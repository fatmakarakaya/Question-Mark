using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworksApi.TCP.SERVER;
using System.Net;
using System.Xml;
using System.Threading;
namespace AdvencedServer
{
    public partial class frmServer : Form
    {
        struct Kullanici
        {
            public string userName;
            public int dogruSayisi ;
        };
        int sayi = 0;
        int sorulacakSoruIndex = 0;
        int sorulanSoruIndex ;
        string cevap = "";
        Server server;
        public delegate void UpdateChatLog(string txt);
        public delegate void UpdateListBox(ListBox box, string value,bool Remove);
        Kullanici[] kullanicilar = new Kullanici[0];
        string DosyaYolu = Application.StartupPath + "\\Sorular.xml";
        
        public frmServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string bilgisayarAdi = Dns.GetHostName();
            string ipAdresi = System.Net.Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            server = new Server(ipAdresi, "3000");
            server.OnClientConnected += new OnConnectedDelegate(server_OnClientConnected);
            server.OnClientDisconnected += new OnDisconnectedDelegate(server_OnClientDisconnected);
            server.OnDataReceived += new OnReceivedDelegate(server_OnDatareceived);
            server.OnServerError += new OnErrorDelegate(server_OnServerError);
            server.Start();
            
        }

        private void ChangeChatLog(string txt)
        {

            if(textBox1.InvokeRequired)
            {
                Invoke(new UpdateChatLog(ChangeChatLog), new object[] { txt });

            }
            else
            {
                textBox1.Text += txt + "\r\n";
            }
        }

        private void ChangeListBox(ListBox box, string value,bool Remove)
        {
            if(box.InvokeRequired)
            {
                Invoke(new UpdateListBox(ChangeListBox), new object[] { box,value,Remove });
            }
            else
            {
                if (Remove)
                {
                    box.Items.Remove(value);
                }
                else
                {
                    box.Items.Add(value);
                }
            }
        }

        private void server_OnServerError(object Sender, ErrorArguments R)
        {
            MessageBox.Show(R.ErrorMessage);
        }

        private void server_OnDatareceived(object Sender, ReceivedArguments R)
        {
            ChangeChatLog(R.Name+ " : "+R.ReceivedData);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(DosyaYolu);
            XmlNode SecilenNode = xmlDoc.ChildNodes[1];
            foreach (XmlNode item in SecilenNode)
            {
                if (Convert.ToInt32(item.ChildNodes[0].InnerText) == sorulanSoruIndex)
                {
                  
                    for (int i = 0; i < kullanicilar.Length; i++)
                    {
                        if (kullanicilar[i].userName == R.Name)
                        {
                            if (R.ReceivedData == cevap)
                            {
                                kullanicilar[i].dogruSayisi++;
                            }
                        }
                    }
                }
            }
            server.BroadCast(R.Name+" says : "+R.ReceivedData);
        }

        private void server_OnClientDisconnected(object Sender, DisconnectedArguments R)
        {
            server.BroadCast(R.Name + " Has Disconnected");
            ChangeListBox(listBox1, R.Name, true);
        }

        private void server_OnClientConnected(object Sender, ConnectedArguments R)
        {
            server.BroadCast(R.Name + " Has Connected");
            Array.Resize(ref kullanicilar, kullanicilar.Length + 1);
            kullanicilar[kullanicilar.Length - 1].userName = R.Name;
            kullanicilar[kullanicilar.Length - 1].dogruSayisi = 0;

            ChangeListBox(listBox1, R.Name, false);
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            sayi = 0;
            Timer.Interval = 1000;
            Timer.Start();
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            server.DisconnectClient((string)listBox1.SelectedItem);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            sayi = sayi + 1;
            int kazananId = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(DosyaYolu);
            XmlNode SecilenNode = xmlDoc.ChildNodes[1];

            server.BroadCast("Süreniz = " + sayi.ToString());
            if (sorulacakSoruIndex == 5 && (sayi-6)%15==14)
            {
                for (int i = 0; i < kullanicilar.Length; i++)
                {
                    if (kullanicilar[i].dogruSayisi > kullanicilar[kazananId].dogruSayisi)
                    {
                        kazananId = i;
                    }
                }
                sorulacakSoruIndex = 0;
                server.BroadCast("Yarışmanın Kazananı " + kullanicilar[kazananId].userName);
                for (int i = 0; i < kullanicilar.Length; i++)
                {
                    kullanicilar[i].dogruSayisi = 0;
                }
                kazananId = 0;
                Timer.Stop();
            }
            else if ((sayi%15) == 5 && sorulacakSoruIndex < 5)
            {

                foreach (XmlNode item in SecilenNode)
                {
                    if (Convert.ToInt32(item.ChildNodes[0].InnerText) == sorulacakSoruIndex)
                    {
                        server.BroadCast("Soru : " + item.ChildNodes[1].InnerText);
                        server.BroadCast(item.ChildNodes[2].InnerText);
                        server.BroadCast(item.ChildNodes[3].InnerText);
                        server.BroadCast(item.ChildNodes[4].InnerText);
                        cevap = item.ChildNodes[5].InnerText;
                    }
                }
                sorulanSoruIndex = sorulacakSoruIndex;
                sorulacakSoruIndex++;
            }                     
            lblSayac.Text = sayi.ToString();
            if (sayi==15)
            {
                server.BroadCast("Cevap = "+cevap);
            }
            else if(sayi>15 && sayi%15 ==0)
            {
                server.BroadCast("Cevap = " + cevap);
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
