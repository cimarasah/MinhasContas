using MinhasContas.Domain.Enuns;
using System;

namespace MinhasContas.Domain.Extension
{
    public static class InvoiceCardExtension
    {
        public static DateTime GetDate(int day, MonthEnum mes)
        {
            DateTime date;
            date = new DateTime(DateTime.Now.Year, (int)mes, day);
            return DiaUtil(date);
        }
        private static DateTime DiaUtil(DateTime dt)
        {
            while (true)
            {
                if (dt.DayOfWeek == DayOfWeek.Saturday)
                {
                    dt = dt.AddDays(2);
                    return DiaUtil(dt);
                }
                else if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    dt = dt.AddDays(1);
                    return DiaUtil(dt);
                }
                else return dt;
            }
        }
        

    }
}
