namespace UtageExcelConverter
{
    public class CommandCreator
    {
        public static DataCommand CreateLineBreak()
        {
            var command = new DataCommand();
            command.Command = Defines._COMMAND_LINEBREAK;
            command.Type = CommandType.NewLine;
            return command;
        }

        public static DataCommand CreateFadeIn()
        {
            var command = new DataCommand();
            command.Command = Defines._UTAGE_COMMAND_FADE_IN;
            command.Type = CommandType.FadeIn;
            command.Arg1 = Defines._COLOUR_FADE_DEFAULT;
            command.Arg6 = Defines._DURATION_FADE_DEFAULT.ToString();
            return command;
        }
        
        public static DataCommand CreateFadeOut()
        {
            var command = new DataCommand();
            command.Command = Defines._UTAGE_COMMAND_FADE_OUT;
            command.Type = CommandType.FadeOut;
            command.Arg1 = Defines._COLOUR_FADE_DEFAULT;
            command.Arg6 = Defines._DURATION_FADE_DEFAULT.ToString();
            return command;
        }
    }
}