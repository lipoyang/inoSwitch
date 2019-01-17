using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace inoSwitch
{
    public partial class ManagerForm : Form
    {
        // 選択されたIDE
        public IdeInfo SelectedIde = null;

        // inoファイルを開くか
        bool m_toOpenInoFile;
        // IDEリスト
        List<IdeInfo> m_ideList;
        // IDE追加欄
        AddItemControl m_addItemControl = new AddItemControl();

        // selectable: IDEを選択して実行できるか？
        public ManagerForm(bool open)
        {
            InitializeComponent();

            m_toOpenInoFile = open;
        }

        // フォーム読み込み時
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // IDE情報登録ファイルからIDEリストの読み出し
            loadIdeList();
            // IDEリスト表示
            viewList();
            // IDE追加欄のイベントハンドラ設定
            m_addItemControl.onAdd += onAdd;
        }

        // IDEが選択されたとき
        private void onSelect(object sender, IdeInfoEventArgs e)
        {
            // 選択されたIDE
            SelectedIde = e.ideInfo;

            // inoファイルを開くとき
            if (m_toOpenInoFile){
                // フォームを閉じる (親フォーム側でinoファイルを開く)
                this.Close();
            }
            // inoファイルを開かないとき
            else{
                // IDEを起動
                try{
                    var p = Process.Start(SelectedIde.Path);
                }catch{
                    MessageBox.Show("IDEが起動できませんでした", "エラー");
                }
            }
        }

        // IDE情報が編集されたとき
        private void onEdit(object sender, IdeInfoEventArgs e)
        {
            // リストをソート
            m_ideList.Sort((a, b) => a.Name.CompareTo(b.Name));
            // IDE情報登録ファイルに保存
            saveIdeList();
            // リスト表示の更新
            viewList();
        }

        // IDE情報が削除されたとき
        private void onRemove(object sender, IdeInfoEventArgs e)
        {
            // リストからIDEを削除
            m_ideList.Remove(e.ideInfo);
            // リストをソート
            m_ideList.Sort((a, b) => a.Name.CompareTo(b.Name));
            // IDE情報登録ファイルに保存
            saveIdeList();
            // リスト表示の更新
            viewList();
        }

        // IDE情報が追加された時
        private void onAdd(object sender, IdeInfoEventArgs e)
        {
            // リストにIDEを追加
            m_ideList.Add(e.ideInfo);
            // リストをソート
            m_ideList.Sort((a, b)=>a.Name.CompareTo(b.Name));
            // IDE情報登録ファイルに保存
            saveIdeList();
            // リスト表示の更新
            viewList();
        }

        // リストの表示
        private void viewList()
        {
            // 全てのコントロールをいったん削除
            this.Controls.Clear();

            // IDEリストの表示
            for (int i = 0; i < m_ideList.Count; i++)
            {
                IdeItemControl item = new IdeItemControl(m_ideList[i]);
                item.Location = new Point(10, 10 + i * 110);
                item.onSelect += onSelect;
                item.onEdit += onEdit;
                item.onRemove += onRemove;
                this.Controls.Add(item);
            }
            // IDE追加欄の表示
            m_addItemControl.Location = new Point(10, 10 + m_ideList.Count * 110);
            this.Controls.Add(m_addItemControl);
        }

        // IDE情報登録ファイルに保存
        private void saveIdeList()
        {
            try{
                // IDE情報登録ファイル名 (C:\Users\UserName\AppData\Local\inoSwitch\setting.txt)
                string path =
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                    + @"\inoSwitch";
                if (!Directory.Exists(path)){
                    Directory.CreateDirectory(path);
                }
                string fileName = path + @"\setting.txt";

                // IDEリストをシリアライズしてファイルを保存
                var serializer = new XmlSerializer(typeof(List<IdeInfo>));
                var sw = new StreamWriter(fileName, false, new UTF8Encoding(false));
                serializer.Serialize(sw, m_ideList);
                sw.Close();
            }catch{
                MessageBox.Show("IDE情報登録ファイルが保存できませんでした", "エラー");
            }
        }
        // IDE情報登録ファイルから読み込み
        private void loadIdeList()
        {
            try{
                // IDE情報登録ファイル名 (C:\Users\UserName\AppData\Local\inoSwitch\setting.txt)
                string path =
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                    + @"\inoSwitch";
                string fileName = path + @"\setting.txt";

                if (File.Exists(fileName)){
                    // ファイルからIDEリストをデシリアライズして読み込み
                    var serializer = new XmlSerializer(typeof(List<IdeInfo>));
                    var sr = new StreamReader(fileName, new UTF8Encoding(false));
                    m_ideList = (List<IdeInfo>)serializer.Deserialize(sr);
                    sr.Close();
                }else{
                    // IDE情報登録ファイルがないなら空のリスト
                    m_ideList = new List<IdeInfo>();
                }
            }catch{
                MessageBox.Show("IDE情報登録ファイルが読み込めませんでした", "エラー");
            }
        }
    }
}
