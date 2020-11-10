using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworksApi.TCP.CLIENT;
using System.Net;
using System.Xml;

namespace AdvancedClient
{
    public partial class frmClient : Form
    {
        public delegate void UpdateText(string txt);

        public frmClient()
        {
            InitializeComponent();
        }
        Client client;


        string DosyaYolu = Application.StartupPath + "\\Kisiler.xml";

        int sayac = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            string bilgisayarAdi = Dns.GetHostName();
            label1.Text = "Bilgisayar Adı: " + bilgisayarAdi;
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(DosyaYolu);

            XmlNode SecilenNode = xmlDoc.ChildNodes[1];

            foreach (XmlNode item in SecilenNode)
            {
                txt_ClientName.Text = frmRegister.girisName;
            }
            txt_IP.Text = ipAdresi;
            txt_Port.Text = "24";

        }
        private void ChangeTextBox(string txt)
        {

            if (lblSoru.InvokeRequired)
            {
                Invoke(new UpdateText(ChangeTextBox), new object[] { txt });

            }
            else
            {
                if (txt.Substring(0, 2) == "A)")
                {
                    btnA.Text = txt;
                    btnA.BackColor = Color.FromArgb(255, 240, 240, 240);
                    btnA.Enabled = true;
                }
                else if (txt.Substring(0, 2) == "B)")
                {
                    btnB.Text = txt;
                    btnB.BackColor = Color.FromArgb(255, 240, 240, 240);
                    btnB.Enabled = true;
                }
                else if (txt.Substring(0, 2) == "C)")
                {
                    btnC.Text = txt;
                    btnC.BackColor = Color.FromArgb(255, 240, 240, 240);
                    btnC.Enabled = true;
                }
                else if (txt.Substring(0, 2) == "Sü")
                {

                    sayac++;
                    if (((sayac % 15)) > 5)
                    {
                        lblSure.Text = ((sayac % 15) - 5).ToString();
                    }
                    else
                    {
                        lblSure.Text = "Bekleyin.";
                    }

                    if ((sayac % 15) <= 4)
                    {
                        lblSureKontrol.Text = "Sorunuz Hazırlanıyor..." + (5 - (sayac%5)).ToString();
                        lblSoru.Text = "";
                        btnA.Enabled = false;
                        btnB.Enabled = false;
                        btnC.Enabled = false;
                    }
                    else
                    {
                        lblSureKontrol.Text = "";
                    }
                    if (txt == "Süreniz = 15")
                    {
                        btnA.Enabled = false;
                        btnB.Enabled = false;
                        btnC.Enabled = false;
                        lblSureKontrol.Text = "Süreniz Dolmuştur. Yeni Soruyu Bekleyiniz...";
                    }



                }
                else if (txt.Substring(0, 2) == "Ce")
                {

                    if (txt == "Cevap = A")
                    {
                        btnA.BackColor = Color.Green;
                    }
                    else if (txt == "Cevap = B")
                    {
                        btnB.BackColor = Color.Green;
                    }
                    else if (txt == "Cevap = C")
                    {
                        btnC.BackColor = Color.Green;
                    }

                }
                else if (txt.Substring(0, 2) == "So")
                {
                    lblSoru.Text = txt;
                    btnA.BackColor = Color.FromArgb(255, 240, 240, 240);
                    btnB.BackColor = Color.FromArgb(255, 240, 240, 240);
                    btnC.BackColor = Color.FromArgb(255, 240, 240, 240);

                }
                else if (txt.Substring(0, 5) == "Yarış")
                {
                    MessageBox.Show(txt, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblSureKontrol.Text = "Yarışmamız Sona Ermiştir...";
                    sayac = 0;
                }
            }
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (txt_ClientName.Text != "" && txt_IP.Text != "" && txt_Port.Text != "")
            {
                client = new Client();
                client.ClientName = txt_ClientName.Text;
                client.ServerIp = txt_IP.Text;
                client.ServerPort = txt_Port.Text;

                client.OnClientConnected += new OnClientConnectedDelegate(client_OnClientConnected);
                client.OnClientConnecting += new OnClientConnectingDelegate(client_OnClientConnecting);
                client.OnClientDisconnected += new OnClientDisconnectedDelegate(client_OnClientDisconnected);
                client.OnClientError += new OnClientErrorDelegate(client_OnClientError);
                client.OnClientFileSending += new OnClientFileSendingDelegate(client_OnClientFileSending);
                client.OnDataReceived += new OnClientReceivedDelegate(client_OnDataReceived);

                client.Connect();


            }
            else
            {
                MessageBox.Show("You Must Fill All The Textboxes");
            }
        }

        private void client_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            ChangeTextBox(R.ReceivedData);
        }

        private void client_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {

        }

        private void client_OnClientError(object Sender, ClientErrorArguments R)
        {
            ChangeTextBox(R.ErrorMessage);
            MessageBox.Show("Bağlantı Kurulamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void client_OnClientDisconnected(object Sender, ClientDisconnectedArguments R)
        {
            ChangeTextBox(R.EventMessage);
            MessageBox.Show("Yarışmamız Sona Ermiştir...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void client_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            ChangeTextBox(R.EventMessage);
            
        }

        private void client_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            ChangeTextBox(R.EventMessage);
            MessageBox.Show("Yarışmamıza Hoşgeldiniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            if (lblSoru.InvokeRequired)
            {
                Invoke(new UpdateText(ChangeTextBox), new object[] { R.EventMessage });

            }
            else
            {

                btn_Connect.Enabled = false;
            }
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                client.Send("A");
                btnA.BackColor = Color.Orange;
                btnA.Enabled = false;
                btnB.Enabled = false;
                btnC.Enabled = false;
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                client.Send("B");
                btnB.BackColor = Color.Orange;
                btnA.Enabled = false;
                btnB.Enabled = false;
                btnC.Enabled = false;
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                client.Send("C");
                btnC.BackColor = Color.Orange;
                btnA.Enabled = false;
                btnB.Enabled = false;
                btnC.Enabled = false;
               
            }
        }

        private void lblSure_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
