using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
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

    public partial class UserBillWindow : Window
    {
        public UserBillWindow()
        {
            InitializeComponent();
        }





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            using (ApplicationContext context = new ApplicationContext())
            {
                List<Total> total = context.Totals.ToList();
                listOfBill.ItemsSource = total;
            }


















        }

        private void Create_Bill(object sender, RoutedEventArgs e)
        {
            string nameBill;
            if (textBoxForName.Text != "")
            {
                nameBill = textBoxForName.Text.Trim();
            }
            else
            {
                MessageBox.Show("Введите Название!");
                return;
            }


            double amount;
            if (textBoxForAmount.Text != "")
            {
                amount = Convert.ToDouble(textBoxForAmount.Text.Trim());
            }
            else
            {
                MessageBox.Show("Выберите сумму!");
                return;
            }


            Total totals = new Total(amount, nameBill);

            using(ApplicationContext context = new ApplicationContext())
            {
                context.Totals.Add(totals);
                context.SaveChanges();

                List<Total> total = context.Totals.ToList();
                listOfBill.ItemsSource = total;
            }

            textBoxForName.Clear();
            textBoxForAmount.Clear();

        }

        private void Go_To_Transfers(object sender, RoutedEventArgs e)
        {
            UserTransfersWindow userTransfersWindow = new UserTransfersWindow();
            userTransfersWindow.Show();
            Hide();
        }
    }
}