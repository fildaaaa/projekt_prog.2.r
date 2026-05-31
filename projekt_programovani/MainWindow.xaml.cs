using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace projekt_velky
{
    public partial class MainWindow : Window
    {
        private bool mamKlic = false;
        private bool obrazProhledan = false;
        private bool pocitacZapnuty = false;
        private bool skrinOtevrena = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void HerniAkce_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string akce = btn.Tag.ToString();

            switch (akce)
            {

                case "obraz":

                    if (!obrazProhledan)
                    {
                        obrazProhledan = true;

                        txtLog.Text = "Pankrác: Hmm... za obrazem jsou nějaké klíče.";

                        pozadi.Source = new BitmapImage(
                            new Uri("pack://application:,,,/Images/odsunutamonalisasklicema.jpg"));


                        btnKlice.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        txtLog.Text = "Pankrác: Obraz už jsem odsunul.";
                    }

                    break;


                case "klice":

                    if (!mamKlic)
                    {
                        mamKlic = true;

                        txtLog.Text = "Pankrác: Vzal jsem si klíče.";

                        pozadi.Source = new BitmapImage(
                            new Uri("pack://application:,,,/Images/odsunutamonalisabezklicu.jpg"));

                        btnKlice.Visibility = Visibility.Hidden;
                    }

                    break;


                case "pocitac":

                    if (!pocitacZapnuty)
                    {
                        pocitacZapnuty = true;
                        txtLog.Text = "Pankrác: Počítač chce heslo. To asi jen tak neuhodnu.";
                    }
                    else
                    {
                        txtLog.Text = "Pankrác: Pořád potřebuju heslo.";
                    }

                    break;


                case "skrin":

                    if (mamKlic)
                    {
                        if (!skrinOtevrena)
                        {
                            skrinOtevrena = true;

                            txtLog.Text = "Pankrác: Klíč funguje! Ve skříni je papír s heslem: POLDA";
                        }
                        else
                        {
                            txtLog.Text = "Pankrác: Skříň už je otevřená.";
                        }
                    }
                    else
                    {
                        txtLog.Text = "Pankrác: Skříň je zamčená. Budu potřebovat klíč.";
                    }

                    break;


                case "dvere":

                    if (skrinOtevrena)
                    {
                        txtLog.Text = "Pankrác: Super. Mám všechno potřebné a můžu odejít.";

                        pozadi.Source = new BitmapImage(new Uri("pack://application:,,,/Images/chodba.jpg"));
                        btnDvere.Visibility = Visibility.Hidden;
                        btnObraz.Visibility = Visibility.Hidden;
                        btnPocitac.Visibility = Visibility.Hidden;
                        btnSkrin.Visibility = Visibility.Hidden;
                        btnKlice.Visibility = Visibility.Hidden;
                        btnDvere_chodba.Visibility = Visibility.Visible;
                        txtLog.Text = "Pankrác: Jsem na chodbě.";
                    }
                    else
                    {
                        txtLog.Text = "Pankrác: Neměl bych odejít, dokud to tu neprohledám.";
                    }

                    break;

                case "parkoviste":
                    
                    pozadi.Source = new BitmapImage(new Uri("pack://application:,,,/Images/parkoviste.jpg"));
                    btnDvere_chodba.Visibility = Visibility.Collapsed;
                    txtLog.Text = "Podle kódu ve skříni musím jít za poldou";
                    Polda.Visibility = Visibility.Visible;

                    break;

                case "Polda":
                    txtLog.Text = "Pane Pankráci, už na vás čekám, pojďte odvezu vás na policejní stanici, nasedněte si do auta";
                    Polda.Visibility = Visibility.Hidden;
                    Auto.Visibility = Visibility.Visible;
                    break;
                case "Auto":


                    pozadi.Source = new BitmapImage(new Uri("pack://application:,,,/Images/vybouchle_auto.jpg"));
                    txtLog.Text = "Ale né, v autě byla umístěna bomba, a Pankrác byl zabit, úmysl policisty už se nikdy nedozvíme, nebo v přístím díle?";
                    break;




            }
        }
    }
}