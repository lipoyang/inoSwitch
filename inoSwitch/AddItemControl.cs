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
    public partial class AddItemControl : UserControl
    {
        // IDE追加時のイベント
        public event IdeAddEvent onAdd;

        public AddItemControl()
        {
            InitializeComponent();
        }

        // 参照ボタン追加
        private void buttonRefer_Click(object sender, EventArgs e)
        {
            // ファイルを開くのダイアログ
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめに表示されるファイル名とフォルダ
            //ofd.FileName = "default.file";
            //ofd.InitialDirectory = @"C:\";
            ofd.InitialDirectory = Environment.GetEnvironmentVariable("HOMEDRIVE");
            //[ファイルの種類]
            ofd.Filter = "実行ファイル(*.exe)|*.exe|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1; // 1番目のフィルタを最初に選択
            //タイトル
            ofd.Title = "IDEの実行ファイルを選択してください";
            //ダイアログを閉じるときに現在のディレクトリを復元するか
            ofd.RestoreDirectory = true;
            //存在しないファイルやパスが指定されたとき警告を表示するか
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // 新しいIDE情報を作成
                createIdeInfo(ofd.FileName);
            }

        }

        // ドラッグされたとき
        private void AddItemControl_DragEnter(object sender, DragEventArgs e)
        {
            // ファイルのみ受け付ける
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                BackColor = Color.White; // 背景色を変化
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        // ドロップされたとき
        private void AddItemControl_DragDrop(object sender, DragEventArgs e)
        {
            // ファイル名を取得する
            string[] fileName =
                (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // 新しいIDE情報を作成
            createIdeInfo(fileName[0]);

            BackColor = SystemColors.Control; // 背景色を戻す
        }

        // ドラッグが外れたとき
        private void AddItemControl_DragLeave(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control; // 背景色を戻す
        }

        // IDE情報を作成する
        void createIdeInfo(string path)
        {
            IdeInfo info = new IdeInfo();

            // IDE情報入力画面を表示
            InputForm inputForm = new InputForm(path);
            inputForm.ShowDialog(this);
            if (inputForm.Info != null)
            {
                // IDE追加時のイベント発行
                IdeAddEventArgs args = new IdeAddEventArgs();
                args.ideInfo = inputForm.Info;
                onAdd(this, args);
            }
        }
    }

    // IDE追加時のイベント
    public class IdeAddEventArgs : EventArgs
    {
        public IdeInfo ideInfo;
    }
    public delegate void IdeAddEvent(object sender, IdeAddEventArgs e);

}
