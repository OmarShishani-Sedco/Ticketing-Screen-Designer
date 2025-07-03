namespace TicketingScreenDesigner.Models.Models
{
    public class ButtonModel
    {
        public int ButtonId { get; set; }
        public int ScreenId { get; set; }
        public int BankId { get; set; } 

        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public string Type { get; set; } // "Issue Ticket" or "Show Message"

        public int? ServiceId { get; set; } // Only if Type = Issue Ticket

        public string? MessageEn { get; set; } // Only if Type = Show Message
        public string? MessageAr { get; set; }
    }
}
