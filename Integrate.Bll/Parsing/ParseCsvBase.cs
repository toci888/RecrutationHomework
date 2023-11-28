using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrate.Bll.Parsing
{
    public abstract class ParseCsvBase<TCsvModel> where TCsvModel : new()
    {
        protected Dictionary<string, Func<string[], TCsvModel, TCsvModel>> ParsingMap;

        public virtual TCsvModel ParseCsvLine(string[] csvLine)
        {
            TCsvModel model = new TCsvModel();

            csvLine = SkipQuoting(csvLine);

            if (csvLine.Length > 0)
            {
                foreach (KeyValuePair<string, Func<string[], TCsvModel, TCsvModel>> parseEntry in ParsingMap)
                {
                    model = parseEntry.Value(csvLine, model);
                }
            }

            return model;
        }

        private string[] SkipQuoting(string[] values) 
        {
            for(int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Replace("\"", "");
            }

            return values;
        }
    }
}
