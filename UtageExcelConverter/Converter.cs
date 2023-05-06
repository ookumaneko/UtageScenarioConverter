
namespace UtageExcelConverter
{
    public class Converter
    {
        public static ParamResult Convert(ParamConvert param)
        {
            ScenarioToDataConverter scenarioConverter = new ScenarioToDataConverter();
            UtageExcelWriter writer = new UtageExcelWriter();

            ParamResult result = new ParamResult();
            
            var data = scenarioConverter.Convert(param, result);
            if (!result.IsSuccess)
            {
                return result;
            }
            
            return writer.Write(param, data);
        }
    }
}