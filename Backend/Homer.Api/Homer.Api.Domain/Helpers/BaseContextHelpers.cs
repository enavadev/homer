using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer.Api.Domain.Helpers
{
    public class BaseContextHelpers
    {
        private static string _ConnStr = "";

        public static string GetConnectionStr() => _ConnStr;
        public static string SetConnectionStr(string value) => _ConnStr = value;
    }
}
