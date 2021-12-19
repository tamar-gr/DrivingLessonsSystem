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

namespace PLWPF
{
    public partial class myFind : Window
    {
        BL.Ibl bl;

        public myFind()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();


        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var found = bl.findById(Convert.ToInt32(txtAnswer.Text));
                if (found is BE.Test)
                    MessageBox.Show(((BE.Test)found).ToString());

                else if (found is BE.Tester)
                    MessageBox.Show(((BE.Tester)found).ToString());
                else if (found is BE.Trainee)
                    MessageBox.Show(((BE.Trainee)found).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        private void TxtAnswer_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswer.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtAnswer.Text = txtAnswer.Text.Remove(txtAnswer.Text.Length - 1);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TraineeFunctions m = new TraineeFunctions();
            this.Close();
            m.Show();
        }



    }
}


