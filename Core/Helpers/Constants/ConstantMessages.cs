using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Constants
{
    public class ConstantMessages
    {
        public static readonly string AddMessage = "Added Successfully";
        public static readonly string EditMessage = "Updated Successfully";
        public static readonly string DeleteMessage = "Deleted Successfully";
        public static string RequiredMessage(string property) 
        {
            return (property + " is required");
        }
        public static string LengthMessage(string property, string length)
        {
            return (property + " must be between 1 and" + length + " characters");
        }
    }
}
