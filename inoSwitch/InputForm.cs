using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inoSwitch
{
    public partial class InputForm : Form
    {
        public IdeInfo Info;

        // 追加の場合
        public InputForm(string path)
        {
            InitializeComponent();

            Info = new IdeInfo();

            // パス
            textPath.Text = path;

            // 名前と種別
            string filename = System.IO.Path.GetFileNameWithoutExtension(path);
            if(filename.ToLower().Equals("arduino"))
            {
                // Arduinoの場合
                textName.Text = "Arduino";
                radioArduino.Select();
            }
            else if (filename.ToLower().Equals("ide4gr"))
            {
                // IDE for GRの場合
                textName.Text = "IDE for GR";
                radioGR.Select();
            }
            else
            {
                // 不明なIDEの場合
                textName.Text = filename;
                radioArduino.Select();
            }

            // アイコン画像の取得
            getIcon(path);
        }

        // 編集の場合
        public InputForm(IdeInfo info)
        {
            InitializeComponent();

            Info = info;

            // パス
            textPath.Text = info.Path;
            // 名前
            textName.Text = info.Name;
            // 種別
            switch(info.Type)
            {
                case IdeType.ARDUINO:
                    radioArduino.Select();
                    break;
                case IdeType.IDE4GR:
                    radioGR.Select();
                    break;
                default:
                    radioArduino.Select();
                    break;
            }

            // アイコン画像の取得
            getIcon(info.Path);
        }

        // アイコン画像の取得
        private void getIcon(string path)
        {
            Icon ico;
            try{
                ico = Icon.ExtractAssociatedIcon(path);
            }catch{
                ico = SystemIcons.Application; // 取得できないとき
            }
            Bitmap resizeBmp = new Bitmap(128, 128);
            Graphics g = Graphics.FromImage(resizeBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(ico.ToBitmap(), 0, 0, 128, 128);
            g.Dispose();
            pictureIcon.Image = resizeBmp;
        }

        // OKボタン
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Info.Name = textName.Text;
            Info.Path = textPath.Text;
            if (radioGR.Checked)
            {
                Info.Type = IdeType.ARDUINO;
            }
            else if(radioGR.Checked)
            {
                Info.Type = IdeType.IDE4GR;
            }
            else
            {
                Info.Type = IdeType.ARDUINO;
            }
            this.Close();
        }

        // キャンセルボタン
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Info = null;
            this.Close();
        }
    }
}
