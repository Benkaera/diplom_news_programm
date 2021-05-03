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
    public partial class AdminUserPanel : Form
    {
        public AdminUserPanel()
        {
            InitializeComponent();
            LoadDataToTable(); //Вызов метода показа таблицы
        }

        public void LoadDataToTable() 
        { //показ таблицы
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




            //для нажатия и появления данных слева в столбцах добавления
            //MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            //var ds = new DataSet();
            //adapter.SelectCommand = command;
            //adapter.Fill(ds);
            //usertableUA.DataSource = ds.Tables[0];
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


            //idUA.Text = usertableUA.SelectedRows[1].Cells[0].Value.ToString();
            //loginUA.Text = usertableUA.SelectedRows[1].Cells[1].Value.ToString();
            //.Text = usertableUA.SelectedRows[1].Cells[2].Value.ToString();
            //.Text = usertableUA.SelectedRows[1].Cells[3].Value.ToString();
            //.Text = usertableUA.SelectedRows[1].Cells[4].Value.ToString();
            // .Text = usertableUA.SelectedRows[1].Cells[5].Value.ToString();
            // .Text = usertableUA.SelectedRows[1].Cells[6].Value.ToString();
            // .Text = usertableUA.SelectedRows[1].Cells[7].Value.ToString();
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
    }
}
