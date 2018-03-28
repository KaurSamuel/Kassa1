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
using System.Text.RegularExpressions;

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
            List<Toode> failist_tooted = new List<Toode>();
            foreach (var line in System.IO.File.ReadAllLines("../../Tooted.txt"))
            {
                if (line != ""&& line!=" ")
                {
                    failist_tooted.Add(new Toode()
                    {
                        Name = line.Split(' ')[0],
                        Hind = decimal.Parse(line.Split(' ')[1]),
                    });
                }
            }                   
            TootedListBox.ItemsSource = failist_tooted;
           
        }
        public void Refresh_tooted()
        {
            List<Toode> failist_tooted = new List<Toode>();
            foreach (var line in System.IO.File.ReadAllLines("../../Tooted.txt"))
            {
                if (line !=""&& line !=" ")
                {
                    failist_tooted.Add(new Toode()
                    {
                        Name = line.Split(' ')[0],
                        Hind = decimal.Parse(line.Split(' ')[1]),
                    });
                }
            }
            TootedListBox.ItemsSource = failist_tooted;
        }

        //-----------------------------------------------------
        #region buttons 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Lisa_ostukorvi();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Ostukorv.Items.Remove(Ostukorv.SelectedItem);
            
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Refresh_tooted();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Lisa_Toode win2 = new Lisa_Toode();
            win2.Show();
        }
        #endregion
        public string Removing_productname;
        public string Removing_productprice;
        public string Removing_productquantity;
        public string Removing_product;
        // isegi jumal ei tea mida ma siin tegin
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (TootedListBox.SelectedItem == null)
            {
                MessageBox.Show("Palun valige toode mida eemaldada");
            }
            else
            {
                foreach (var item in TootedListBox.SelectedItems)
                {
                    Removing_productname = (item as Toode).Name;
                    Removing_productprice = (item as Toode).Hind.ToString();
                    Removing_product = Removing_productname +" "+ 
                        Removing_productprice;

                }
                string[] linesar = System.IO.File.ReadAllLines("../../Tooted.txt");
                List<string> linesL = new List<string>(linesar.ToList());
                linesL.Remove(Removing_product);
                System.IO.File.WriteAllLines("../../Tooted.txt", linesL);
                Refresh_tooted();
            }
        }
        public void Lisa_ostukorvi()
        {
            if (TootedListBox.SelectedItem == null)
            {
                MessageBox.Show("Palun valige toode");
            }
            else if (Ostukorv.Items.Contains(TootedListBox.SelectedItem))
            {
                MessageBox.Show("See toode on juba ostukorvis");
            }
            else
            {
                var lisatav_toode = TootedListBox.SelectedItem as Toode;
                lisatav_toode.Kogus = int.Parse(KogusTB.Text);
                Ostukorv.Items.Add(lisatav_toode);
            }
        }

        private void KogusTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal base_hind = 0;
            foreach (Toode item in Ostukorv.Items)
            {
                base_hind += item.Hind*item.Kogus;
            }
            MessageBox.Show("Ostukorv läheb maksma: "+base_hind.ToString()+ "€");
        }   
    }
}
