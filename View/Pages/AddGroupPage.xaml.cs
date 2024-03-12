using PetrovaControl8.Model;
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

namespace PetrovaControl8.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : Page
    {
        public AddGroupPage()
        {
            InitializeComponent();
            SpezCmb.SelectedValuePath = "Id";
            SpezCmb.DisplayMemberPath = "Name";
            SpezCmb.ItemsSource = App.context.Spez.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if(string.IsNullOrEmpty(NameTb.Text))
            {
                mes += "Напишите имя группы\n";
            }
            if(string.IsNullOrEmpty(SpezCmb.Text))
            {
                mes += "Выберите спезализацию группы\n";
            }
            if(mes !="")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Group group = new Group()
            {
                Name = NameTb.Text,
                Spez = SpezCmb.SelectedItem as Spez
            };

            App.context.Group.Add(group);
            App.context.SaveChanges();
            MessageBox.Show("Группа успешно добавлена!");
            NameTb.Text = "";
            SpezCmb.Text = "";
        }
    }
}
