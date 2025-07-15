using System.Windows.Forms;
using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{

    public partial class AddEditScreenForm : Form
    {
        private Point _selectionStart;
        private Rectangle _selectionRect;
        private bool _isSelecting = false;
        private readonly ToolTip _tooltip = new ToolTip();

        private readonly IScreenManager _screenManager;
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;
        private readonly BankModel _bank;
        private ScreenModel _screen;
        private readonly bool _isEditMode;
        private List<ButtonModel> _buttons = new();
        private bool _isSaved = false;
        private bool _isChanged;
        private ScreenModel _originalScreen;
        private List<ButtonModel> _originalButtons;

        public AddEditScreenForm(
            BankModel bank,
            IScreenManager screenManager,
            IButtonManager buttonManager,
            IServiceManager serviceManager,
            ScreenModel existingScreen = null)
        {
            InitializeComponent();

            _bank = bank;
            _screenManager = screenManager;
            _buttonManager = buttonManager;
            _serviceManager = serviceManager;
            _isEditMode = existingScreen != null;
            _tooltip.IsBalloon = true;
            _tooltip.ToolTipIcon = ToolTipIcon.Warning;

            _screen = existingScreen ?? new ScreenModel
            {
                BankId = _bank.BankId,
                ScreenId = -1 // Indicates not yet saved
            };

            InitializeForm();
            this.FormClosing += AddEditScreenForm_FormClosing;
        }

        private void InitializeForm()
        {
            txtScreenName.Text = _screen.ScreenName ?? "";
            chkIsActive.Checked = _screen.IsActive;

            if (_isEditMode)
            {
                this.Text = "Edit Screen";
                _buttons = _buttonManager.GetButtonsForScreen(_screen.ScreenId);
                _originalScreen = _screen.Clone();
                _originalButtons = _buttons.Select(b => b.Clone()).ToList();
                if (_buttons.Count > 0)
                {
                    UpdateStatus("Button(s) loaded successfully.");
                }
            }
            else
            {
                this.Text = "Add Screen";
            }

            RefreshButtonList();
            UpdateButtonActionsEnabled();
            _isChanged = false;
        }

        private void RefreshButtonList()
        {
            listViewButtons.Items.Clear();

            foreach (var button in _buttons)
            {
                var item = new ListViewItem(button.NameEn);
                item.SubItems.Add(button.NameAr);
                item.SubItems.Add(button.Type.ToDisplayString());
                item.Tag = button;

                listViewButtons.Items.Add(item);
            }

            UpdateButtonActionsEnabled();
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            var form = new AddEditButtonForm(_screen.ScreenId, _bank.BankId, _buttonManager, _serviceManager);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _buttons.Add(form.ResultButton);
                _isChanged = true;
                RefreshButtonList();
            }
        }

        private void btnEditButton_Click(object sender, EventArgs e)
        {
            if (listViewButtons.SelectedItems.Count != 1) return;

            var selectedItem = listViewButtons.SelectedItems[0];
            var selected = selectedItem.Tag as ButtonModel;

            var form = new AddEditButtonForm(_screen.ScreenId, _bank.BankId, _buttonManager, _serviceManager, selected);
            if (form.ShowDialog() == DialogResult.OK)
            {
                int index = _buttons.FindIndex(b => b.ButtonId == selected.ButtonId);
                if (index >= 0)
                    _buttons[index] = form.ResultButton;
                _isChanged = true;

                RefreshButtonList();
            }
        }

        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            if (listViewButtons.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one button to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected button(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var buttonsToDelete = new List<ButtonModel>();
            foreach (ListViewItem item in listViewButtons.SelectedItems)
            {
                if (item.Tag is ButtonModel btn)
                {
                    buttonsToDelete.Add(btn);
                }
            }

            foreach (var btn in buttonsToDelete)
                _buttons.Remove(btn);
            _isChanged = true;

            RefreshButtonList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScreenName.Text))
            {
                MessageBox.Show("Screen name is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_buttons.Count == 0)
            {
                MessageBox.Show("A screen must contain at least one button.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _screen.ScreenName = txtScreenName.Text.Trim();
            _screen.IsActive = chkIsActive.Checked;

            try
            {
                if (_isEditMode)
                {
                    _screenManager.UpdateScreen(_screen);

                    var existingButtons = _buttonManager.GetButtonsForScreen(_screen.ScreenId);
                    var existingIds = existingButtons.Select(b => b.ButtonId).ToHashSet();
                    var currentIds = _buttons.Where(b => b.ButtonId != 0).Select(b => b.ButtonId).ToHashSet();

                    foreach (var btn in existingButtons)
                    {
                        if (!currentIds.Contains(btn.ButtonId))
                            _buttonManager.DeleteButton(btn.ButtonId);
                    }

                    foreach (var btn in _buttons)
                    {
                        btn.ScreenId = _screen.ScreenId;

                        if (btn.ButtonId == 0)
                            _buttonManager.AddButton(btn);
                        else
                            _buttonManager.UpdateButton(btn);
                    }

                    UpdateStatus("Screen and buttons updated successfully.");
                }
                else
                {
                    _screen = _screenManager.AddScreen(_screen);
                    foreach (var btn in _buttons)
                    {
                        btn.ScreenId = _screen.ScreenId;
                        _buttonManager.AddButton(btn);
                    }

                    UpdateStatus("Screen and buttons saved successfully.");
                }

                _isSaved = true;
                _isChanged = false;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "AddEditScreenForm_Save");
            }
        }

        private void AddEditScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isSaved && !_isEditMode && _screen.ScreenId == -1 && _buttons.Count != 0)
            {
                var confirm = MessageBox.Show(
                    "You haven't saved the screen yet. Are you sure you want to close? (warning: all buttons will be deleted)",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_isSaved && !_isEditMode && _screen.ScreenId == -1 && _buttons.Count != 0)
            {
                var confirm = MessageBox.Show(
                    "You haven't saved the screen yet. Are you sure you want to close? (warning: all buttons will be deleted)",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                {
                    return;
                }
            }
            if (!_isSaved && _isEditMode && _isChanged)
            {
                var confirm = MessageBox.Show(
                   "You haven't saved the screen yet. Are you sure you want to close? (warning: all changes will be reverted)",
                   "Unsaved Changes",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning);
                _screen = _originalScreen.Clone();
                _buttons = _originalButtons.Select(b => b.Clone()).ToList();

                if (confirm == DialogResult.No)
                {
                    return;
                }
            }


            this.Close();
        }

        private void listViewButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonActionsEnabled();
        }

        private void UpdateButtonActionsEnabled()
        {
            int selectedCount = listViewButtons.SelectedItems.Count;

            btnEditButton.Enabled = selectedCount == 1;
            btnDeleteButton.Enabled = selectedCount > 0;
        }

        private void statusClearTimer_Tick(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
            statusClearTimer.Stop();
            statusStrip.Visible = false;
        }
        private void UpdateStatus(string message)
        {
            statusStrip.Visible = true;
            StatusLabel.Text = message;
            statusClearTimer.Stop();
            statusClearTimer.Start();
        }


        //Utility methods for custom design
        private void listViewButtons_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isSelecting = true;
                _selectionStart = listViewButtons.PointToScreen(e.Location);
                _selectionRect = new Rectangle(_selectionStart, new Size(0, 0));
            }
        }

        private void listViewButtons_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isSelecting)
            {
                ControlPaint.DrawReversibleFrame(_selectionRect, Color.Black, FrameStyle.Dashed);

                Point currentPoint = listViewButtons.PointToScreen(e.Location);
                _selectionRect = GetNormalizedRectangle(_selectionStart, currentPoint);

                ControlPaint.DrawReversibleFrame(_selectionRect, Color.Black, FrameStyle.Dashed);
            }
        }

        private void listViewButtons_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isSelecting)
            {
                _isSelecting = false;
                ControlPaint.DrawReversibleFrame(_selectionRect, Color.Black, FrameStyle.Dashed);

                Rectangle selectionBox = listViewButtons.RectangleToClient(_selectionRect);
                foreach (ListViewItem item in listViewButtons.Items)
                {
                    if (item.Bounds.IntersectsWith(selectionBox))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        private Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }

        private void txtScreenName_TextChanged(object sender, EventArgs e)
        {
            _isChanged = true;
            if (txtScreenName.Text.Length == txtScreenName.MaxLength)
            {
                _tooltip.Show(
                    $"Maximum length of {txtScreenName.MaxLength} characters reached.",
                    txtScreenName,
                    90, -65,
                    3000);
            }
            else
            {
                _tooltip.Hide(txtScreenName);
            }
        }

        private void chkIsActive_TextChanged(object sender, EventArgs e)
        {
            _isChanged = true;
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            _isChanged = true;
        }
    }
}
