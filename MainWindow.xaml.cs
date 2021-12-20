using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;

namespace Space_Invaders
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ListBoxPlayer.ItemsSource =  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:/Users/Maxime/Documents/CNAM/C#/TP3");
        }

        private void ___Button1___Apparence__Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        public void ListBoxPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Btn_ajout_joueur_Click(object sender, RoutedEventArgs e)
        {
            ListBoxPlayer.Items.Add(ajout_joueur.Text);
            ajout_joueur.Clear();
        }

        private void btn_delete_all_Click(object sender, RoutedEventArgs e)
        {
            ListBoxPlayer.Items.Clear();
        }
    }
}
