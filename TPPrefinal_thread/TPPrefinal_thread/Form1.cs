using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPPrefinal_thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            lbThread.Text = "-Thread Start-";

            Thread threadA = new Thread(MyThreadClass.Thread1) { Name = "Thread A", Priority = ThreadPriority.Highest };
            Thread threadB = new Thread(MyThreadClass.Thread2) { Name = "Thread B", Priority = ThreadPriority.Normal };
            Thread threadC = new Thread(MyThreadClass.Thread1) { Name = "Thread C", Priority = ThreadPriority.AboveNormal };
            Thread threadD = new Thread(MyThreadClass.Thread2) { Name = "Thread D", Priority = ThreadPriority.BelowNormal };

            // Start threads
            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            // Run a background task to monitor threads and update UI
            Task.Run(() =>
            {
                threadA.Join();
                threadB.Join();
                threadC.Join();
                threadD.Join();

                // Safely update UI
                UpdateLabel("-End of Thread-");
            });
        }

        private void UpdateLabel(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lbThread.Text = message));
            }
            else
            {
                lbThread.Text = message;
            }
        }
    }
}



