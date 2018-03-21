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
using SimpleUDP;

namespace SimpleClient
{
    public partial class Form1 : Form
    {
        string serverIP = "127.0.0.1";
        int serverListenPort = 5555;
        UDPHandle udpHandle;
        public Form1()
        {
            InitializeComponent();

            Closing += (sender, e) => {
                Quit();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
            SendAddUser();
            userid_text.Enabled = false;
            listen_btn.Enabled = false;
            quit_btn.Enabled = true;
            send_btn.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Quit();

            userid_text.Enabled = true;
            listen_btn.Enabled = true;
            quit_btn.Enabled = false;
            send_btn.Enabled = false;
        }

        void Quit()
        {
            if (udpHandle != null)
            {
                SendRemoveUser();
                udpHandle.Quit();
                udpHandle = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendWord();
        }

        void Init()
        {
            udpHandle = new UDPHandle()
            {
                packHandler = (commandType, content, EP) =>
                {
                    switch (commandType)
                    {
                        case ClientCommandType.get:
                            UpdateListView(content);
                            break;
                    }
                }
            };
            udpHandle.StartReciver();
        }

        void UpdateListView(string word)
        {
            this.BeginInvoke(new Action(() => {
                word_listbox.Items.Add(word);
            }), null);
        }

        void SendAddUser()
        {
            string userid = userid_text.Text;
            string pack = CommandHelper.MakePackAddUser(userid);
            Send(pack);
        }

        void SendRemoveUser()
        {
            string userid = userid_text.Text;
            string pack = CommandHelper.MakePackRemoveUser(userid);
            Send(pack);
        }

        void SendWord()
        {
            string word = word_text.Text;
            string userid = userid_text.Text;
            string content = userid + ":" + word;
            string pack = CommandHelper.MakePackSay(content);
            Send(pack);
        }

        void Send(string pack)
        {
            if (udpHandle == null)
                return;

            debug_label.Text = pack;
            byte[] data = Encoding.UTF8.GetBytes(pack);

            UdpClient sender = udpHandle.Get();
            sender.BeginSend(data, data.Length, serverIP, serverListenPort, null, sender);
        }
    }
}
