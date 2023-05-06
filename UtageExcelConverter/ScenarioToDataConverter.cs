using System;
using System.IO;
using System.Text;

namespace UtageExcelConverter
{
    public class ScenarioToDataConverter
    {
        static readonly string[] _COMMAND_REMOVE_TEXT = { " ", "　" };
        static readonly string[] _COMMAND_CHARA_START = { "[", "［" };
        static readonly string[] _COMMAND_CHARA_END = { "]", "］" };
        static readonly string[] _COMMAND_START = { "<", "＜" };
        static readonly string[] _COMMAND_END = { ">", "＞" };
        
        const string _COMMAND_COMMENT = "//";
        const string _COMMAND_CONTE_START = "/*";
        const string _COMMAND_CONTE_END = "*/";

        const string _TEXT_TEB = "\t";
        const string _TEXT_LINEBREAK = "\n";
        
        public DataConvert Convert(ParamConvert param, ParamResult result)
        {
            DataConvert data = new DataConvert();
            var files = Directory.GetFiles ($"{param.PathInputFolder}\\", $"*.{param.ExtensionScenarioFile}",
                SearchOption.AllDirectories);
            
            var count = files.Length;
            for (int i = 0; i < count; ++i)
            {
                //EditorUtility.DisplayProgressBar ("Processing...", $"ファイル: ${files[i]}を変換中", i / count);
                ProcessFile (param, data, files[i]);
                //EditorUtility.ClearProgressBar ();
            }

            return data;
        }

        private void ProcessFile(ParamConvert param, DataConvert outputData, in string filePath)
        {
            //Debug.Log ($"Start convert file: {filePath}");
            StreamReader stream = new StreamReader (filePath, Encoding.UTF8, true);

            DataFile currentFile = new DataFile(Path.GetFileNameWithoutExtension(filePath));
            DataCommand currentDataCommand = new DataCommand ();
            //bool isConte = false;

            while (!stream.EndOfStream)
            {
                var line = ReadLine (stream);

                // 空の時は保存する
                if (string.IsNullOrEmpty (line))
                {
                    if (!currentDataCommand.IsEmpty())
                    {
                        currentFile.Commands.Add(new DataCommand(currentDataCommand));
                    }

                    currentDataCommand.Reset ();
                    continue;
                }

                // コメント "//" 対応
                if (line.Contains (_COMMAND_COMMENT))
                {
                    currentFile.Commands.Add (new DataCommand ()
                    {
                        Text = line, //line.Replace (_COMMAND_COMMENT, ""),
                        IsComment = true,
                    });
                    continue;
                }

                /*// 字コンテ開始 "/*字コンテ"
                if (line.Contains (_COMMAND_CONTE_START))
                {
                    isConte = true;
                    continue;
                }

                // 字コンテ終了 "#1#"
                if (line.Contains (_COMMAND_CONTE_END))
                {
                    isConte = false;
                    continue;
                }*/

                // [キャラ名指定]
                if (HasTextInArray (in line, in _COMMAND_CHARA_START))
                {
                    // todo: キャラ名変換
                    ConvertCharaToID (currentDataCommand, in line);
                    continue;
                }

                // <コマンド>
                /*if (HasTextInArray (in line, in _COMMAND_START))
                {
                    //isConte = false;
                    ProcessCommands (in line, currentFile, currentDataCommand);
                    continue;
                }*/

                /*// 字コンテ中の場合はテキスト本体は飛ばしたい
                if (isConte)
                {
                    if (!string.IsNullOrEmpty (currentData.Conte))
                    {
                        currentData.Conte += _TEXT_LINEBREAK;
                    }

                    currentData.Conte += line;
                    continue;
                }*/

                // テキスト毎に改行する
                if (!string.IsNullOrEmpty (currentDataCommand.Text))
                {
                    currentDataCommand.Text += _TEXT_LINEBREAK;
                }

                currentDataCommand.Text += line;
            }

            OnFileEnd(outputData, currentFile, currentDataCommand);
        }
        
        private static void ConvertCharaToID (DataCommand currentData, in string line)
        {
            var chara = RemoveTextInArray (line, in _COMMAND_CHARA_START);
            chara = RemoveTextInArray (chara, in _COMMAND_CHARA_END);

            currentData.Arg1 = chara;
        }
        
        /*
        private static void ProcessCommands (in string line, DataFile currentFile, DataCommand currentData)
		{
			var command = RemoveTextInArray (line, in _COMMAND_START);
			command = RemoveTextInArray (command, in _COMMAND_END).ToUpper ();
			
			// 分岐前にテキスト書き出しとコンテ終了
			if (string.IsNullOrEmpty (currentData.Text))
			{
				currentFile.Commands.Add (new DataCommand(currentData));
				currentData.Reset ();
			}
			//isConte = false;

			// 選択肢 <選択...>
			if (command.Contains (_COMMAND_SELECTION_TEXT))
			{
				// 空白消す
				command = command.Replace (" ", "");
				command = command.Replace ("　", "");

				var result = command.Split (_COMMAND_SELECTION_SEPARATOR);

				// 種類
				currentData.Text = result[0];

				// パラメーター
				StringBuilder builder = new StringBuilder ();
				var textLength = result.Length;
				for (int i = 1; i < textLength; ++i)
				{
					builder.Append (result[i]);
					builder.Append (System.Environment.NewLine);
				}

				currentData.Direction = builder.ToString ();
				currentData.Chara = _COMMAND_SELECTION_TEXT;
				currentData.Conte = string.Empty;
				currentFile.Commands.Add (new DataCommand(currentData));
				return;
			}

			// 分岐一括
			var commandLength = _COMMAND_BRANCH_LIST.Length;
			var hasCommand = false;
			for (var kk = 0; kk < commandLength; ++kk)
			{
				// 選択肢用のテキスト書き込み
				hasCommand = command.Contains (_COMMAND_BRANCH_LIST[kk]);
				if (!hasCommand)
				{
					continue;
				}

				if (kk == _LABEL_COMMAND_INDEX)
				{
					// ラベル
					currentData.Text = command;
				}
				else
				{
					// 分岐系
					currentData.Text = _COMMAND_BRANCH_LIST[kk];
				}

				// 念の為
				currentData.Chara = string.Empty;
				break;
			}

			// 分岐が有ったら次に行く
			if (hasCommand)
			{
				return;
			}
			
			// ...他有れば足す
		}
*/
        
        private void OnFileEnd(DataConvert outputData, DataFile currentFile, DataCommand currentData)
        {
	        // 溜まってるテキストを先に書き出しておく
	        currentFile.Commands.Add (new DataCommand(currentData));
			
	        // 現在のファイルを追加
	        outputData.Add(currentFile);

	        // リセット処理
	        currentData.Reset ();   
        }
        
        private static string ReadLine (StreamReader stream)
        {
            return stream.ReadLine ().Replace (" ", "").Replace (_TEXT_TEB, "");
        }
        
        private static bool HasTextInArray (in string text, in string[] array)
        {
            foreach (var element in array)
            {
                if (text.Contains (element))
                {
                    return true;
                }
            }

            return false;
        }

        private static string RemoveTextInArray (string text, in string[] array)
        {
            foreach (var element in array)
            {
                text = text.Replace (element, "");
            }

            return text;
        }
    }
}