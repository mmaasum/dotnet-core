using System;

namespace Talent.Common.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static int ToAge(this DateTime? birthDate)
        {
            if (birthDate == null)
                return -1;
            var years = DateTime.Now.Year - ((DateTime)birthDate).Year;
            //get the date of the birthday this year
            var birthdayThisYear = ((DateTime)birthDate).AddYears(years);
            int age = birthdayThisYear > DateTime.Now ? years - 1 : years;
            return age;
        }
    }
}
