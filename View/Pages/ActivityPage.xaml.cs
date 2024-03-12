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
    /// Логика взаимодействия для ActivityPage.xaml
    /// </summary>
    public partial class ActivityPage : Page
    {
        public ActivityPage()
        {
            InitializeComponent();
            DirectionCmb.SelectedValuePath = "Id";
            DirectionCmb.DisplayMemberPath = "Name";
            DirectionCmb.ItemsSource = App.context.Direction.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrEmpty(NameTb.Text))
            {
                mes += "Напишите название активности\n";
            }
            if (string.IsNullOrEmpty(DirectionCmb.Text))
            {
                mes += "Выберите направленность активности\n";
            }
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Activity activity = new Activity()
            {
                Name = NameTb.Text,
                Direction = DirectionCmb.SelectedItem as Direction
            };

            App.context.Activity.Add(activity);
            App.context.SaveChanges();
            MessageBox.Show("Активность успешно добавлена!");
            NameTb.Text = "";
            DirectionCmb.Text = "";
        }
    }
}
