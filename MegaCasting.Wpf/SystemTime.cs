using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Wpf
{
    public static class SystemTime
    {
        public static Func<DateTime> DateProvider = () => DateTime.Now;

        public static DateTime Now { get { return DateProvider(); } }
    }
}
