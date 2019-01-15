namespace inoSwitch
{
    partial class IdeItemControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelIdePath = new System.Windows.Forms.Label();
            this.labelIdeName = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonIde = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIdePath
            // 
            this.labelIdePath.AutoSize = true;
            this.labelIdePath.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelIdePath.Location = new System.Drawing.Point(129, 53);
            this.labelIdePath.Name = "labelIdePath";
            this.labelIdePath.Size = new System.Drawing.Size(63, 15);
            this.labelIdePath.TabIndex = 5;
            this.labelIdePath.Text = "IDE Path";
            // 
            // labelIdeName
            // 
            this.labelIdeName.AutoSize = true;
            this.labelIdeName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelIdeName.Location = new System.Drawing.Point(129, 18);
            this.labelIdeName.Name = "labelIdeName";
            this.labelIdeName.Size = new System.Drawing.Size(82, 16);
            this.labelIdeName.TabIndex = 4;
            this.labelIdeName.Text = "IDE Name";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRemove.Location = new System.Drawing.Point(495, 65);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(96, 26);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.TabStop = false;
            this.buttonRemove.Text = "削除";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonIde
            // 
            this.buttonIde.Location = new System.Drawing.Point(13, 13);
            this.buttonIde.Name = "buttonIde";
            this.buttonIde.Size = new System.Drawing.Size(70, 70);
            this.buttonIde.TabIndex = 0;
            this.buttonIde.UseVisualStyleBackColor = true;
            this.buttonIde.Click += new System.EventHandler(this.buttonIde_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonEdit.Location = new System.Drawing.Point(495, 33);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(96, 26);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.TabStop = false;
            this.buttonEdit.Text = "編集";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // IdeItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonIde);
            this.Controls.Add(this.labelIdePath);
            this.Controls.Add(this.labelIdeName);
            this.Controls.Add(this.buttonRemove);
            this.Name = "IdeItemControl";
            this.Size = new System.Drawing.Size(598, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIdePath;
        private System.Windows.Forms.Label labelIdeName;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonIde;
        private System.Windows.Forms.Button buttonEdit;
    }
}
