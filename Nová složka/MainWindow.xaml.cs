using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace projekt_velky
{
    public partial class MainWindow : Window
    {
        // Stav hry
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
                // =========================
                // OBRAZ
                // =========================
                case "obraz":

                    if (!obrazProhledan)
                    {
                        obrazProhledan = true;

                        txtLog.Text = "Pankrác: Hmm... za obrazem jsou nějaké klíče.";

                        // změní pozadí
                        pozadi.Source = new BitmapImage(
                            new Uri("pack://application:,,,/Images/odsunutamonalisasklicema.jpg"));

                        // ukáže hotspot na klíče
                        btnKlice.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        txtLog.Text = "Pankrác: Obraz už jsem odsunul.";
                    }

                    break;

                // =========================
                // KLÍČE
                // =========================
                case "klice":

                    if (!mamKlic)
                    {
                        mamKlic = true;

                        txtLog.Text = "Pankrác: Vzal jsem si klíče.";

                        // změní pozadí na verzi bez klíčů
                        pozadi.Source = new BitmapImage(
                            new Uri("pack://application:,,,/Images/odsunutamonalisabezklicu.jpg"));

                        // schová hotspot klíčů
                        btnKlice.Visibility = Visibility.Hidden;
                    }

                    break;

                // =========================
                // POČÍTAČ
                // =========================
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

                // =========================
                // SKŘÍŇ
                // =========================
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

                // =========================
                // DVEŘE
                // =========================
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
                    }
                    else
                    {
                        txtLog.Text = "Pankrác: Neměl bych odejít, dokud to tu neprohledám.";
                    }

                    break;
            }
        }
    }
}