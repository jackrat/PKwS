using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkStreamingClientApp
{
  class log
  {
    public static void Init(TextBox aTextBox)
    {
      ilog = new log(aTextBox);
    }
    TextBox tb;
    private log(TextBox aTextBox)
    {
      tb = aTextBox;
    }
    private static log ilog;

    public static void WriteLine(string s)
    {
      
      ilog.tb.Invoke(new Action(() => { ilog.tb.AppendText(s + "\r\n"); }));
    }

    public static void WriteLine(string fs, string s)
    {
      ilog.tb.Invoke(new Action(()=> { ilog.tb.AppendText(string.Format(fs, s) + "\r\n"); }));
      
    }
  }
}
