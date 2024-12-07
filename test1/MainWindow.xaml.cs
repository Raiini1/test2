using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Role;
            string cs = @"Data Source=D:\\Рабочий стол\\test\\test\\test.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT Role FROM Avtorizacia WHERE Login = @Login and Parol = @Parol", connection);
                command.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                command.Parameters.AddWithValue("@Parol", TextBoxParol.Password);
                Role = (string)command.ExecuteScalar();
            }
            if (Role == "Администратор")
            {
                this.Hide();
                Prep f3 = new Prep();
                f3.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
