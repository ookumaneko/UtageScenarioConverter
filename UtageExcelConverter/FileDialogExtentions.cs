using System;
using System.IO;
using System.Windows.Forms;

namespace UtageExcelConverter
{
	static class FileDialogExtentions
	{
		/// <summary>環境変数名</summary>
		private static string environmentVariableName = $"{Application.ProductName}_CURRENT_DIR_PATH";

		/// <summary>環境変数アクセサ</summary>
		private static string EnvironmentValue
		{
			get
			{
				// 環境変数の値取得
				string variable = Environment.GetEnvironmentVariable (environmentVariableName, EnvironmentVariableTarget.User);
				if (string.IsNullOrEmpty (variable))
				{   // Nullの場合（初回）のみデスクトップとする
					return Environment.GetFolderPath (Environment.SpecialFolder.Desktop);
				}
				return variable;
			}
			set
			{
				// 環境変数の値設定
				Environment.SetEnvironmentVariable (environmentVariableName, value, EnvironmentVariableTarget.User);
			}
		}

		public static string GetEnvirionmentValue (string name)
		{
			// 環境変数の値取得
			string variable = Environment.GetEnvironmentVariable (environmentVariableName + name, EnvironmentVariableTarget.User);
			if (string.IsNullOrEmpty (variable))
			{   // Nullの場合（初回）のみデスクトップとする
				return Environment.GetFolderPath (Environment.SpecialFolder.Desktop);
			}
			return variable;
		}

		public static void SetEnvironmentValue (string name, string savePath)
		{
			// 環境変数の値設定
			Environment.SetEnvironmentVariable (environmentVariableName + name, savePath, EnvironmentVariableTarget.User);
		}

		/// <summary>
		/// <para>OpenFileDialog.ShowDialogの拡張メソッド</para>
		/// <para>初期フォルダーを設定し、OK選択時に作業ディレクトリを保存します</para>
		/// </summary>
		/// <param name="self"></param>
		/// <param name="window"></param>
		/// <returns></returns>
		public static DialogResult ShowDialogEx (this OpenFileDialog self, IWin32Window window)
		{
			self.InitialDirectory = EnvironmentValue;

			DialogResult ret = self.ShowDialog (window);
			if (ret.Equals (DialogResult.OK))
			{   // OK選択時は選択したファイルのディレクトリを保存する
				EnvironmentValue = Path.GetDirectoryName (self.FileName);
			}
			return ret;
		}

		/// <summary>
		/// <para>FolderBrowserDialog.ShowDialogの拡張メソッド</para>
		/// <para>初期フォルダーを設定し、OK選択時に作業ディレクトリを保存します</para>
		/// </summary>
		/// <param name="self"></param>
		/// <param name="window"></param>
		/// <returns></returns>
		public static DialogResult ShowDialogEx (this FolderBrowserDialog self, IWin32Window window)
		{
			self.SelectedPath = EnvironmentValue;

			DialogResult ret = self.ShowDialog (window);
			if (ret.Equals (DialogResult.OK))
			{   // OK選択時は選択したディレクトリを保存する
				EnvironmentValue = self.SelectedPath;
			}
			return ret;
		}

		/// <summary>
		/// <para>SaveFileDialog.ShowDialogの拡張メソッド</para>
		/// <para>初期フォルダーを設定し、保存選択時に作業ディレクトリを保存します</para>
		/// </summary>
		/// <param name="self"></param>
		/// <param name="window"></param>
		/// <returns></returns>
		public static DialogResult ShowDialogEx (this SaveFileDialog self, IWin32Window window)
		{
			self.InitialDirectory = EnvironmentValue;

			DialogResult ret = self.ShowDialog (window);
			if (ret.Equals (DialogResult.OK))
			{   // OK選択時は選択したファイルのディレクトリを保存する
				EnvironmentValue = Path.GetDirectoryName (self.FileName);
			}
			return ret;
		}

		// ----------------------------------------- //

		/// <para>OpenFileDialog.ShowDialogの拡張メソッド</para>
		/// <para>初期フォルダーを設定し、OK選択時に作業ディレクトリを保存します</para>
		/// </summary>
		/// <param name="self"></param>
		/// <param name="window"></param>
		/// <returns></returns>
		public static DialogResult ShowDialogEx (this OpenFileDialog self, IWin32Window window, string name)
		{
			self.InitialDirectory = GetEnvirionmentValue( name );

			DialogResult ret = self.ShowDialog (window);
			if (ret.Equals (DialogResult.OK))
			{   // OK選択時は選択したファイルのディレクトリを保存する
				SetEnvironmentValue(name, Path.GetDirectoryName (self.FileName) );
			}
			return ret;
		}

		/// <summary>
		/// <para>FolderBrowserDialog.ShowDialogの拡張メソッド</para>
		/// <para>初期フォルダーを設定し、OK選択時に作業ディレクトリを保存します</para>
		/// </summary>
		/// <param name="self"></param>
		/// <param name="window"></param>
		/// <returns></returns>
		public static DialogResult ShowDialogEx (this FolderBrowserDialog self, IWin32Window window, string name)
		{
			self.SelectedPath = GetEnvirionmentValue (name);

			DialogResult ret = self.ShowDialog (window);
			if (ret.Equals (DialogResult.OK))
			{   // OK選択時は選択したディレクトリを保存する
				SetEnvironmentValue (name, self.SelectedPath );
			}
			return ret;
		}

		/// <summary>
		/// <para>SaveFileDialog.ShowDialogの拡張メソッド</para>
		/// <para>初期フォルダーを設定し、保存選択時に作業ディレクトリを保存します</para>
		/// </summary>
		/// <param name="self"></param>
		/// <param name="window"></param>
		/// <returns></returns>
		public static DialogResult ShowDialogEx (this SaveFileDialog self, IWin32Window window, string name)
		{
			self.InitialDirectory = GetEnvirionmentValue (name);

			DialogResult ret = self.ShowDialog (window);
			if (ret.Equals (DialogResult.OK))
			{   // OK選択時は選択したファイルのディレクトリを保存する
				SetEnvironmentValue (name, Path.GetDirectoryName (self.FileName) );
			}
			return ret;
		}
	}
}
