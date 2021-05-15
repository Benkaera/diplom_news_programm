using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DipKuznecov
{
    public partial class SostavitZayvku : Form
    {
        public SostavitZayvku()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Крестик закрытие
            this.Close();
            
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.Gray;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Кнопка готовности заявки (ОК)
            


            try
            {

                if (nazvUz.Text == "" || commUz.Text == "" || dateUz.Text == "" || locUz.Text == "" || catUz.Text == "" || statusUz.Text == "" )
                { MessageBox.Show("Проверьте введенные данные"); }
                else
                {


                    string nazv = nazvUz.Text;
                    string comm = commUz.Text;
                    string date = dateUz.Text;
                    string locat = locUz.Text;
                    string cat = catUz.Text;
                    string status = statusUz.Text;
                    

                    string URL = "http://localhost:81/zayav.php?nazv=" + nazv + "&comm=" + comm + "&date=" + date + "&locat=" + locat + "&cat=" + cat + "&status=" + status;

                    using (WebClient client = new WebClient())
                    {
                        string src = client.DownloadString(URL);
                        MessageBox.Show("Заявка добавлена");
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            MessageBox.Show(catUz.Text); 
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }
    }
}
