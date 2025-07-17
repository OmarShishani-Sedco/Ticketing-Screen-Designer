namespace TicketingScreenDesigner.Models.Models
{
    public class ScreenModel
    {
        public int ScreenId { get; set; }
        public int BankId { get; set; }
        public string ScreenName { get; set; }
        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; }


        public ScreenModel Clone()
        {
            return new ScreenModel
            {
                ScreenId = this.ScreenId,
                BankId = this.BankId,
                ScreenName = this.ScreenName,
                IsActive = this.IsActive
            };
        }
        
    }
}
