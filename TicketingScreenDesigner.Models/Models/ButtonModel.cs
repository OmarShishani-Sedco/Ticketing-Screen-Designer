namespace TicketingScreenDesigner.Models.Models
{
    public class ButtonModel
    {
        public int ButtonId { get; set; }
        public int ScreenId { get; set; }
        public int BankId { get; set; } 

        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public ButtonType Type { get; set; } // "Issue Ticket" or "Show Message"

        public int? ServiceId { get; set; } // Only if Type = Issue Ticket

        public string? MessageEn { get; set; } // Only if Type = Show Message
        public string? MessageAr { get; set; }
        public byte[] RowVersion { get; set; } 


        public ButtonModel Clone()
        {
            return new ButtonModel
            {
                ButtonId = this.ButtonId,
                ScreenId = this.ScreenId,
                NameEn = this.NameEn,
                NameAr = this.NameAr,
                Type = this.Type,
                MessageEn = this.MessageEn,
                MessageAr = this.MessageAr,
                ServiceId = this.ServiceId,
                BankId = this.BankId,
                RowVersion = this.RowVersion
            };
        }


    }
}
