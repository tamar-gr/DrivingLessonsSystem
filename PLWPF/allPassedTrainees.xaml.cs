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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for allPassedTrainees.xaml
    /// </summary>
    public partial class allPassedTrainees : Window
    {
        Ibl bl;
        public allPassedTrainees()
        {
            InitializeComponent();
            bl= FactoryBL.GetBL();
            List<BE.Trainee> passedTrainees =bl. getAllPassedTraineesDay();
            this.dataGrid.ItemsSource = passedTrainees;
            ListCollectionView collection = new ListCollectionView(bl.getAllPassedTraineesDay());
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Firstname"));
            this.dataGrid.ItemsSource = collection;
         

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            
            TraineeFunctions m = new TraineeFunctions();
            this.Close();
            m.Show();
        }
    }
}
