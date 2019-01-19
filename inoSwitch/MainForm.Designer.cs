namespace inoSwitch
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelSketch = new System.Windows.Forms.Label();
            this.labelIDE = new System.Windows.Forms.Label();
            this.textSketch = new System.Windows.Forms.TextBox();
            this.textIde = new System.Windows.Forms.TextBox();
            this.pictureIde = new System.Windows.Forms.PictureBox();
            this.labelAttention1 = new System.Windows.Forms.Label();
            this.labelAttention2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIde)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.buttonSave.Location = new System.Drawing.Point(27, 122);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 29);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "バックアップ";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelSketch
            // 
            this.labelSketch.AutoSize = true;
            this.labelSketch.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.labelSketch.Location = new System.Drawing.Point(24, 27);
            this.labelSketch.Name = "labelSketch";
            this.labelSketch.Size = new System.Drawing.Size(51, 15);
            this.labelSketch.TabIndex = 1;
            this.labelSketch.Text = "スケッチ";
            // 
            // labelIDE
            // 
            this.labelIDE.AutoSize = true;
            this.labelIDE.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.labelIDE.Location = new System.Drawing.Point(24, 63);
            this.labelIDE.Name = "labelIDE";
            this.labelIDE.Size = new System.Drawing.Size(29, 15);
            this.labelIDE.TabIndex = 2;
            this.labelIDE.Text = "IDE";
            // 
            // textSketch
            // 
            this.textSketch.Location = new System.Drawing.Point(93, 23);
            this.textSketch.Name = "textSketch";
            this.textSketch.ReadOnly = true;
            this.textSketch.Size = new System.Drawing.Size(360, 19);
            this.textSketch.TabIndex = 3;
            // 
            // textIde
            // 
            this.textIde.Location = new System.Drawing.Point(93, 63);
            this.textIde.Name = "textIde";
            this.textIde.ReadOnly = true;
            this.textIde.Size = new System.Drawing.Size(360, 19);
            this.textIde.TabIndex = 4;
            // 
            // pictureIde
            // 
            this.pictureIde.Location = new System.Drawing.Point(491, 23);
            this.pictureIde.Name = "pictureIde";
            this.pictureIde.Size = new System.Drawing.Size(128, 128);
            this.pictureIde.TabIndex = 5;
            this.pictureIde.TabStop = false;
            // 
            // labelAttention1
            // 
            this.labelAttention1.AutoSize = true;
            this.labelAttention1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.labelAttention1.Location = new System.Drawing.Point(164, 114);
            this.labelAttention1.Name = "labelAttention1";
            this.labelAttention1.Size = new System.Drawing.Size(197, 15);
            this.labelAttention1.TabIndex = 6;
            this.labelAttention1.Text = "環境設定のバックアップは必ず";
            // 
            // labelAttention2
            // 
            this.labelAttention2.AutoSize = true;
            this.labelAttention2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.labelAttention2.Location = new System.Drawing.Point(164, 136);
            this.labelAttention2.Name = "labelAttention2";
            this.labelAttention2.Size = new System.Drawing.Size(211, 15);
            this.labelAttention2.TabIndex = 7;
            this.labelAttention2.Text = "IDE終了後におこなってください。";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 169);
            this.Controls.Add(this.labelAttention2);
            this.Controls.Add(this.labelAttention1);
            this.Controls.Add(this.pictureIde);
            this.Controls.Add(this.textIde);
            this.Controls.Add(this.textSketch);
            this.Controls.Add(this.labelIDE);
            this.Controls.Add(this.labelSketch);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "環境設定のバックアップ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureIde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSketch;
        private System.Windows.Forms.Label labelIDE;
        private System.Windows.Forms.TextBox textSketch;
        private System.Windows.Forms.TextBox textIde;
        private System.Windows.Forms.PictureBox pictureIde;
        private System.Windows.Forms.Label labelAttention1;
        private System.Windows.Forms.Label labelAttention2;
    }
}

