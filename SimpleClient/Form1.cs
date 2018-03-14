using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Library;

namespace SimpleClient
{
    public partial class Form1 : Form
    {
        string serverIP = "127.0.0.1";
        int serverListenPort = 5555;
        int listenPort;
        UDPHandle uDPHandle;
        public Form1()
        {
            InitializeComponent();

            Closing += (sender, e) => {
                if (uDPHandle != null) uDPHandle.Quit();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
            SendAddUser();
        }

        void SendAddUser()
        {
            string ip = GetLocalIP();
            string port = listenPort.ToString();
            string pack = CommandHelper.MakePackAddUser(ip, port);
            Send(pack);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uDPHandle.Quit();
            uDPHandle = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendWord();
        }

        void SendWord()
        {
            string word = word_text.Text;
            string userid = userid_text.Text;
            string content = userid + ":" + word;
            string pack = CommandHelper.MakePackSay(content);
            Send(pack);
        }

        string GetLocalIP()
        {
            String strHostName = Dns.GetHostName();

            // 取得本機的 IpHostEntry 類別實體
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);


            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                // 只取得IP V4的Address
                if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ipaddress.ToString();
                }
            }

            return "127.0.0.1";
        }

        void Send(string pack)
        {
            debug_label.Text = pack;
            byte[] data = Encoding.UTF8.GetBytes(pack);

            UdpClient sender = new UdpClient();
            sender.Connect(serverIP, serverListenPort);
            sender.Send(data, data.Length);
            sender.Close();
        }

        void Init()
        {
            listenPort = int.Parse(listenport_text.Text);
            uDPHandle = new UDPHandle(listenPort)
            {
                msgHandler = (commandType, content) =>
                {
                    switch (commandType)
                    {
                        case ClientCommandType.get:
                            UpdateListView(content);
                            break;
                    }
                }
            };
            uDPHandle.StartReciver();
        }

        void UpdateListView(string word)
        {
            this.BeginInvoke(new Action(() => {
                word_listbox.Items.Add(word);
            }), null);
        }

        
    }
}
