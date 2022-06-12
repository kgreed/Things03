using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using Things03.Module.BusinessObjects;

namespace Things03.Module.Functions
{
    public static class StringFunctions
    {
        public static string SafeString(string s)
        {
            Regex r = new Regex("^[a-zA-Z0-9 ]*$");
            if (!r.IsMatch(s))
            {
                throw new Exception(s + "is not alphanumeric or space. Please only enter numbers letters or spaces in your search.");
            }
            return s;

        }
    }
}
