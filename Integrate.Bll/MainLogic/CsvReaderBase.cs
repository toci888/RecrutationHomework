using AutoMapper;
using Integrate.Bll.Parsing;
using Integrate.Common.Interfaces;

namespace Integrate.Bll.MainLogic
{
    public abstract class CsvReaderBase<TModel, TCsvModel> 
        where TModel : class 
        where TCsvModel : new()
    {
        protected IDbHandle<TModel> DbHandle = new IntegrateDbHandle<TModel>();
        protected ParseCsvBase<TCsvModel> CsvParser;
        protected string Path;
        protected string Delimiter;
        protected bool SkipFirstLine;

        public virtual void ParseFile()
        {
            using (StreamReader textReader = new StreamReader(Path))
            {
                if (SkipFirstLine)
                {
                    textReader.ReadLine();
                }

                while (!textReader.EndOfStream)
                {
                    string csvLine = textReader.ReadLine();

                    if (!csvLine.Contains("__empty_line__"))
                    {
                        TCsvModel csvModel = CsvParser.ParseCsvLine(csvLine.Split(Delimiter, StringSplitOptions.None));

                        if (Qualify(csvModel))
                        {
                            DbHandle.Insert(Map(csvModel));
                        }
                    }
                }
            }
        }

        protected virtual TModel Map(TCsvModel csvModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
                cfg.CreateMap<TCsvModel, TModel>());

            Mapper mapper = new Mapper(config);

            return mapper.Map<TModel>(csvModel);
        }

        protected abstract bool Qualify(TCsvModel csvModel);
    }
}
