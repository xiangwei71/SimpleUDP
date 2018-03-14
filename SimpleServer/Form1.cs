using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Library;

namespace SimpleServer
{
    public partial class Form1 : Form
    {
        int listenPort = 5555;
        UDPHandle uDPHandle;

        public Form1()
        {
            InitializeComponent();

            Closing += (sender,e)=> {
                if (uDPHandle!=null) uDPHandle.Quit();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
            listen_btn.Enabled = false;
            quit_btn.Enabled = true;
        }

        void Init()
        {
            initClientDictionary();

            uDPHandle = new UDPHandle(listenPort)
            {
                packHandler = (commandType, content) =>
                {
                    switch (commandType)
                    {
                        case ServerCommandType.add_user:

                            string key = content;
                            string[] item = CommandHelper.GetItems(content);
                            string ip = item[0];
                            int listenPort = int.Parse(item[1]);

                            Console.WriteLine(key);
                            if (!clientDictionary.ContainsKey(key))
                                clientDictionary.Add(key, new IPEndPoint(IPAddress.Parse(ip), listenPort));

                            break;
                        case ServerCommandType.say:
                            SendToAll(content);
                            UpdateListView(content);
                            break;
                    }
                }
            };
            uDPHandle.StartReciver();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (uDPHandle != null)
            {
                uDPHandle.Quit();
                uDPHandle = null;
            }

            listen_btn.Enabled = true;
            quit_btn.Enabled = false;
        }

        Dictionary<String, IPEndPoint> clientDictionary;
        void initClientDictionary()
        {
            clientDictionary = new Dictionary<String, IPEndPoint>();
        }

        void SendToAll(string word)
        {
            string pack = CommandHelper.MakePackGet(word);
            byte[] data = Encoding.UTF8.GetBytes(pack);

            foreach (var ep in clientDictionary.Values)
            {
                UdpClient sender = uDPHandle.Get();
                sender.BeginSend(data, data.Length, ep, (ar)=> { }, sender);
            }
        }

        void UpdateListView(string word)
        {
            this.BeginInvoke(new Action(() => {
                word_listbox.Items.Add(word);
            }), null);
        }     
    }
}
