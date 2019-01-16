using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace inoSwitch
{
    // メインフォーム
    public partial class MainForm : Form
    {
        // 強制終了フラグ
        private bool m_forceClose = false;
        // inoファイルのパス
        private string m_inoPath = "";
        // IDE情報
        IdeInfo m_ideInfo;

        public MainForm()
        {
            InitializeComponent();
        }

        // 起動時
        private void FormMain_Load(object sender, EventArgs e)
        {
            // コマンド引数をチェックする
            checkArgs();

            // 引数がないとき(inoファイルを開かないとき)
            if(m_inoPath.Equals("")){
                // inoファイルが関連付けられていないなら関連付ける
                if (checkAssociation() == false)
                {
                    // 関連付けの可否を確認
                    if (MessageBox.Show(
                        "関連づけますか？", "確認",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question
                        ) == DialogResult.No)
                    {
                        MessageBox.Show("さようなら。", "終了");

                        m_forceClose = true;
                        this.Close();
                        return;
                    }
                    // inoファイルの関連付け
                    if( associateIno() == false)
                    {
                        MessageBox.Show("関連付けに失敗しました。", "エラー");
                    }
                }
                // IDEマネージャ画面を表示 (IDE起動不可)
                ManagerForm form = new ManagerForm(false);
                form.ShowDialog(this);

                // 終了
                m_forceClose = true;
                this.Close();
            }
            // inoファイルを開くとき
            else
            {
                // 設定ファイルがあるか？
                bool opened = false;
                string setting = Path.GetDirectoryName(m_inoPath) + @"\inoSwitch.txt";
                if (File.Exists(setting)){
                    // 設定ファイルを読み込んでIDEを起動
                    if (loadSetting(setting)){
                        copyPreferences();
                        opened = startIde();
                    }
                }
                // IDEを起動しなかった場合
                if(!opened){
                    // IDEマネージャ画面を表示 (IDE起動可)
                    ManagerForm form = new ManagerForm(true);
                    form.ShowDialog(this);
                    // 選択されたIDEで起動
                    m_ideInfo = form.SelectedIde;
                    if(m_ideInfo != null){
                        copyPreferences();
                        opened = startIde();
                    }
                }
                // それでもIDE起動しなかった場合は終了
                if (!opened){
                    m_forceClose = true;
                    this.Close();
                }
                // 設定ファイルに保存
                saveSetting(setting);

                // スケッチ名
                textSketch.Text = m_inoPath;
                // IDE名
                textIde.Text = m_ideInfo.Name;
                // アイコン
                Icon ico;
                try{
                    ico = Icon.ExtractAssociatedIcon(m_ideInfo.Path);
                }catch{
                    ico = SystemIcons.Application; // 取得できないとき
                }
                Bitmap resizeBmp = new Bitmap(128, 128);
                Graphics g = Graphics.FromImage(resizeBmp);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(ico.ToBitmap(), 0, 0, 128, 128);
                g.Dispose();
                pictureIde.Image = resizeBmp;
            }
        }

        // Arduino IDEの設定ファイル(preferences.txt)のコピー
        private void copyPreferences()
        {
            // コピー元
            string src = Path.GetDirectoryName(m_inoPath) + @"\preferences.txt";

            // コピー先
            string dst;
            switch (m_ideInfo.Type)
            {
                case IdeType.ARDUINO:
                    dst = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                        + @"\Arduino15\preferences.txt";
                    break;
                case IdeType.IDE4GR:
                    dst = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                        + @"\Arduino15\preferences.txt";
                    break;
                default:
                    dst = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                        + @"\Arduino15\preferences.txt";
                    break;
            }

            // ファイルが異なっていれば
            if (File.Exists(src) && !fileCompare(src, dst)){
                // コピーするか確認？
                if (MessageBox.Show(
                    "設定ファイルを上書きしますか？", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    // ファイルのコピー
                    try{
                        File.Copy(src, dst, true);
                    }catch{
                        MessageBox.Show("設定ファイルがコピーできませんでした", "エラー");
                    }
                }
            }
        }

        // IDEを起動
        private bool startIde()
        {
            try{
                var p = Process.Start(m_ideInfo.Path, "\"" + m_inoPath + "\"");
                return true;
            }catch{
                MessageBox.Show("IDEの起動に失敗しました", "エラー");
                return false;
            }
        }

        // ファイルの比較
        private bool fileCompare(string file1, string file2)
        {
            if (file1 == file2)
                return true;

            FileStream fs1 = new FileStream(file1, FileMode.Open);
            FileStream fs2 = new FileStream(file2, FileMode.Open);
            int byte1;
            int byte2;
            bool ret = false;

            try{
                if (fs1.Length == fs2.Length){
                    do{
                        byte1 = fs1.ReadByte();
                        byte2 = fs2.ReadByte();
                    }while ((byte1 == byte2) && (byte1 != -1));

                    if (byte1 == byte2)
                        ret = true;
                }
            }catch{
            }finally{
                fs1.Close();
                fs2.Close();
            }
            return ret;
        }

        // 設定ファイルの読み込み
        private bool loadSetting(string path)
        {
            try
            {
                // IDE情報をデシリアライズして読み込み
                var serializer = new XmlSerializer(typeof(IdeInfo));
                var sr = new StreamReader(path, new UTF8Encoding(false));
                m_ideInfo = (IdeInfo)serializer.Deserialize(sr);
                sr.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("設定ファイルの読み込みに失敗しました。", "エラー");
                return false;
            }
        }

        // 設定ファイルの保存
        private void saveSetting(string path)
        {
            try
            {
                // IDE情報をシリアライズして保存
                var serializer = new XmlSerializer(typeof(IdeInfo));
                var sw = new StreamWriter(path, false, new UTF8Encoding(false));
                serializer.Serialize(sw, m_ideInfo);
                sw.Close();
            }
            catch
            {
                MessageBox.Show("設定ファイルの保存に失敗しました。", "エラー");
            }

        }

        // 終了時
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_forceClose)
            {
                // TODO 起動中のIDEがあるか？

                // 終了確認 
                if (MessageBox.Show(
                    "終了してもいいですか？", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    ) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        // コマンド引数のチェック
        private void checkArgs()
        {
            string[] cmds = System.Environment.GetCommandLineArgs();
            if (cmds.Length >= 2)
            {
                m_inoPath = cmds[1];
            }
        }

        // inoファイルとの関連付け確認
        private bool checkAssociation()
        {
            // 拡張子
            string extension = ".ino";
            // ファイルタイプ
            string fileType = Application.ProductName + ".0";
            // 実行するコマンドライン
            string commandline = "\"" + Application.ExecutablePath + "\" \"%1\"";
            // 動詞
            string verb = "open";

            // レジストリ
            Microsoft.Win32.RegistryKey rootkey =
                Microsoft.Win32.Registry.ClassesRoot;

            try {
                // 拡張子の確認
                Microsoft.Win32.RegistryKey regkey =
                    rootkey.OpenSubKey(extension);
                string val = (string)regkey.GetValue("");
                if (!val.Equals(fileType)) return false;
                regkey.Close();

                // 関連付け確認
                Microsoft.Win32.RegistryKey cmdkey =
                    rootkey.OpenSubKey(fileType + "\\shell\\" + verb + "\\command");
                val = (string)cmdkey.GetValue("");
                if (!val.Equals(commandline)) return false;
                cmdkey.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        // inoファイルを関連付ける
        private bool associateIno()
        {
            // 管理者権限が必要なので別プログラムを管理者として起動して処理する

            // 関連付けプログラム(コンソールアプリ)のパス
            string path = "inoAssociate";
            string arguments = ""; // 引数は無し
            Form parentForm = this; // 親フォームは自分

            // プログラムがあるかチェック
            if (!System.IO.File.Exists(path)){
                MessageBox.Show("inoAssociateファイルがありません", "エラー");
                return false;
            }

            // 起動するプロセスの設定
            var psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = path;
            psi.Verb = "runas"; // 管理者として実行
            psi.Arguments = arguments;

            // UACダイアログが親プログラム(自分)に対して表示されるようにする
            psi.ErrorDialog = true;
            psi.ErrorDialogParentHandle = parentForm.Handle;

            try{
                // 起動して終了まで待機
                var p = Process.Start(psi);
                p.WaitForExit();
            }catch{
                // 管理者権限のキャンセルされるなどで起動できなかった時
                return false;
            }
            return true;
        }

        // 保存ボタン
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // ArduinoIDEの設定ファイル(preferences.txt)のバックアップ

            // 保存元
            string src;
            switch (m_ideInfo.Type)
            {
                case IdeType.ARDUINO:
                    src = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                        + @"\Arduino15\preferences.txt";
                    break;
                case IdeType.IDE4GR:
                    src = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                        + @"\Arduino15\preferences.txt";
                    break;
                default:
                    src = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                        + @"\Arduino15\preferences.txt";
                    break;
            }
            
            // 保存先
            string dst = Path.GetDirectoryName(m_inoPath) + @"\preferences.txt";

            // ファイルのコピー
            try{
                File.Copy(src, dst, true);
            }catch{
                MessageBox.Show("設定ファイルが保存できませんでした", "エラー");
            }
        }
    }
}
