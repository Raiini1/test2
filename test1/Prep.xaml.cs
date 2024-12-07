using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace test1
{
    /// <summary>
    /// Логика взаимодействия для Prep.xaml
    /// </summary>
    public partial class Prep : Window
    {
        private string cs = "Data Source=D:\\Рабочий стол\\test\\test\\test.db;Version=3;";
        public Prep()
        {
            InitializeComponent();
            Load_Prep();
        }
        private void Load_Prep()
        {
            List<Prepodavateli> prep = new List<Prepodavateli>();

            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();

                string query = "SELECT ID_Prepodavatel, Familia, Imya, Otchestvo, Data_rojdenia, Adres_projivania, Doljnost.Nazvanie_doljnosti as Doljnost_ID FROM Prepodavatel JOIN Doljnost ON Prepodavatel.Doljnost_ID = Doljnost.ID_Doljnost";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Prepodavateli prepp = new Prepodavateli
                        {
                            ID_Prepodavatel = reader["ID_Prepodavatel"].ToString(),
                            Familia = reader["Familia"].ToString(),
                            Imya = reader["Imya"].ToString(),
                            Otchestvo = reader["Otchestvo"].ToString(),
                            Data_rojdenia = reader["Data_rojdenia"].ToString(),
                            Adres_projivania = reader["Adres_projivania"].ToString(),
                            Doljnost_ID = reader["Doljnost_ID"].ToString(),
                        };
                        prep.Add(prepp);
                    }
                }
            }
            DataGridPrep.ItemsSource = prep;
        }
    }

    public class Prepodavateli
    {
        public string ID_Prepodavatel { get; set; }
        public string Familia { get; set; }
        public string Imya { get; set; }
        public string Otchestvo { get; set; }
        public string Data_rojdenia { get; set; }
        public string Adres_projivania { get; set; }
        public string Doljnost_ID { get; set; }
    }
}
