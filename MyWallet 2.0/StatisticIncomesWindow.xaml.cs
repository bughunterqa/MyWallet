using MyWallet_2._0.Helpers;
using MyWallet_2._0.Models;
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
using System.Windows.Shapes;

namespace MyWallet_2._0
{

    public partial class StatisticIncomesWindow : Window
    {
        public StatisticIncomesWindow()
        {
            InitializeComponent();
        }

        private void Back_to_Income(object sender, RoutedEventArgs e)
        {
            UserIncomeWindow userIncome = new UserIncomeWindow();
            userIncome.Show();
            Hide();
        }

        private void Go_to_StatisticCosts(object sender, RoutedEventArgs e)
        {
            StatisticCostsWindow statisticCosts = new StatisticCostsWindow();
            statisticCosts.Show();
            Hide();
        }

        private void comboBoxForCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            int getCategoryId;
            if (comboBoxForCategories.SelectedIndex > -1)
            {
                getCategoryId = Convert.ToInt32(comboBoxForCategories.SelectedItem.ToString());
                using (ApplicationContext context = new ApplicationContext())
                {
                    List<UserIncome> userIncomes = null;
                    userIncomes = context.UserIncomes.Where(b => b.CategoryId == getCategoryId).ToList();

                    historyByCategory.ItemsSource = userIncomes.Take(100);

                    new Sorting().SortDesc(historyByCategory);
                }
            }
            else
                return;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<IncomeCategory> categories = context.IncomeCategories.ToList();

                comboBoxForCategories.ItemsSource = categories;


                new StatisticsByDay().ByDay(historyByDate);


            }

            new Sorting().SortDescAmount(historyByDate);

            byDayButton.Background = Brushes.MediumPurple;
            byMonthButton.Background = Brushes.LightSkyBlue;
            byYearButton.Background = Brushes.LightSkyBlue;
        }

        private void Button_Click_By_Day(object sender, RoutedEventArgs e)
        {
            historyByDate.Items.Clear();
            new StatisticsByDay().ByDay(historyByDate);
            new Sorting().SortDescAmount(historyByDate);

            byDayButton.Background = Brushes.MediumPurple;
            byMonthButton.Background = Brushes.LightSkyBlue;
            byYearButton.Background = Brushes.LightSkyBlue;


        }

        private void Button_Click_By_Month(object sender, RoutedEventArgs e)
        {
            historyByDate.Items.Clear();
            new StatisticsByDay().ByMonth(historyByDate);
            new Sorting().SortDescAmount(historyByDate);

            byDayButton.Background = Brushes.LightSkyBlue;
            byMonthButton.Background = Brushes.MediumPurple;
            byYearButton.Background = Brushes.LightSkyBlue;

        }

        private void Button_Click_By_Year(object sender, RoutedEventArgs e)
        {
            historyByDate.Items.Clear();
            new StatisticsByDay().ByYear(historyByDate);
            new Sorting().SortDescAmount(historyByDate);

            byDayButton.Background = Brushes.LightSkyBlue;
            byMonthButton.Background = Brushes.LightSkyBlue;
            byYearButton.Background = Brushes.MediumPurple;
        }
    }
}
