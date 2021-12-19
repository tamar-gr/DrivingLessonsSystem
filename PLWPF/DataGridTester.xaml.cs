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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DataGridTester.xaml
    /// </summary>
    public partial class DataGridTester : Window
    {
        BL.Ibl bl;
        public DataGridTester(List<Tester> testers1 = null, IEnumerable<Tester> testers2 = null)
        {

            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            if (testers1 != null)
                this.dataGridTesters.ItemsSource = testers1;
            else if (testers2 != null)
                this.dataGridTesters.ItemsSource = testers2;
            else
                this.dataGridTesters.ItemsSource = bl.getTestersList();
            this.txtShowTester.Name = "Testers";
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TesterMenu menu = new TesterMenu();
            this.Close();
            menu.Show();
        }

        private void dataGridTesters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridTesters.SelectedItems == null)
                return;
            var selectedTesters = dataGridTesters.SelectedItem as Tester;
            tester myTester = new tester("View", selectedTesters.ID);
            this.Close();
            myTester.Show();

        }

        
    }
}
