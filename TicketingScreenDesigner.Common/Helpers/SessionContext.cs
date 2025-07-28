using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingScreenDesigner.Common.Helpers
{

    public static class SessionContext
    {
        private static bool _initialized = false;
        public static string CurrentUserName { get; private set; }
        public static int? CurrentBankId { get; set; } // can change at runtime
        public static bool IsSuperAdmin { get; set; } = false;


        public static void Initialize(string currentUserName)
        {
            if (_initialized)
                return;
            CurrentUserName = currentUserName ?? throw new ArgumentNullException(nameof(currentUserName), "Current user name cannot be null.");

            IsSuperAdmin = CurrentUserName.Equals("sa", StringComparison.OrdinalIgnoreCase)
                            || CurrentUserName.Equals("dbo", StringComparison.OrdinalIgnoreCase);
            _initialized = true;
        }
    }

}
