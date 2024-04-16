using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using System;
using Avalonia.Interactivity;

namespace Ermolenko_FitnessCentr;

public partial class Registration : Window
{
    public Registration()
    {
        InitializeComponent();
    }
    
    private MySqlConnection conn;
    private string connStr = "server=10.10.1.24;database=abd10_1;port=3306;User Id=user_01;password=user01pro";
    private void Reg(object? sender, RoutedEventArgs e)
    {
        conn = new MySqlConnection(connStr);
        conn.Open();
        string regist = "INSERT INTO client VALUES (" + Convert.ToInt32(id.Text) + ", '" + Surname.Text + "', '" + Name.Text + "', '" + Telephone.Text + "', '" + Password.Text + "', '" + Date.Text + "', '" + Convert.ToInt32(Gender.Text)  + "');";
        MySqlCommand cmd = new MySqlCommand(regist, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    private void GoBack(object? sender, RoutedEventArgs e)
    {
        MainWindow auth = new MainWindow();
        this.Close();
        auth.Show();
    }
}