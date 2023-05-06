namespace UtageExcelConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPathInput = new System.Windows.Forms.Button();
            this.btnPathOutput = new System.Windows.Forms.Button();
            this.txtPathInput = new System.Windows.Forms.TextBox();
            this.txtPathOutput = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtensionScenario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPathInput
            // 
            this.btnPathInput.Location = new System.Drawing.Point(302, 31);
            this.btnPathInput.Name = "btnPathInput";
            this.btnPathInput.Size = new System.Drawing.Size(27, 24);
            this.btnPathInput.TabIndex = 0;
            this.btnPathInput.Text = "...";
            this.btnPathInput.UseVisualStyleBackColor = true;
            this.btnPathInput.Click += new System.EventHandler(this.btnPathInput_Click);
            // 
            // btnPathOutput
            // 
            this.btnPathOutput.Location = new System.Drawing.Point(302, 74);
            this.btnPathOutput.Name = "btnPathOutput";
            this.btnPathOutput.Size = new System.Drawing.Size(27, 24);
            this.btnPathOutput.TabIndex = 1;
            this.btnPathOutput.Text = "...";
            this.btnPathOutput.UseVisualStyleBackColor = true;
            this.btnPathOutput.Click += new System.EventHandler(this.btnPathOutput_Click);
            // 
            // txtPathInput
            // 
            this.txtPathInput.Location = new System.Drawing.Point(76, 34);
            this.txtPathInput.Name = "txtPathInput";
            this.txtPathInput.Size = new System.Drawing.Size(220, 19);
            this.txtPathInput.TabIndex = 2;
            // 
            // txtPathOutput
            // 
            this.txtPathOutput.Location = new System.Drawing.Point(76, 77);
            this.txtPathOutput.Name = "txtPathOutput";
            this.txtPathOutput.Size = new System.Drawing.Size(220, 19);
            this.txtPathOutput.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(137, 217);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(79, 28);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "変換";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "読み込み先";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-1, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "書き出し先";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "シナリオ拡張子";
            // 
            // txtExtensionScenario
            // 
            this.txtExtensionScenario.Location = new System.Drawing.Point(76, 161);
            this.txtExtensionScenario.Name = "txtExtensionScenario";
            this.txtExtensionScenario.Size = new System.Drawing.Size(52, 19);
            this.txtExtensionScenario.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-1, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "テンプレ";
            // 
            // txtTemplate
            // 
            this.txtTemplate.Location = new System.Drawing.Point(76, 120);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(220, 19);
            this.txtTemplate.TabIndex = 10;
            // 
            // btnTemplate
            // 
            this.btnTemplate.Location = new System.Drawing.Point(302, 117);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(27, 24);
            this.btnTemplate.TabIndex = 9;
            this.btnTemplate.Text = "...";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 257);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExtensionScenario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtPathOutput);
            this.Controls.Add(this.txtPathInput);
            this.Controls.Add(this.btnPathOutput);
            this.Controls.Add(this.btnPathInput);
            this.Name = "Form1";
            this.Text = "宴シナリオ変換君";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Button btnTemplate;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtensionScenario;

        private System.Windows.Forms.Button btnPathInput;
        private System.Windows.Forms.Button btnPathOutput;
        private System.Windows.Forms.TextBox txtPathInput;
        private System.Windows.Forms.TextBox txtPathOutput;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        #endregion
    }
}