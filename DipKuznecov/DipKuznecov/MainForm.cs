using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DipKuznecov
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadDataToTable(); //Вызов метода показа табл

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
            string query = "SELECT * FROM zayavki ORDER BY id_z";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[12]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
                data[data.Count - 1][9] = reader[9].ToString();
                data[data.Count - 1][10] = reader[10].ToString();
                data[data.Count - 1][11] = reader[11].ToString();
            }
            reader.Close();


            db.closeConnection();


            foreach (string[] s in data)
                usertableUA.Rows.Add(s);



        }




        private void label2_Click(object sender, EventArgs e)
        {// Крестик закрытие
            Application.Exit();
        }
  

        private void label2_MouseEnter_1(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.Gray;
        }

        private void label2_MouseLeave_1(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.White;
        }

        private void usertableUA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // отображение ячеек таблицы в текстовых полях при нажатии
            try
            {
                int i = e.RowIndex;
            DataGridViewRow row = usertableUA.Rows[i];
            idU.Text = row.Cells[0].Value.ToString();
            }
            catch (Exception ex) 
            { 
               MessageBox.Show("Выбирайте только поля заявок");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //изменить статус заявки (кнопка)
            
            try
            {

                if (idU.Text == "" )
                { MessageBox.Show("Проверьте данные"); }
                else
                {
                    DB db = new DB();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    db.openConnection();

                    string query = "update zayavki set status='" + gotovnostCombobox.Text + "' where id_z ='" + idU.Text + "' ";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные заявки обновлены успешно");
                    db.closeConnection();
                    LoadDataToTable();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //удалить заявку
            try
            {
                if (idU.Text == "")
                {
                    MessageBox.Show("Выберите пользователя для удаления");
                }
                else
                {
                    DB db = new DB();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    db.openConnection();

                    string query = " delete from zayavki where id_z=" + idU.Text + "";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Заявка удалена успешно");


                    db.closeConnection();
                    LoadDataToTable();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //кнопка составить заявку
            //this.Hide();
            SostavitZayvku sostavit_z = new SostavitZayvku();
            sostavit_z.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDataToTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //кнопка график доходов
            Grafic graf = new Grafic();
            graf.Show();
        }
    }
}
