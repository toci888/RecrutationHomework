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

        public virtual TCsvModel Parse(string[] csvLine)
        {
            TCsvModel model = new TCsvModel();

            foreach (KeyValuePair<string, Func<string[], TCsvModel, TCsvModel>> parseEntry in ParsingMap)
            {
                model = parseEntry.Value(csvLine, model);
            }

            return model;
        }
    }
}
