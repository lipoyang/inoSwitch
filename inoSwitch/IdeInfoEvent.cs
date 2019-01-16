using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inoSwitch
{
    // IDE選択・編集・削除・追加時のイベント

    public class IdeInfoEventArgs : EventArgs
    {
        public IdeInfo ideInfo;
        public IdeInfoEventArgs(IdeInfo info)
        {
            ideInfo = info;
        }
    }

    public delegate void IdeInfoEvent(object sender, IdeInfoEventArgs e);
}
