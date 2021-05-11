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
using System.Data.Entity;
using System.Data.SQLite;
using System.Data;

namespace MyWallet_2._0
{

    public partial class AllCategoriesWindow : Window
    {
        public AllCategoriesWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {


                List<Category> categories = context.Categories
                    .Include(c => c.Image)
                    .ToList();
                listOfCategories.ItemsSource = categories;

            }


            removeBtn.Background = Brushes.LightCoral;
            createBtn.Background = Brushes.LightGreen;
        }

        private void Back_To_Costs(object sender, RoutedEventArgs e)
        {
            UserCostsWindow userCosts = new UserCostsWindow();
            userCosts.Show();
            Hide();
        }

        private void Add_New_Category(object sender, RoutedEventArgs e)
        {
            CreateCategoryWindow createCategory = new CreateCategoryWindow();
            createCategory.Show();
            Hide();
        }

        private void Remove_Category(object sender, RoutedEventArgs e)
        {
            string getCategoryId;
            if (listOfCategories.SelectedIndex > -1)
            {
                getCategoryId = listOfCategories.SelectedItems[0].ToString();
            }
            else
            {
                MessageBox.Show("Выберите категорию!");
                return;
            }

            using (ApplicationContext context = new ApplicationContext())
            {
                DB db = new DB();


                SQLiteCommand command = new SQLiteCommand(" DELETE FROM Categories WHERE id = @id", db.getConnection());
                command.Parameters.Add("@id", DbType.Int32).Value = Convert.ToInt32(getCategoryId);

                db.openConnection();
                command.ExecuteNonQuery();
                

                List<Category> categories = context.Categories
                    .Include(c => c.Image)
                    .ToList();
                listOfCategories.ItemsSource = categories;
            }

        }
    }
}
