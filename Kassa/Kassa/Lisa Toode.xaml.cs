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
using System.Text.RegularExpressions;

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
            
            System.IO.File.AppendAllText("../../Tooted.txt", "\n"+ TootenimiTB.Text
                + " " + TootehindTB.Text);
            MessageBox.Show("Toode lisatud ärge unustage refreshida");
            return;
            
        }

        private void TootehindTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }
    }
    
}
