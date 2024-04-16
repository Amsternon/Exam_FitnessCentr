using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using MySql.Data.MySqlClient;

namespace Ermolenko_FitnessCentr;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    string connectionString = "server=10.10.1.24;database=abd10_1;port=3306;User Id=user_01;password=user01pro";

    private void Enter_OnClick(object? sender, RoutedEventArgs e)
    {
        string username = Login.Text;
        string password = Password.Text;
        if (IsUserValid(username, password))
        {
            clients choise = new clients();
            Hide();
            choise.Show();
        }
        else
        {
            Console.Write("Неверный логин или пароль");
        }
    }
    
    private bool IsUserValid(string username, string password) 
    {
        bool isValid = false;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "SELECT COUNT(1) FROM client WHERE Telephone = @Username AND Password = @Password";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();

                object result = command.ExecuteScalar();
                int count = Convert.ToInt32(result);

                if (count == 1)
                {
                    isValid = true;
                }
            }
        }
        return isValid;
    }

    public void Exit_onClick(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void Registration(object? sender, RoutedEventArgs e)
    {
        Registration reg = new Registration();
        Hide();
        reg.Show();
    }

    private void Register_OnClick(object? sender, RoutedEventArgs e)
    {
            Registration reg = new Registration();
            Hide();
            reg.Show();
    }
}