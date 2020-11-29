namespace Evision_profile_detec
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbimg = new System.Windows.Forms.PictureBox();
            this.btnDetect = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Value_In = new System.Windows.Forms.TextBox();
            this.Value_Out = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg)).BeginInit();
            this.SuspendLayout();
            // 
            // pbimg
            // 
            this.pbimg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbimg.Location = new System.Drawing.Point(573, 80);
            this.pbimg.Margin = new System.Windows.Forms.Padding(4);
            this.pbimg.Name = "pbimg";
            this.pbimg.Size = new System.Drawing.Size(562, 425);
            this.pbimg.TabIndex = 0;
            this.pbimg.TabStop = false;
            // 
            // btnDetect
            // 
            this.btnDetect.Font = new System.Drawing.Font("新細明體", 9F);
            this.btnDetect.Location = new System.Drawing.Point(185, 15);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(161, 58);
            this.btnDetect.TabIndex = 1;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("新細明體", 20F);
            this.labelSpeed.Location = new System.Drawing.Point(567, 23);
            this.labelSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(111, 34);
            this.labelSpeed.TabIndex = 2;
            this.labelSpeed.Text = "Speed: ";
            // 
            // openFile
            // 
            this.openFile.Font = new System.Drawing.Font("新細明體", 9F);
            this.openFile.Location = new System.Drawing.Point(16, 15);
            this.openFile.Margin = new System.Windows.Forms.Padding(4);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(161, 58);
            this.openFile.TabIndex = 3;
            this.openFile.Text = "Open Folder";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(16, 80);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(548, 424);
            this.listBox1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Value_In
            // 
            this.Value_In.Location = new System.Drawing.Point(969, 12);
            this.Value_In.Name = "Value_In";
            this.Value_In.Size = new System.Drawing.Size(166, 25);
            this.Value_In.TabIndex = 5;
            this.Value_In.Text = "930000";
            // 
            // Value_Out
            // 
            this.Value_Out.Location = new System.Drawing.Point(969, 48);
            this.Value_Out.Name = "Value_Out";
            this.Value_Out.Size = new System.Drawing.Size(166, 25);
            this.Value_Out.TabIndex = 6;
            this.Value_Out.Text = "576793";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(876, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "臨界值(In):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(876, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "臨界值(Out):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 530);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Value_Out);
            this.Controls.Add(this.Value_In);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.pbimg);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Vehicle Speed Measurement";
            ((System.ComponentModel.ISupportInitialize)(this.pbimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbimg;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox Value_In;
        private System.Windows.Forms.TextBox Value_Out;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

