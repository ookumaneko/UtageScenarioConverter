namespace UtageExcelConverter
{
    public class DataCommand
    {
        public string Command = string.Empty;
        public string Arg1 = string.Empty;
        public string Arg2 = string.Empty;
        public string Arg3 = string.Empty;
        public string Arg4 = string.Empty;
        public string Arg5 = string.Empty;
        public string Arg6 = string.Empty;
        public string WaitType = string.Empty;
        public string Text = string.Empty;
        public string PageCtrl = string.Empty;
        public string Voice = string.Empty;
        public string WindowType = string.Empty;
        public string English = string.Empty;
        public bool IsComment = false;
        
        public DataCommand ()
        {
            Reset();
        }
        
        public DataCommand (DataCommand source)
        {
            Command = source.Command;
            Arg1 = source.Arg1;
            Arg2 = source.Arg2;
            Arg3 = source.Arg3;
            Arg4 = source.Arg4;
            Arg5 = source.Arg5;
            Arg6 = source.Arg6;
            WaitType = source.WaitType;
            Text = source.Text;
            PageCtrl = source.PageCtrl;
            Voice = source.Voice;
            WindowType = source.WindowType;
            English = source.English;
            IsComment = source.IsComment;
        }

        public void Reset()
        {
            Command = string.Empty;
            Arg1 = string.Empty;
            Arg2 = string.Empty;
            Arg3 = string.Empty;
            Arg4 = string.Empty;
            Arg5 = string.Empty;
            Arg6 = string.Empty;
            WaitType = string.Empty;
            Text = string.Empty;
            PageCtrl = string.Empty;
            Voice = string.Empty;
            WindowType = string.Empty;
            English = string.Empty;
            IsComment = false;
        }

        public bool IsEmpty()
        {
            return (string.IsNullOrWhiteSpace(Command)
                && string.IsNullOrWhiteSpace(Arg1)
                && string.IsNullOrWhiteSpace(Arg2)
                && string.IsNullOrWhiteSpace(Arg3)
                && string.IsNullOrWhiteSpace(Arg4)
                && string.IsNullOrWhiteSpace(Arg5)
                && string.IsNullOrWhiteSpace(Arg6)
                && string.IsNullOrWhiteSpace(WaitType)
                && string.IsNullOrWhiteSpace(Text)
                && string.IsNullOrWhiteSpace(PageCtrl)
                && string.IsNullOrWhiteSpace(Voice)
                && string.IsNullOrWhiteSpace(WindowType)
                && string.IsNullOrWhiteSpace(English)
                );
        }
    }
}