using System;
using System.Collections.Generic;
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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bibliotekaEntities context = new bibliotekaEntities();
        public MainWindow()
        {
            InitializeComponent();
            AuthorsDgr.ItemsSource = context.Authors.ToList();
        }

        private void AuthorsDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorsDgr.SelectedItem != null)
            {
                var selected = AuthorsDgr.SelectedItem as Authors;

                NameTbx.Text = selected.Name;
            }
        }

        //Добавление
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Authors c = new Authors();
            c.Name = NameTbx.Text;

            context.Authors.Add(c);

            context.SaveChanges();
            AuthorsDgr.ItemsSource = context.Authors.ToList();
        }


        //Изменение
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsDgr.SelectedItem != null)
            {
                var selected = AuthorsDgr.SelectedItem as Authors;

                selected.Name = NameTbx.Text;

                context.SaveChanges();
                AuthorsDgr.ItemsSource = context.Authors.ToList();
            }
        }


        //Удаление
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AuthorsDgr.SelectedItem != null)
            {
                context.Authors.Remove(AuthorsDgr.SelectedItem as Authors);

                context.SaveChanges();
                AuthorsDgr.ItemsSource = context.Authors.ToList();
            }
        }
    }
}
