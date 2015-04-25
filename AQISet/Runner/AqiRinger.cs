using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Media;
using System.Windows.Forms;
namespace AQISet.Runner
{
    /// <summary>
    /// 提醒者
    /// </summary>
    public sealed class AqiRinger
    {
        [DllImport("Kernel32.dll")] //引入命名空间 using System.Runtime.InteropServices;  
        public static extern bool Beep(int frequency, int duration);


        private string name;
        private AqiManage am;

        public AqiRinger(AqiManage manage)
        {
            name = "DefaultRinger";
            this.am = manage;
        }

        /// <summary>
        /// 提醒
        /// </summary>
        public void Ring()
        {
            bool useBeep = true;
            bool useEmail = true;
            bool useMessage = true;

            if(useBeep)
            {
                Beep();
            }

        }

        private void Beep()
        {
            //Beep(500, 700); // 这个声音还不错
            //SystemSounds.Beep.Play();
            SystemSounds.Question.Play();
        }

        private void Email()
        {

        }

        private void Message(string name)
        {
            MessageBox.Show(name);
        }
    }
}
