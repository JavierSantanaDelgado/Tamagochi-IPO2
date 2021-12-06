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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tamagochi
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string nombre;
        System.Windows.Threading.DispatcherTimer t1;
        double decremneto = 1;
        int contJuego = 0;
        int contComida = 0;
        int contEnergia = 0;
        int contador = 0;
        Boolean semaforoDiversion = false;
        Boolean semaforoEnergia = false;
        Boolean semaforoAlimento = false;
        Boolean semaforoGeneral = false;
        public MainWindow()
        {
            InitializeComponent();
            VentanaBienvenida pantallaIncio = new VentanaBienvenida(this);
            pantallaIncio.ShowDialog();
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(1000.0);
            t1.Tick += new EventHandler(reloj);

        }
        private void reloj(object sender, EventArgs e)
        {
            contador++;
            this.pbEnergia.Value -= decremneto;
            this.pbDiversion.Value -= decremneto;
            this.pbAlimento.Value -= decremneto;
            
            Storyboard sttriste = (Storyboard)this.Resources["animacionTriste"];
            Storyboard stDesenfado = (Storyboard)this.Resources["animacionDesenfado"];
            Storyboard stEnfado = (Storyboard)this.Resources["animacionEnfado"];
            Storyboard stHambriento = (Storyboard)this.Resources["animacionHambriento"];
            Storyboard stNoHambriento = (Storyboard)this.Resources["animacionNoHambriento"];
            Storyboard stNoTriste = (Storyboard)this.Resources["animacionNoTriste"];

            if (pbDiversion.Value <= 40)
            {
                if (semaforoDiversion == false && semaforoGeneral == false)
                {
                    semaforoDiversion = true;
                    semaforoGeneral = true;
                    stEnfado.Begin();
                }

            }
            else if (pbDiversion.Value >= 50)
            {
                if (semaforoDiversion == true)
                {
                    stDesenfado.Begin();
                    semaforoDiversion = false;

                    semaforoGeneral = false;
                    //semaforoAlimento = true;
                    //semaforoEnergia = true;
                }

            }
            else
            {

            }
            if (pbEnergia.Value <= 40 && semaforoGeneral == false)
            {
                if(semaforoEnergia == false )
                {
                    sttriste.Begin();
                    semaforoEnergia = true;

                    semaforoGeneral = true;
                }

            }
            else if (pbEnergia.Value >= 50 )
            {
                if (semaforoEnergia == true)
                {
                    stNoTriste.Begin();
                    semaforoEnergia = false;

                    semaforoGeneral = false;
                }

            }
            else
            {

            }
            if(pbAlimento.Value <= 40 && semaforoGeneral == false)
            {
                if (semaforoAlimento == false)
                {
                    stHambriento.Begin();
                    semaforoAlimento = true;

                    semaforoGeneral = true;
                }

            } else if(pbAlimento.Value > 50){
                if(semaforoAlimento == true)
                {
                    stNoHambriento.Begin();
                    semaforoAlimento = false;

                    semaforoGeneral = false;
                }

            }else
            {

            }
            if (contador == 15 || contador == 40 || contador == 60)
            {
                Storyboard stsombrero = (Storyboard)this.Resources["animacionSombrero"];
                stsombrero.Begin();
            }
            if (contComida == 20)
            {
                imLogroComida.Opacity = 100;
                contComida++;
                MessageBox.Show("Enhorabuena has conseguido el Logro 'Comida Feliz'");
            }
            if (contJuego == 10)
            {
                imLogroFeliz.Opacity = 100;
                contJuego++;
                MessageBox.Show("Enhorabuena has conseguido el Logro 'Jugando espero'");
            }
            if (contJuego == 15)
            {
                imCuernoMini.Opacity = 100;
                imCuernoMini.IsEnabled = true;
                imCuernoMini.Visibility = Visibility.Visible;
                imChooper.Opacity = 100;
                contJuego++;
                MessageBox.Show("Enhorabuena has conseguido el Premio y el Coleccionable 'Ser como chooper'");
            }
            if (contador == 18)
            {
                imFondoWano.Opacity = 100;
                imFondoWano.IsEnabled = true;
                imFondoWano.Visibility = Visibility.Visible;
                imPremioFondo.Opacity = 100;
                contador++;
                MessageBox.Show("Enhorabuena has conseguido el Premio y el Coleccionable 'Cambiar fondo'");
            }
            if (contEnergia == 10)
            {
                imTraje.Opacity = 100;
                imPajaritaFormaMini.IsEnabled = true;
                imPajaritaFormaMini.Visibility = Visibility.Visible;
                imPajaritaFormaMini.Opacity = 100;
                contEnergia++;
                MessageBox.Show("Enhorabuena has conseguido el Premio y el Coleccionable 'Elegancia'");
            }
            if (contComida == 10)
            {
                imGuanteMini.Opacity = 100;
                imGuanteMini.IsEnabled = true;
                imGuanteMini.Visibility = Visibility.Visible;
                imPremioGuantes.Opacity = 100;
                contComida++;
                MessageBox.Show("Enhorabuena has conseguido el Premio y el Coleccionable 'Échame un guante'");
            }
            if (pbEnergia.Value <= 0 || pbAlimento.Value <= 0 || pbDiversion.Value <= 0)
            {
                t1.Stop();
                //this.lblGameOver.Visibility = Visibility.Visible;
                //this.lblPuntuacion.Visibility = Visibility.Visible;
                String resultado = "" + contador;
                //this.lblPuntuacion.Content = "Tu puntuacion final es " + resultado;
                this.btnAlimentar.IsEnabled = false;
                this.btnDescansar.IsEnabled = false;
                this.btnJugar.IsEnabled = false;

                MessageBoxResult pregunta = MessageBox.Show("Tu puntuación ha sido "+resultado+"\n¿Desea volver a jugar?", "Game Over", MessageBoxButton.YesNo);

                switch (pregunta)
                {
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                    case MessageBoxResult.Yes:
                        recargar();
                        break;
                }

            }

        }
        private void recargar()
        {
            this.pbAlimento.Value = 50;
            this.pbDiversion.Value = 50;
            this.pbEnergia.Value = 50;
            btnEmpezar.IsEnabled = true;
            btnAlimentar.IsEnabled = true;
            btnDescansar.IsEnabled = true;
            btnJugar.IsEnabled = true;
            contador = 0;
            semaforoDiversion = false;
            semaforoEnergia = false;
            semaforoAlimento = false;
            semaforoGeneral = false;
            Storyboard stDesenfado = (Storyboard)this.Resources["animacionDesenfado"];
            Storyboard stNoHambriento = (Storyboard)this.Resources["animacionNoHambriento"];
            Storyboard stNoTriste = (Storyboard)this.Resources["animacionNoTriste"];
            stDesenfado.Begin();
            stNoHambriento.Begin();
            stNoTriste.Begin();
            t1.Start();
        }
        private void btnEmpezar_Click_1(object sender, RoutedEventArgs e)
        {
            t1.Start();
            this.btnAlimentar.IsEnabled = true;
            this.btnDescansar.IsEnabled = true;
            this.btnJugar.IsEnabled = true;
            this.btnEmpezar.IsEnabled = false;
        }

        private void btnDescansar_Click(object sender, RoutedEventArgs e)
        {
            this.pbEnergia.Value += 10;
            contEnergia++;
            decremneto += 0.05;

            //DoubleAnimation cerrarOjoderecho = new DoubleAnimation();
            //DoubleAnimation cerrarPupiladerechar = new DoubleAnimation();
            ////cerrarOjoderecho.From = this.OjoDerecho.Height;
            //cerrarOjoderecho.To = this.OjoDerecho.Height / 2;
            //cerrarOjoderecho.Duration = new Duration(TimeSpan.FromSeconds(1));
            //cerrarOjoderecho.AutoReverse = true;
            ////cerrarPupiladerechar.To = this.PupilaDerecha.Height;
            //cerrarPupiladerechar.To = this.PupilaDerecha.Height / 4;
            //cerrarPupiladerechar.Duration = new Duration(TimeSpan.FromSeconds(1));
            //cerrarPupiladerechar.AutoReverse = true;
            //cerrarOjoderecho.Completed += new EventHandler(finCerrarOjoDer);
            //OjoDerecho.BeginAnimation(Ellipse.HeightProperty, cerrarOjoderecho);
            //PupilaDerecha.BeginAnimation(Ellipse.HeightProperty, cerrarPupiladerechar);

            //DoubleAnimation cerrarOjoizquierdo = new DoubleAnimation();
            //DoubleAnimation cerrarPupilaizquierda = new DoubleAnimation();
            ////cerrarOjoderecho.From = this.OjoDerecho.Height;
            //cerrarOjoizquierdo.To = this.OjoIzquierdo.Height / 2;
            //cerrarOjoizquierdo.Duration = new Duration(TimeSpan.FromSeconds(1));
            //cerrarOjoizquierdo.AutoReverse = true;

            ////cerrarPupiladerechar.To = this.PupilaDerecha.Height;
            //cerrarPupilaizquierda.To = this.PupilaIzquierda.Height / 4;
            //cerrarPupilaizquierda.Duration = new Duration(TimeSpan.FromSeconds(1));
            //cerrarPupilaizquierda.AutoReverse = true;
            //OjoIzquierdo.BeginAnimation(Ellipse.HeightProperty, cerrarOjoizquierdo);
            //PupilaIzquierda.BeginAnimation(Ellipse.HeightProperty, cerrarPupilaizquierda);
            Storyboard stdescansar = (Storyboard)this.Resources["animacionDescansar"];
            
            stdescansar.Completed += new EventHandler(finDescansar);
            stdescansar.Begin();
            this.btnDescansar.IsEnabled = false;
            btnAlimentar.IsEnabled = false;
            btnJugar.IsEnabled = false;
        }

        private void finCerrarOjoDer(object sender, EventArgs e)
        {
            btnDescansar.IsEnabled = true;
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            
            this.pbDiversion.Value += 10;
            contJuego++;
            Storyboard stJugar = (Storyboard)this.Resources["animacionJuego"];
            decremneto +=0.05;
            stJugar.Completed += new EventHandler(finJuego);
            stJugar.Begin();
            btnJugar.IsEnabled = false;
            
            btnAlimentar.IsEnabled = false;
            btnDescansar.IsEnabled = false;
            
        }

        private void btnAlimentar_Click(object sender, RoutedEventArgs e)
        {
            contComida++;
            this.pbAlimento.Value += 10;
            Storyboard staux = (Storyboard)this.Resources["animacionComer"];
            staux.Completed += new EventHandler(finComer);
            decremneto += 0.05;
            staux.Begin();
            btnAlimentar.IsEnabled = false;
            btnDescansar.IsEnabled = false;
            btnJugar.IsEnabled = false;
            

        }

        private void finComer(object sender, EventArgs e)
        {
            btnAlimentar.IsEnabled = true;
            btnDescansar.IsEnabled = true;
            btnJugar.IsEnabled = true;
            this.Chooper.Visibility = Visibility.Hidden;
        }
        private void finJuego(object sender, EventArgs e)
        {
            btnJugar.IsEnabled = true;
            btnDescansar.IsEnabled = true;
            btnAlimentar.IsEnabled = true;
        }
        private void finDescansar(object sender, EventArgs e)
        {
            btnDescansar.IsEnabled = true;
            btnJugar.IsEnabled = true;
            btnAlimentar.IsEnabled = true;
        }

        private void cambiarFondo(object sender, MouseButtonEventArgs e)
        {
            ImageSource anterior = imFondo.Source;
            this.imFondo.Source = ((Image)sender).Source; //imFondoVolcan.Source;
            this.imFondoWano.Source = anterior;
            //this.imVolcan.Source = imFondo.Source;
        }

        private void acercaDe(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Programa realizado por \n \nJavier Santana\n\n ¿Desea salir de la aplicación?", "Acerca De", MessageBoxButton.YesNo);

            switch(result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
            }
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
            tbBienvenido.Text = "Bienvenido " + nombre;
            
        }

        private void inicioArrastrarColeccionable(object sender, MouseButtonEventArgs e)
        {
            DataObject dobj = new DataObject((Image)sender);
            DragDrop.DoDragDrop((Image)sender, dobj, DragDropEffects.Move);
        }

        private void colocarColeccionable(object sender, DragEventArgs e)
        {
            Image aux = (Image)e.Data.GetData(typeof(Image));
            switch (aux.Name)
            {
                case "imCuernoMini":
                    imCuernosReno.Visibility = Visibility.Visible;
                    break;
                case "imPajaritaFormaMini":
                    cvPajarita.Visibility = Visibility.Visible;
                    break;
                case "imGuanteMini":
                    cvGuantes.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void eventoSombrero(object sender, MouseButtonEventArgs e)
        {
            pbAlimento.Value = 100;
            pbDiversion.Value = 100;
            pbEnergia.Value = 100;
        }
    }
}
