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

namespace Kassa
{
    /// <summary>
    /// Interaction logic for Lisa_Toode.xaml
    /// </summary>
    public partial class Lisa_Toode : Window
    {
        
        public Lisa_Toode()
        {
            InitializeComponent();  
        }     
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // this is getting ridiculous
            System.IO.File.AppendAllText("../../Tooted.txt", "\n"+ TootenimiTB.Text
                + " " + TootehindTB.Text + " " + TootekogusTB.Text);
            MessageBox.Show(" Toode lisatud (Ära unusta refresh-ida)");
            return;
            
        }
    }
}
