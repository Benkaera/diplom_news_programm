using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DipKuznecov
{
    class DB
    {
        //Подключение к БД для авторизации
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=root; database=diplom_users");

        public void openConnection()
        {
            //Открытие соединения
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            //Закрытие соединения
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection() 
        {
            //Возврат соединения
            return connection;
        }

    }
}
