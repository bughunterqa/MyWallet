using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MyWallet_2._0.Helpers
{
    class Sorting
    {

        public void SortDesc(ListView listview)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listview.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CreatedAt", ListSortDirection.Descending));
        }
    }
}
