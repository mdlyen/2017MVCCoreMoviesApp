using System;

namespace Movies.Web.Shared
{
    public static class DateExtensions
    {
        public static string Year(this DateTime? dt)
        {
            return dt?.Year.ToString();
        }
    }
}