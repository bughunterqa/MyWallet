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
using Image = MyWallet_2._0.Models.Image;

namespace MyWallet_2._0
{

    public partial class CreateCategoryWindow : Window
    {
        public CreateCategoryWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {


                List<Image> images = context.Images.ToList();
                listOfIcons.ItemsSource = images;

            }


            createBtn.Background = Brushes.LightGreen;

        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            string getName;
            if (textBoxCategory.Text != "")
            {
                getName = textBoxCategory.Text.Trim();
            }
            else
            {
                MessageBox.Show("Введите название!");
                return;
            }


            string getCategoryId;
            if (listOfIcons.SelectedIndex > -1)
            {
                getCategoryId = listOfIcons.SelectedItems[0].ToString();
            }
            else
            {
                MessageBox.Show("Выберите категорию!");
                return;
            }

            Category category = new Category(getName, Convert.ToInt32(getCategoryId));


            using (ApplicationContext context = new ApplicationContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();


            }
            AllCategoriesWindow allCategories = new AllCategoriesWindow();
            allCategories.Show();
            Hide();
        }

        private void Go_To_Back(object sender, RoutedEventArgs e)
        {
            AllCategoriesWindow allCategories = new AllCategoriesWindow();
            allCategories.Show();
            Hide();
        }
    }
}
