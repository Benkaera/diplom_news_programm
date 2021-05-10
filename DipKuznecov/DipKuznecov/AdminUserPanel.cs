using System;
using System.Net; //API
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;

namespace DipKuznecov
{
    public partial class AdminUserPanel : Form
    {
        WebClient client = new WebClient();//API
        public AdminUserPanel()
        {
            InitializeComponent();

            LoadDataToTable(); //Вызов метода показа таблицы

        }

        public void LoadDataToTable() 
        { //показ таблицы
            usertableUA.Rows.Clear();
            usertableUA.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы пользователи
            string query = "SELECT * FROM users ORDER BY id";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read()) 
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }
            reader.Close();


            db.closeConnection();


            foreach (string[] s in data)
                usertableUA.Rows.Add(s);


            
        }



        private void usertableUA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {// отображение ячеек таблицы в текстовых полях при нажатии

            int i = e.RowIndex;
            DataGridViewRow row = usertableUA.Rows[i];
            idUA.Text = row.Cells[0].Value.ToString();
            loginUA.Text = row.Cells[1].Value.ToString();
            passUA.Text = row.Cells[2].Value.ToString();
            famUA.Text = row.Cells[3].Value.ToString();
            imyaUA.Text = row.Cells[4].Value.ToString();
            otchUA.Text = row.Cells[5].Value.ToString();
            dolzhUA.Text = row.Cells[6].Value.ToString();
            roleUA.Text = row.Cells[7].Value.ToString();
             
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.Gray;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //кнопка удаления
            try 
            {
                if (idUA.Text == "")
                {
                    MessageBox.Show("Выберите пользователя для удаления");
                }
                else 
                {
                    DB db = new DB();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    db.openConnection();

                    string query = " delete from users where id=" + idUA.Text +"";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пользователь удален успешно");
                    

                    db.closeConnection();
                    LoadDataToTable();
                }

            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //кнопка редактирования
            try 
            {

                if (idUA.Text == "" || loginUA.Text == "" || passUA.Text == "" || famUA.Text == "" || imyaUA.Text == "" || otchUA.Text == "" || dolzhUA.Text == "" || roleUA.Text == "")
                { MessageBox.Show("Проверьте данные"); }
                else
                {
                    DB db = new DB();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    db.openConnection();

                    string query = "update users set login='" + loginUA.Text + "', pass='" + passUA.Text + "', familiya='" + famUA.Text + "',imya='" + imyaUA.Text + "',otchestvo='" + otchUA.Text + "',dolzhnost='" + dolzhUA.Text + "',role='" + roleUA.Text + "' where id ='" + idUA.Text + "' ";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные пользователя обновлены успешно");
                    db.closeConnection();
                    LoadDataToTable();
                }
            } 
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //кнопка добавить

            
            try
            {

                if (idUA.Text == "" || loginUA.Text == "" || passUA.Text == "" || famUA.Text == "" || imyaUA.Text == "" || otchUA.Text == "" || dolzhUA.Text == "" || roleUA.Text == "")
                { MessageBox.Show("Проверьте данные"); }
                else
                {
                    

                    string id = idUA.Text;
                    string login = loginUA.Text;
                    string pass = passUA.Text;
                    string familiya = famUA.Text;

                    string imya = imyaUA.Text;
                    string otchestvo = otchUA.Text;
                    string dolzhnost = dolzhUA.Text;
                    string role = roleUA.Text;

                    string URL = "http://localhost:81/index.php?id=" + id + "&login=" + login+ "&pass=" + pass + "&familiya=" + familiya + "&imya=" + imya + "&otchestvo=" + otchestvo + "&dolzhnost=" + dolzhnost + "&role=" + role;

                    using (WebClient client = new WebClient())
                    {
                        string src = client.DownloadString(URL);
                        MessageBox.Show("Пользователь добавлен");
                    }

                        LoadDataToTable();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            label11.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }
    }
}
