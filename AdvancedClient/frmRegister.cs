using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace AdvancedClient
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        frmClient frm = new frmClient();
        string DosyaYolu = Application.StartupPath + "\\Kisiler.xml";
        public static string girisName = "";

        private void btn_GirişYap_Click(object sender, EventArgs e)
        {
            bool giris = false;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(DosyaYolu);

            XmlNode SecilenNode = xmlDoc.ChildNodes[1];

            foreach (XmlNode item in SecilenNode)
            {
                if (item.ChildNodes[2].InnerText == txt_KullanıcıAdı.Text && item.ChildNodes[3].InnerText == txt_Şifre.Text)
                {
                    MessageBox.Show("Hosgeldin " + item.ChildNodes[0].InnerText);
                    girisName = item.ChildNodes[0].InnerText;
                    frm.Show();
                    this.Hide();
                    giris = true;
                    break;
                }
                else
                {
                    giris = false;
                }                
            }
            if (giris == false)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
