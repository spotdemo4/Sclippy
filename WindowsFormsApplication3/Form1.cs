using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3 {
    public partial class Form1 : Form {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string sClassName, String sAppName);
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        public int ayylmao = 0;
        public int attlmao = 0;
        string rumorticksit = "";
        string otherrumor = "";

        public Form1() {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m) {
            if(m.Msg == 0x0312) {
                int id = m.WParam.ToInt32();
                if(id == 1) {
                    label1.Text = listBox1.GetItemText(listBox1.Items[attlmao]);
                    listBox1.SelectedIndex = attlmao;
                    this.WindowState = FormWindowState.Minimized;
                    this.WindowState = FormWindowState.Maximized;
                    if (ayylmao == 0) {
                        label1.Visible = true;
                        ayylmao = 1;
                    }
                    else {
                        label1.Visible = false;
                        ayylmao = 0;
                    }
                }
                else if (id == 2 && ayylmao == 1) {
                    try {
                        attlmao = attlmao - 1;
                        label1.Text = listBox1.GetItemText(listBox1.Items[attlmao]);
                        listBox1.SelectedIndex = attlmao;
                    } catch(Exception e) {
                        attlmao = attlmao + 1;
                    }
                }
                else if (id == 3 && ayylmao == 1) {
                    try {
                        attlmao = attlmao + 1;
                        label1.Text = listBox1.GetItemText(listBox1.Items[attlmao]);
                        listBox1.SelectedIndex = attlmao;
                    }
                    catch (Exception e) {
                        attlmao = attlmao - 1;
                    }
                }
                else if (id == 4 && ayylmao == 1) {
                    Clipboard.SetText(listBox1.GetItemText(listBox1.Items[attlmao]));
                }
            }
            base.WndProc(ref m);
        }

        public enum fsModifiers {
            Alt = 0x0001,
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.ShowInTaskbar = false;
            IntPtr thisWindow = FindWindow(null, "Form1");
            RegisterHotKey(thisWindow, 1, (uint)fsModifiers.Alt, (uint)Keys.G);
            RegisterHotKey(thisWindow, 2, (uint)fsModifiers.Alt, (uint)Keys.Right);
            RegisterHotKey(thisWindow, 3, (uint)fsModifiers.Alt, (uint)Keys.Left);
            RegisterHotKey(thisWindow, 4, (uint)fsModifiers.Alt, (uint)Keys.Enter);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.TopMost = true;
            label1.ForeColor = Color.White;
            Thread thread = new Thread(dodadoo);
            thread.Start();
            label1.Visible = false;
        }
        public Color lerpedColor = Color.White;

        public void dodadoo() {
            while (true) {
                for (int i = 255; i >= 0; i--) {
                    label1.ForeColor = Color.FromArgb(i, 255, 255);
                    System.Threading.Thread.Sleep(5);
                }
                for(int i = 0; i < 255; i++) {
                    label1.ForeColor = Color.FromArgb(i, 255, 255);
                    System.Threading.Thread.Sleep(5);
                }
                //for (int i = 0; i < 255; i++) {
                //    label1.ForeColor = Color.FromArgb(255, i, 0);
                //    System.Threading.Thread.Sleep(5);
                //}
                //for (int i = 0; i < 255; i++) {
                //    label1.ForeColor = Color.FromArgb(255, 255, i);
                //    System.Threading.Thread.Sleep(5);
                //}
                //for (int i = 255; i >= 0; i--) {
                //    label1.ForeColor = Color.FromArgb(i, 255, 255);
                //    System.Threading.Thread.Sleep(5);
                //}
                //for (int i = 255; i >= 0; i--) {
                //    label1.ForeColor = Color.FromArgb(0, i, 255);
                //    System.Threading.Thread.Sleep(5);
                //}
                //for (int i = 255; i >= 0; i--) {
                //    label1.ForeColor = Color.FromArgb(0, 0, i);
                //    System.Threading.Thread.Sleep(5);
                //}
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            IntPtr thisWindow = FindWindow(null, "Form1");
            UnregisterHotKey(thisWindow, 1);
            System.Environment.Exit(1);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            IntPtr thisWindow = FindWindow(null, "Form1");
            UnregisterHotKey(thisWindow, 1);
            System.Environment.Exit(1);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            otherrumor = rumorticksit;
            rumorticksit = Clipboard.GetText();
            if(rumorticksit.Replace(" ", "") == "") {
                return;
            }
            else if(otherrumor == rumorticksit) {} else {
                listBox1.Items.Insert(0, rumorticksit);
            }
        }
    }
}
