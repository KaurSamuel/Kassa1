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
                // ma tahan surra
                failist_tooted.Add(new Toode() { Name = line.Split(' ')[0],
                    Hind = decimal.Parse(line.Split(' ')[1]),
                    Kogus = int.Parse(line.Split(' ')[2]) });
            }                   
            TootedListBox.ItemsSource = failist_tooted;
           
        }
        public void Refresh_tooted()
        {
            List<Toode> failist_tooted = new List<Toode>();
            foreach (var line in System.IO.File.ReadAllLines("../../Tooted.txt"))
            {
                // I deserve to die
                failist_tooted.Add(new Toode()
                {
                    Name = line.Split(' ')[0],
                    Hind = decimal.Parse(line.Split(' ')[1]),
                    Kogus = int.Parse(line.Split(' ')[2])
                });
            }
            TootedListBox.ItemsSource = failist_tooted;
        }

        //-----------------------------------------------------
        #region buttons 


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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Tootekogusint += 5;
            string Tootekogus = Tootekogusint.ToString();
            mitutootet.Text = Tootekogus;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
                Ostukorv.Items.Add(TootedListBox.SelectedItem); 
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
        // isegi jumal ei tea mida ma siin tegin
        public string Removing_productname;
        public string Removing_productprice;
        public string Removing_productquantity;
        public string Removing_product;
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
                    Removing_productquantity = (item as Toode).Kogus.ToString();
                    Removing_product = Removing_productname +" "+ 
                        Removing_productprice +" "+ Removing_productquantity;

                }
                string[] linesar = System.IO.File.ReadAllLines("../../Tooted.txt");
                List<string> linesL = new List<string>(linesar.ToList());
                linesL.Remove(Removing_product);
                System.IO.File.WriteAllLines("../../Tooted.txt", linesL);
                MessageBox.Show("Toode eemaldatud Ärge unustage refreshida");

            }
        }
    }
}
