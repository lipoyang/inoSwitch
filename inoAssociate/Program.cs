using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inoAssociate
{
    class Program
    {
        static void Main(string[] args)
        {
            string inoSwitchPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "inoSwitch.exe";

            // 拡張子
            string extension = ".ino";
            // ファイルタイプ
//          string fileType = Application.ProductName + ".0";
            string fileType = "inoSwitch" + ".0";
            string description = "Arduino sketch";
            // 実行するコマンドライン
//          string commandline = "\"" + Application.ExecutablePath + "\" \"%1\"";
            string commandline = "\"" + inoSwitchPath + "\" \"%1\"";
            // アイコン
//          string iconPath = Application.ExecutablePath;
            string iconPath = inoSwitchPath;
            int iconIndex = 0;
            // 動詞
            string verb = "open";
            // string verbDescription = "inoSwitchで開く(&O)";
            

            // レジストリ
            Microsoft.Win32.RegistryKey rootkey =
                Microsoft.Win32.Registry.ClassesRoot;

            try
            {
                // 拡張子の登録
                Microsoft.Win32.RegistryKey regkey =
                    rootkey.CreateSubKey(extension);
                regkey.SetValue("", fileType);
                regkey.Close();

                // ファイルタイプの登録
                Microsoft.Win32.RegistryKey typekey =
                    rootkey.CreateSubKey(fileType);
                typekey.SetValue("", description);
                typekey.Close();

                // 動詞の登録
                Microsoft.Win32.RegistryKey verblkey =
                    rootkey.CreateSubKey(fileType + "\\shell\\" + verb);
                //            verblkey.SetValue("", verbDescription);
                verblkey.Close();

                // コマンドの登録
                Microsoft.Win32.RegistryKey cmdkey =
                    rootkey.CreateSubKey(fileType + "\\shell\\" + verb + "\\command");
                cmdkey.SetValue("", commandline);
                cmdkey.Close();

                // アイコンの登録
                Microsoft.Win32.RegistryKey iconkey =
                    rootkey.CreateSubKey(fileType + "\\DefaultIcon");
                iconkey.SetValue("", iconPath + "," + iconIndex.ToString());
                iconkey.Close();
            }
            catch
            {
                // エラー終了
                Environment.Exit(-1);
            }
            
            // 正常終了
            Environment.Exit(0);
        }
    }
}
