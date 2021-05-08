using System;
using System.Collections.Generic;
using System.Data;
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
    /// <summary>
    /// Interaction logic for UserTransfersWindow.xaml
    /// </summary>
    public partial class UserTransfersWindow : Window
    {
        public UserTransfersWindow()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<Total> total = context.Totals.ToList();
                listOfBill.ItemsSource = total;
                comboBoxTransfers.ItemsSource = total;
                comboBoxTransfersSecond.ItemsSource = total;
            }


        }

        private void Send_Transfer_Click(object sender, RoutedEventArgs e)
        {
            string firstField = comboBoxTransfers.SelectedItem.ToString();
            string secondField = comboBoxTransfersSecond.Text.Trim();
            string amount = textBoxForAmount.Text.Trim();



            using (ApplicationContext context = new ApplicationContext())
            {
                DB db = new DB();

                SQLiteCommand commandPlus = new SQLiteCommand("UPDATE Totals SET totalMoney = totalMoney + @amountSpent WHERE billName = @namePlus", db.getConnection());
                commandPlus.Parameters.Add("@amountSpent", DbType.Double).Value = amount;
                commandPlus.Parameters.Add("namePlus", DbType.String).Value = secondField;


                SQLiteCommand commandMinus = new SQLiteCommand("UPDATE Totals SET totalMoney = totalMoney - @amountSpent WHERE billName = @nameMinus", db.getConnection());
                commandMinus.Parameters.Add("@amountSpent", DbType.Double).Value = amount;
                commandMinus.Parameters.Add("nameMinus", DbType.String).Value = firstField;

                db.openConnection();

                commandPlus.ExecuteNonQuery();
                commandMinus.ExecuteNonQuery();


                List<Total> total = context.Totals.ToList();
                listOfBill.ItemsSource = total;
                comboBoxTransfers.ItemsSource = total;
                comboBoxTransfersSecond.ItemsSource = total;


                textBoxForAmount.Clear();




            }



        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            comboBoxTransfers.SelectedIndex = -1;
            comboBoxTransfersSecond.SelectedIndex = -1;
            textBoxForAmount.Clear();
        }

        private void Go_To_Bill(object sender, RoutedEventArgs e)
        {
            UserBillWindow userBillWindow = new UserBillWindow();
            userBillWindow.Show();
            Hide();

        }

        private void Go_To_Costs(object sender, RoutedEventArgs e)
        {
            UserCostsWindow userCostsWindow = new UserCostsWindow();
            userCostsWindow.Show();
            Hide();
        }
    }
}