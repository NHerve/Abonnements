using MagGestion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Helper
{
    public static class FriendlyEnumMethod
    {
        public static string GetFriendlyStatusEnums()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (StatusCode statusCode in Enum.GetValues(typeof(StatusCode)))
            {
                stringBuilder.Append(statusCode.GetDescription());
            }
            return stringBuilder.ToString();
        }
    }
}
