using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inoSwitch
{
    public partial class IdeItemControl : UserControl
    {
        // IDE情報
        IdeInfo m_ideInfo;

        // IDE選択時のイベント
        public event IdeInfoEvent onSelect;
        // IDE情報編集時のイベント
        public event IdeInfoEvent onEdit;
        // IDE情報削除時のイベント
        public event IdeInfoEvent onRemove;
        
        // IDEを選択可能か
        public bool Selectable
        {
            set { buttonIde.Enabled = value; }
            get { return buttonIde.Enabled; }
        }

        public IdeItemControl()
        {
            InitializeComponent();
        }
        public IdeItemControl(IdeInfo ide)
        {
            InitializeComponent();

            m_ideInfo = ide;

            // IDEの名前
            labelIdeName.Text = ide.Name;
            // IDEのパス
            labelIdePath.Text = ide.Path;

            // アイコン画像の取得
            Icon ico;
            try{
                ico = Icon.ExtractAssociatedIcon(ide.Path);
            }catch{
                ico = SystemIcons.Application; // 取得できないとき
            }
            Bitmap resizeBmp = new Bitmap(70, 70);
            Graphics g = Graphics.FromImage(resizeBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(ico.ToBitmap(), 3, 3, 64, 64);
            g.Dispose();
            buttonIde.BackgroundImage = resizeBmp;
        }

        // IDE(選択)ボタン
        private void buttonIde_Click(object sender, EventArgs e)
        {
            var args = new IdeInfoEventArgs(m_ideInfo);
            onSelect(this, args);
        }

        // 編集ボタン
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // IDE情報入力画面を表示
            InputForm inputForm = new InputForm(m_ideInfo);
            inputForm.ShowDialog(this);

            var args = new IdeInfoEventArgs(m_ideInfo);
            onEdit(this, args);
        }

        // 削除ボタン
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var args = new IdeInfoEventArgs(m_ideInfo);
            onRemove(this, args);
        }
    }
}
