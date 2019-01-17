namespace inoSwitch
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelIDE = new System.Windows.Forms.Label();
            this.radioArduino = new System.Windows.Forms.RadioButton();
            this.radioGR = new System.Windows.Forms.RadioButton();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureIcon
            // 
            this.pictureIcon.Location = new System.Drawing.Point(250, 12);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(128, 128);
            this.pictureIcon.TabIndex = 0;
            this.pictureIcon.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.buttonOK.Location = new System.Drawing.Point(26, 216);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 26);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.buttonCancel.Location = new System.Drawing.Point(133, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 26);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelName.Location = new System.Drawing.Point(23, 29);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(126, 15);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "名前をつけてください";
            // 
            // labelIDE
            // 
            this.labelIDE.AutoSize = true;
            this.labelIDE.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.labelIDE.Location = new System.Drawing.Point(23, 88);
            this.labelIDE.Name = "labelIDE";
            this.labelIDE.Size = new System.Drawing.Size(71, 15);
            this.labelIDE.TabIndex = 4;
            this.labelIDE.Text = "IDEの種類";
            // 
            // radioArduino
            // 
            this.radioArduino.AutoSize = true;
            this.radioArduino.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.radioArduino.Location = new System.Drawing.Point(26, 108);
            this.radioArduino.Name = "radioArduino";
            this.radioArduino.Size = new System.Drawing.Size(73, 19);
            this.radioArduino.TabIndex = 5;
            this.radioArduino.TabStop = true;
            this.radioArduino.Text = "Arduino";
            this.radioArduino.UseVisualStyleBackColor = true;
            // 
            // radioGR
            // 
            this.radioGR.AutoSize = true;
            this.radioGR.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.radioGR.Location = new System.Drawing.Point(123, 108);
            this.radioGR.Name = "radioGR";
            this.radioGR.Size = new System.Drawing.Size(94, 19);
            this.radioGR.TabIndex = 6;
            this.radioGR.TabStop = true;
            this.radioGR.Text = "IDE for GR";
            this.radioGR.UseVisualStyleBackColor = true;
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.textName.Location = new System.Drawing.Point(26, 50);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(182, 22);
            this.textName.TabIndex = 7;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.labelPath.Location = new System.Drawing.Point(23, 142);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(37, 15);
            this.labelPath.TabIndex = 8;
            this.labelPath.Text = "場所";
            // 
            // textPath
            // 
            this.textPath.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.textPath.Location = new System.Drawing.Point(26, 163);
            this.textPath.Name = "textPath";
            this.textPath.ReadOnly = true;
            this.textPath.Size = new System.Drawing.Size(368, 19);
            this.textPath.TabIndex = 9;
            this.textPath.TabStop = false;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 261);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.radioGR);
            this.Controls.Add(this.radioArduino);
            this.Controls.Add(this.labelIDE);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.pictureIcon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputForm";
            this.Text = "IDE情報の入力";
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelIDE;
        private System.Windows.Forms.RadioButton radioArduino;
        private System.Windows.Forms.RadioButton radioGR;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textPath;
    }
}