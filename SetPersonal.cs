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
    public partial class SetPersonal : Form
    {
        public SetPersonal()
        {
            InitializeComponent();
            LoadDataToTable();
        }

        int index_of_label_if = 0;//для иф условий выборки добавления в бд
        Point lastPoint;


        public void LoadDataToTable()
        { //показ таблицы главной
            usertableUA.Rows.Clear();
            usertableUA.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы пользователи
            string query = "SELECT id_z, name, p_journalist, p_montazher, p_vipmen, p_semgr1, p_semgr2 FROM zayavki ORDER BY id_z";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                
            }
            reader.Close();


            db.closeConnection();


            foreach (string[] s in data)
                usertableUA.Rows.Add(s);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            //НАЗНАЧИТЬ с ифами



            if (index_of_label_if == 1)
            {
                // Журналист

                try
                {

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" )
                    { MessageBox.Show("Проверьте данные"); }
                    else
                    {
                        DB db = new DB();
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        db.openConnection();

                        string query = "update zayavki set p_journalist='" + textBox1.Text + " " + textBox2.Text+ " " + textBox3.Text + "' where id_z ='" + idpersonal.Text + "' ";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Персонал назначен");
                        db.closeConnection();
                        LoadDataToTable();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }



            }
            else if (index_of_label_if == 2)
            {
                // Монтажёр

                try
                {

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    { MessageBox.Show("Проверьте данные"); }
                    else
                    {
                        DB db = new DB();
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        db.openConnection();

                        string query = "update zayavki set p_montazher='" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "' where id_z ='" + idpersonal.Text + "' ";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Персонал назначен");
                        db.closeConnection();
                        LoadDataToTable();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else if (index_of_label_if == 3)
            {
                // Съемочная группа1

                try
                {

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    { MessageBox.Show("Проверьте данные"); }
                    else
                    {
                        DB db = new DB();
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        db.openConnection();

                        string query = "update zayavki set p_semgr1='" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "' where id_z ='" + idpersonal.Text + "' ";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Персонал назначен");
                        db.closeConnection();
                        LoadDataToTable();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else if (index_of_label_if == 4)
            {
                // Съемочная группа2

                try
                {

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    { MessageBox.Show("Проверьте данные"); }
                    else
                    {
                        DB db = new DB();
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        db.openConnection();

                        string query = "update zayavki set p_semgr2='" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "' where id_z ='" + idpersonal.Text + "' ";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Персонал назначен");
                        db.closeConnection();
                        LoadDataToTable();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else if (index_of_label_if == 5)
            {
                // Выпускающий оператор
                try
                {

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    { MessageBox.Show("Проверьте данные"); }
                    else
                    {
                        DB db = new DB();
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        db.openConnection();

                        string query = "update zayavki set p_vipmen='" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "' where id_z ='" + idpersonal.Text + "' ";
                        MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Персонал назначен");
                        db.closeConnection();
                        LoadDataToTable();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Ошибка. выберите категорию сотрудника");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //сортировка журналист

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы 
            string query = "SELECT dolzhnost, familiya, imya, otchestvo FROM users WHERE dolzhnost= 'Журналист' ";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                

            }
            reader.Close();
            db.closeConnection();


            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

            index_of_label_if = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //сортировка монтажёр

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы 
            string query = "SELECT dolzhnost, familiya, imya, otchestvo FROM users WHERE dolzhnost= 'Монтажёр' ";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();


            }
            reader.Close();
            db.closeConnection();


            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            index_of_label_if = 2;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //сортировка съёмчн группа
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы 
            string query = "SELECT dolzhnost, familiya, imya, otchestvo FROM users WHERE dolzhnost= 'Съемочная группа' ";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();


            }
            reader.Close();
            db.closeConnection();


            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

            index_of_label_if = 3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //сортировка выпуск оператор
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы 
            string query = "SELECT dolzhnost, familiya, imya, otchestvo FROM users WHERE dolzhnost= 'Выпускающий менеджер' ";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();


            }
            reader.Close();
            db.closeConnection();


            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            index_of_label_if = 5;
        }

        private void usertableUA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = usertableUA.Rows[i];
            idpersonal.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //сортировка съёмчн группа2
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы 
            string query = "SELECT dolzhnost, familiya, imya, otchestvo FROM users WHERE dolzhnost= 'Съемочная группа' ";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();


            }
            reader.Close();
            db.closeConnection();


            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

            index_of_label_if = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
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

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Black;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.ForeColor = Color.White;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.ForeColor = Color.Black;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.ForeColor = Color.White;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.ForeColor = Color.Black;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.ForeColor = Color.White;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
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
