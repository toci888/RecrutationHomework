using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrate.ReflectiveTools
{
    public class CsvModelGenerator
    {
        public string GetProperties(string headers)
        {
           // headers = "\"ID\";\"SKU\";\"name\";\"reference_number\";\"EAN\";\"can_be_returned\";\"producer_name\";\"category\";\"is_wire\";\"shipping\";\"package_size\";\"available\";\"logistic_height\";\"logistic_width\";\"logistic_length\";\"logistic_weight\";\"is_vendor\";\"available_in_parcel_locker\";\"default_image\";";

            List<string> properties = headers.Split(",", StringSplitOptions.None).ToList();

            string result = string.Empty;

            foreach (string property in properties)
            {
                if (property.Length > 2)
                {
                    result += "public string " + property.Substring(0, property.Length) + " { get; set; } " + Environment.NewLine;
                }
            }

            return result;
        }

        public string GetFuncEntries(string headers)
        {
            string result = string.Empty;

            List<string> properties = headers.Split(",", StringSplitOptions.None).ToList();

            for (int i = 0; i < properties.Count; i++)
            {
                string property = properties[i].Substring(0, properties[i].Length);

                result += "{ \""  + property + "\", (line, model) => { model."  + property + " = line[" + i + "]; return model; } }," + Environment.NewLine;
                
            }

            return result;
        }
    }
}
