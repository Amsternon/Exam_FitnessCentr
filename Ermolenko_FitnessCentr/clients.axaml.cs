using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace Ermolenko_FitnessCentr;

public partial class clients : Window
{
    public clients()
    {
        InitializeComponent();
        ShowTable(fullTable);
    }
    
     string fullTable = "SELECT * FROM Client";

     private List<tables> users;
    string connStr = "server=127.0.0.1;database=abd10_1;port=3306;User Id=root;password=12345";
    private MySqlConnection conn;

    public void ShowTable(string sql)
    {
        users = new List<tables>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var Client = new tables()
            {
                id = reader.GetInt32("ID"),
                Surname = reader.GetString("Surname"),
                Firstname = reader.GetString("FirstName"),
                Telephone = reader.GetString("Telephone"),
                Password = reader.GetString("Password"),
                Date = reader.GetString("Date"),
                Gender = reader.GetInt32("Gender"),
            };
            users.Add(Client);
        }
        conn.Close();
        DataGrid.ItemsSource = users;
    }
    

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow back = new MainWindow();
        Close();
        back.Show();
    }

    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string add = "INSERT INTO client VALUES (" + Convert.ToInt32(text1.Text) + ", '" + text2.Text + "', '" + text3.Text + "', '" + text4.Text + "', '" + text5.Text + "', '" + text6.Text + "', '" + Convert.ToInt32(text7.Text)  + "');";
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception exception)
        {
            Debug.WriteLine("Эта запись используется в других таблицах", text1.Text = exception.Message);
        }
    }

    private void Delete_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Search_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        string sqlsearch = "select * from client WHERE Surname LIKE '%"+Search.Text+"%'";
        ShowTable(sqlsearch);
    }
}