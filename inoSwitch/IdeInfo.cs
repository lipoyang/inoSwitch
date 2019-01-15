using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inoSwitch
{
    // IDEの情報
    public class IdeInfo
    {
        public string Name; // IDEの名前(任意の名前)
        public string Path; // IDEの実行ファイルのパス
        public IdeType Type; // IDEの種類
    }

    // IDEの種類
    public enum IdeType
    {
        ARDUINO = 0,    // 本家 Arduino IDE
        IDE4GR = 1     // がじぇるね IDE for GR
    }
}
