using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherAPI.Utilities
{
    public class ZipcodeHelper
    {
        public static bool IsZipcodeValid(string zipcode)
        {
            var zipcodePattern = @"^\d{5}(-\d{4})?$";

            if ((Regex.Match(zipcode, zipcodePattern).Success))
            {
                return true;
            }

            return false;
        }



    }
}
