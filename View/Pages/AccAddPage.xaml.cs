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
    /// Логика взаимодействия для AccAddPage.xaml
    /// </summary>
    public partial class AccAddPage : Page
    {
        public AccAddPage()
        {
            InitializeComponent();
            AccDg.ItemsSource = App.context.Acc.ToList();
            SpezCmb.SelectedValuePath = "Id";
            SpezCmb.DisplayMemberPath = "Name";
            SpezCmb.ItemsSource = App.context.Spez.ToList();
            DirectionCmb.SelectedValuePath = "Id";
            DirectionCmb.DisplayMemberPath = "Name";
            DirectionCmb.ItemsSource = App.context.Direction.ToList();
            GroupCmb.SelectedValuePath = "Id";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = App.context.Group.ToList();
            ActivityCmb.SelectedValuePath = "Id";
            ActivityCmb.DisplayMemberPath = "Name";
            ActivityCmb.ItemsSource = App.context.Activity.ToList();

        }

        private void AccDg_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if(string.IsNullOrEmpty(ActivityCmb.Text))
            {
                mes += "Выберите активность\n";
            }
            if(string.IsNullOrEmpty(DirectionCmb.Text))
            {
                mes += "Выберите направление\n";
            }
            if(string.IsNullOrEmpty(GroupCmb.Text))
            {
                mes += "Выберите группу\n";
            }
            if(string.IsNullOrEmpty(SpezCmb.Text))
            {
                mes += "Выберите специализацию\n";
            }
            if(string.IsNullOrEmpty(MarkTb.Text))
            {
                mes += "Введите оценку\n";
            }
            if(string.IsNullOrEmpty(DateDp.Text))
            {
                mes += "Выберите дату\n";
            }
            if(mes !="")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Acc acc = new Acc()
            {
                Group = GroupCmb.SelectedItem as Group,
                Activity = ActivityCmb.SelectedItem as Activity,
                Mark = Convert.ToDecimal(MarkTb.Text),
                Date = (DateTime)DateDp.SelectedDate
            };

            App.context.Acc.Add(acc);
            App.context.SaveChanges();
            MessageBox.Show("Учёт обновлён");
            ActivityCmb.Text = "";
            DirectionCmb.Text = "";
            GroupCmb.Text = "";
            SpezCmb.Text = "";
            MarkTb.Text = "";
            DateDp.Text = "";
            AccDg.ItemsSource = App.context.Acc.ToList();
        }

        private void SpezCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedSpez = Convert.ToInt32(SpezCmb.SelectedValue);
            GroupCmb.ItemsSource = App.context.Group.Where(x => x.SpezId == SelectedSpez).ToList();
        }

        private void DirectionCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedDirection = Convert.ToInt32(DirectionCmb.SelectedValue);
            ActivityCmb.ItemsSource = App.context.Activity.Where(x => x.DirectionId == SelectedDirection).ToList();
        }
    }
}
