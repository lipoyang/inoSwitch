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

namespace inoSwitch
{
    public partial class ManagerForm : Form
    {
        // 選択されたIDE
        public IdeInfo SelectedIde = null;

        // IDEを選択(起動できるか)
        bool m_selectable;
        // IDEリスト
        List<IdeInfo> m_ideList;
        // IDE追加欄
        AddItemControl m_addItemControl = new AddItemControl();

        // selectable: IDEを選択して実行できるか？
        public ManagerForm(bool selectable)
        {
            InitializeComponent();

            m_selectable = selectable;
        }

        // フォーム読み込み時
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // 設定ファイルからIDEリストの読み出し
            loadIdeList();
            // IDEリスト表示
            viewList();
            // IDE追加欄のイベントハンドラ設定
            m_addItemControl.onAdd += onAdd;

            // ウィンドウのキャプション
            this.Text = (m_selectable) ? "IDEの選択" : "IDEの管理";
        }

        // IDEが選択されたとき
        private void onSelect(object sender, IdeInfoEventArgs e)
        {
            // 選択されたIDE
            SelectedIde = e.ideInfo;
            // フォームを閉じる
            this.Close();
        }

        // IDE情報が編集されたとき
        private void onEdit(object sender, IdeInfoEventArgs e)
        {
            // リストをソート
            m_ideList.Sort((a, b) => a.Name.CompareTo(b.Name));
            // 設定ファイルに保存
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
            // 設定ファイルに保存
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
            // 設定ファイルに保存
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
                item.Selectable = m_selectable;
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

        // 設定ファイルに保存
        private void saveIdeList()
        {
            try{
                // 設定ファイル名 (C:\Users\UserName\AppData\Local\inoSwitch\setting.txt)
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
                MessageBox.Show("設定ファイルの保存に失敗しました。", "エラー");
            }
        }
        // 設定ファイルから読み込み
        private void loadIdeList()
        {
            try{
                // 設定ファイル名 (C:\Users\UserName\AppData\Local\inoSwitch\setting.txt)
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
                    // 設定ファイルがないなら空のリスト
                    m_ideList = new List<IdeInfo>();
                }
            }catch{
                MessageBox.Show("設定ファイルの読み込みに失敗しました。", "エラー");
            }
        }
    }
}
