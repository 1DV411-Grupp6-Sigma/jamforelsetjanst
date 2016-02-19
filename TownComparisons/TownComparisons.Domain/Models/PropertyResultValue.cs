using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyResultValue
    {
        public string Gender { get; set; }
        public string Status { get; set; }
        public float? Value { get; set; }  // is it always of number type? never a string or similar?
        
        //Constructors
        public PropertyResultValue()
        {
            // Empty
        }
        public PropertyResultValue(string gender, string status, float? value)
        {
            Gender = gender;
            Status = status;
            Value = value;
        }
    }
}
