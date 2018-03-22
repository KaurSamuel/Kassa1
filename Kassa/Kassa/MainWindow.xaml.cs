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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kassa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Tootekogusint { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            List<Toode> Tooted = new List<Toode>();
            Tooted.Add(new Toode() { Name = "Salat", Hind = 10, Kogus = 5 });
            Tooted.Add(new Toode() { Name = "Kohvi", Hind = 15, Kogus = 4 });
            TootedListBox.ItemsSource = Tooted;
            Tootekogusint = 0;
            
            
        }
        private void vähendakogust_Click(object sender, RoutedEventArgs e)
        {
            Tootekogusint -=1;
            string Tootekogus = Tootekogusint.ToString();
            mitutootet.Text = Tootekogus;
        }

        private void suurendakogust_Click(object sender, RoutedEventArgs e)
        {
            Tootekogusint +=1;
            string Tootekogus = Tootekogusint.ToString();
            mitutootet.Text = Tootekogus;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tootekogusint -= 5;
            string Tootekogus = Tootekogusint.ToString();
            mitutootet.Text = Tootekogus;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tootekogusint += 5;
            string Tootekogus = Tootekogusint.ToString();
            mitutootet.Text = Tootekogus;
        }
    }
}
