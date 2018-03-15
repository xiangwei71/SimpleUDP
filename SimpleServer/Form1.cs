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
        UDPHandle udpHandle;

        public Form1()
        {
            InitializeComponent();

            Closing += (sender,e)=> {
                Quit();
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

            udpHandle = new UDPHandle(listenPort)
            {
                packHandler = (commandType, content, EP) =>
                {
                    switch (commandType)
                    {
                        case ServerCommandType.add_user:
                            {
                                string userId = content;

                                string key = MakeKey(EP);
                                Console.WriteLine("add key=" + key);

                                if (!clientDictionary.ContainsKey(key))
                                    clientDictionary.Add(key, EP);
                            }
                            break;
                        case ServerCommandType.remove_user:
                            {
                                string userId = content;

                                string key = MakeKey(EP);
                                Console.WriteLine("remove key=" + key);

                                if (clientDictionary.ContainsKey(key))
                                    clientDictionary.Remove(key);
                            }
                            break;
                        case ServerCommandType.say:
                            SendToAll(content);
                            UpdateListView(content);
                            break;
                    }
                }
            };
            udpHandle.StartReciver();
        }

        string MakeKey(IPEndPoint EP)
        {
            string ip = EP.Address.ToString();
            int listenPort = EP.Port;
            string key = ip + ":" + listenPort.ToString();
            return key;
        }

        void Quit()
        {
            if (udpHandle != null)
            {
                udpHandle.Quit();
                udpHandle = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Quit();

            listen_btn.Enabled = true;
            quit_btn.Enabled = false;
        }

        Dictionary<String, IPEndPoint> clientDictionary;
        void initClientDictionary()
        {
            clientDictionary = new Dictionary<String, IPEndPoint>();
        }

        void UpdateListView(string word)
        {
            this.BeginInvoke(new Action(() => {
                word_listbox.Items.Add(word);
            }), null);
        }

        void SendToAll(string word)
        {
            string pack = CommandHelper.MakePackGet(word);
            byte[] data = Encoding.UTF8.GetBytes(pack);

            foreach (var ep in clientDictionary.Values)
            {
                UdpClient sender = udpHandle.Get();
                sender.BeginSend(data, data.Length, ep, (ar) => { }, sender);
            }
        }
    }
}
