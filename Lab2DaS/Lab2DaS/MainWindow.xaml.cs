using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab2DaS.bibliotekaDataSetTableAdapters;

namespace Lab2DaS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuthorsTableAdapter authors = new AuthorsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            AuthorsDgr.ItemsSource = authors.GetData();
        }

        //Добавление
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            authors.InsertQuery(NameTbx.Text);
            AuthorsDgr.ItemsSource = authors.GetData();
        }

        //Изменение
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (AuthorsDgr.SelectedItem as DataRowView).Row[0];
            authors.UpdateQuery(NameTbx.Text, Convert.ToInt32(id));
        }

        //Удаление
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (AuthorsDgr.SelectedItem as DataRowView)?.Row[0];
            authors.DeleteQuery(Convert.ToInt32(id));
        }
    }
}
