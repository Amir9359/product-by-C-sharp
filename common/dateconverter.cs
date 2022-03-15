﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
   public static class dateconverter
    {
        public static string PersianDate(this PersianCalendar persian, DateTime date)
        {
            var result = $"{persian.GetHour(date).ToString().PadLeft(2, '0')}:{persian.GetMinute(date).ToString().PadLeft(2, '0')} , {persian.GetYear(date)}/{persian.GetMonth(date).ToString().PadLeft(2, '0')}/{persian.GetDayOfMonth(date).ToString().PadLeft(2, '0')}";
            return result;
        }
    }
}
