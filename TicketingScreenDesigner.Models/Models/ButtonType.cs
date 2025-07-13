namespace TicketingScreenDesigner.Models.Models
{
    public enum ButtonType
    {
        ShowMessage = 0,
        IssueTicket = 1
    }

    public static class ButtonTypeExtensions
    {
        public static string ToDisplayString(this ButtonType type)
        {
            return type switch
            {
                ButtonType.IssueTicket => "Issue Ticket",
                ButtonType.ShowMessage => "Show Message",
                _ => type.ToString()
            };
        }
    }

}
