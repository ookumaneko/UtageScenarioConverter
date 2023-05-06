using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace UtageExcelConverter
{
    public partial class Form1 : Form
    {
        const string _NAME_READ = "pathCsv";
        const string _NAME_OUTPUT = "pathOutput";
        
        public Form1()
        {
            InitializeComponent();
            txtExtensionScenario.Text = Defines._EXTENSION_DEFAULT_SCENARIO;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!IsConvertable())
            {
                return;
            }
            
            Convert();
        }

        private bool IsConvertable()
        {
            if (!IsValidPath(txtPathInput.Text))
            {
                OpenDialog(Defines._MESSAGE_INVALID_SCENARIO_PATH);
                return false;
            }
            
            if (!IsValidPath(txtPathOutput.Text))
            {
                OpenDialog(Defines._MESSAGE_INVALID_OUTPUT_PATH);
                return false;
            }

            if (!IsValidFilePath(txtTemplate.Text))
            {
                OpenDialog(Defines._MESSAGE_INVALID_TEMPLATE_PATH);
                return false;
            }
            
            return true;
        }

        private bool IsValidPath (in string path) => (!string.IsNullOrEmpty (path) && Directory.Exists (path));
        private bool IsValidFilePath (in string path) => (!string.IsNullOrEmpty (path) && File.Exists (path));

        private void Convert()
        {
            // 作業中の色替え…
            var defaultColor = this.BackColor;
            this.BackColor = Color.Gray;

            var originalText = this.Text;
            this.Text = Defines._MESSAGE_PROCESSING;
            
            // 変換処理
            var param = CreateParam();
            var result = Converter.Convert(param);
            
            OpenDialog(result.Message);
            
            // 色替えを戻す
            this.BackColor = defaultColor;
            this.Text = originalText;
        }

        private ParamConvert CreateParam()
        {
            ParamConvert param = new ParamConvert();
            param.PathInputFolder = txtPathInput.Text;
            param.PathOutputFolder = txtPathOutput.Text;
            param.ExtensionScenarioFile = txtExtensionScenario.Text;
            param.PathTemplateFile = txtTemplate.Text;
            return param;
        }
        
        private void OpenDialog (string message)
        {
            Dialog dialog = new Dialog ();
            dialog.Message = message;
            dialog.ShowDialog ();
        }

        private void btnPathInput_Click(object sender, EventArgs e)
        {
            SetPathToTextBox (txtPathInput, _NAME_READ);
        }

        private void btnPathOutput_Click(object sender, EventArgs e)
        {
            SetPathToTextBox (txtPathOutput, _NAME_OUTPUT);
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog ();

            dialog.Filter = $"Excelファイル(*{Defines._EXTENSION_UTAGE_SCENARIO})|*{Defines._EXTENSION_UTAGE_SCENARIO}";
            dialog.Title = "使用するシナリオテンプレファイルを選択してください";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog () == DialogResult.OK)
            {
                txtTemplate.Text = dialog.FileName;
            }
        }
        
        private void SetPathToTextBox (TextBox target, in string name)
        {
            var path = OpenFolderDialog (name);
            if (string.IsNullOrEmpty (path))
            {
                return;
            }

            target.Text = path;
        }

        private string OpenFolderDialog (in string name, in string description = "フォルダを指定してください。")
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog ();

            dialog.Description = description;
            dialog.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (dialog.ShowDialogEx (this, name) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                Console.WriteLine (dialog.SelectedPath);
                return dialog.SelectedPath;
            }

            return string.Empty;
        }        
    }
}