using MyWallet_2._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyWallet_2._0.Helpers
{
    public class StatisticCategories
    {
        public double Amount { get; set; }

        public string CatName { get; set; }



    }
    class StatisticsByDay
    {



        public void ByDay(ListView listView)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<IncomeCategory> categories = context.IncomeCategories.ToList();
                int countCat = categories.Count + 1;

                SQLiteDataReader reader = null;
                DB db = new DB();

                for (int i = 1; i < countCat; i++)
                {
                    SQLiteCommand command = new SQLiteCommand("SELECT SUM(us.amountSpent), cat.categoryName FROM UserIncomes AS us INNER JOIN IncomeCategories AS cat ON us.categoryId = cat.id WHERE us.categoryId = @categoryId AND date(us.CreatedAt) = CURRENT_DATE  ", db.getConnection());
                    command.Parameters.Add("@categoryId", DbType.Int32).Value = i;

                    db.openConnection();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string sum = Convert.ToString(reader["SUM(us.amountSpent)"]);
                        string name = Convert.ToString(reader["categoryName"]);
                        if (sum != "")
                        {
                            listView.Items.Add(new StatisticCategories { Amount = Convert.ToDouble(sum), CatName = name });

                        }
                    }
                }
            }
        }
        public void ByMonth(ListView listView)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<IncomeCategory> categories = context.IncomeCategories.ToList();
                int countCat = categories.Count + 1;

                SQLiteDataReader reader = null;
                DB db = new DB();

                for (int i = 1; i < countCat; i++)
                {
                    SQLiteCommand command = new SQLiteCommand("SELECT SUM(us.amountSpent), cat.categoryName FROM UserIncomes AS us INNER JOIN IncomeCategories AS cat ON us.categoryId = cat.id WHERE us.categoryId = @categoryId AND strftime('%m',us.CreatedAt) = strftime('%m',date('now')) AND strftime('%Y',us.CreatedAt) = strftime('%Y',date('now'))  ", db.getConnection());
                    command.Parameters.Add("@categoryId", DbType.Int32).Value = i;

                    db.openConnection();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string sum = Convert.ToString(reader["SUM(us.amountSpent)"]);
                        string name = Convert.ToString(reader["categoryName"]);
                        if (sum != "")
                        {
                            listView.Items.Add(new StatisticCategories { Amount = Convert.ToDouble(sum), CatName = name });

                        }
                    }
                }
            }

            
            
        }
        public void ByYear(ListView listView)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<IncomeCategory> categories = context.IncomeCategories.ToList();
                int countCat = categories.Count + 1;

                SQLiteDataReader reader = null;
                DB db = new DB();

                for (int i = 1; i < countCat; i++)
                {
                    SQLiteCommand command = new SQLiteCommand("SELECT SUM(us.amountSpent), cat.categoryName FROM UserIncomes AS us INNER JOIN IncomeCategories AS cat ON us.categoryId = cat.id WHERE us.categoryId = @categoryId AND strftime('%Y',CreatedAt) = strftime('%Y',date('now'))  ", db.getConnection());
                    command.Parameters.Add("@categoryId", DbType.Int32).Value = i;

                    db.openConnection();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string sum = Convert.ToString(reader["SUM(us.amountSpent)"]);
                        string name = Convert.ToString(reader["categoryName"]);
                        if (sum != "")
                        {
                            listView.Items.Add(new StatisticCategories { Amount = Convert.ToDouble(sum), CatName = name });

                        }
                    }
                }
            }

            
        }
    }
}
