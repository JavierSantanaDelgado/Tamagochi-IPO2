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

namespace Tamagochi
{
    /// <summary>
    /// Lógica de interacción para VentanaBienvenida.xaml
    /// </summary>
    public partial class VentanaBienvenida : Window
    {
        MainWindow padre;
        public VentanaBienvenida(MainWindow padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void enviarNombre(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbNombreTama.Text))
            {
                padre.setNombre(tbNombreTama.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("¡¡¡Debe rellenar el nombre del TAMAGOCHI!!!","Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void pulsar_enter(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                padre.setNombre(tbNombreTama.Text);
                this.Close();
            }
        }

        private void mostrar_ayuda(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bienvenido a la pantalla de inicio del Tamagochi: \n\nPrimero escriba el nombre en " +
                "el cuadro de texto marcado. \n\nUna vez escrito, puede pulsar la tecla 'ENTER' o pulse el botón 'Empezar'. \n\n\n Gracias por usar nuestro software.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
