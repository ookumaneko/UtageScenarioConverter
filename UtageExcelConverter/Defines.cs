
namespace UtageExcelConverter
{
    public class Defines
    {
        public const string _EXTENSION_XLS = ".xls";
        public const string _EXTENSION_XLSX = ".xlsx";
        
        public const string _EXTENSION_DEFAULT_SCENARIO = "txt";
        public const string _EXTENSION_UTAGE_SCENARIO = _EXTENSION_XLS;

        public const string _MESSAGE_PROCESSING = "作業中...";
        public const string _MESSAGE_INVALID_SCENARIO_PATH = "ドーンだYO！シナリオファイルのパスが不正だYO！";
        public const string _MESSAGE_INVALID_OUTPUT_PATH = "ドーンだYO！書き出し先のパスが不正だYO！";
        public const string _MESSAGE_INVALID_TEMPLATE_PATH = "ドーンだYO！テンプレートファイルのパスが不正だYO！";
        
        public const string _MESSAGE_SUCCESS = "作業が完了しました！";

        public const string _COMMAND_TEXT = "";
        public const string _COMMAND_LINEBREAK = "BR";
        public const string _COMMAND_FADE_IN = "FADEIN";
        public const string _COMMAND_FADE_OUT = "FADEOUT";

        public const string _UTAGE_COMMAND_FADE_IN = "FadeIn";
        public const string _UTAGE_COMMAND_FADE_OUT = "FadeOut";
        
        public const float _DURATION_FADE_DEFAULT = 0.5f;
        public const string _COLOUR_FADE_DEFAULT = "black";
    }
}