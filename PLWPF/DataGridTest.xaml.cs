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
    /// Interaction logic for DataGridTest.xaml
    /// </summary>
    public partial class DataGridTest : Window
    {
        BL.Ibl bl;

        public DataGridTest(List<Test> tests1=null, IEnumerable<Test> tests2 = null)
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            if (tests1 != null)
                this.dataGridTests.ItemsSource = tests1;
            else if (tests2 != null)
                this.dataGridTests.ItemsSource = tests2;
            else
                this.dataGridTests.ItemsSource = bl.getTestsList();
            this.txtShowTests.Name = "Tests";
        }
        private void DataGridTest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (dataGridTests.SelectedItems == null)
                                        return;
            var selectedTests = dataGridTests.SelectedItem as BE.Test;
            test myTest = new test("View", selectedTests.numOfTest);
            this.Close();
            myTest.Show();


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TestMenu menu = new TestMenu();
            this.Close();
            menu.Show();
        }

     
    }
}
