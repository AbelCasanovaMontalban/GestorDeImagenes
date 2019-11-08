using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorDeImagenes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        String[] imagenes;
        int numeroImagenActual;
        int numeroImagenTotal;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Creamos un nuevo diálogo
            System.Windows.Forms.FolderBrowserDialog dialogo = new FolderBrowserDialog();

            //Mostramos el diálogo
            DialogResult resultado = dialogo.ShowDialog();

            //Comprobamos si el usuario ha pulsado el botón Aceptar
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                //Accedemos a la ruta seleccionada por el usuario
                string ruta = dialogo.SelectedPath;
                imagenes = Directory.GetFileSystemEntries(ruta);
                numeroImagenTotal = imagenes.Length;
                numeroImagenActual = 0;
                var converter = new ImageSourceConverter();
                fotoPrincipalImage.Source =(ImageSource)converter.ConvertFromString(imagenes[0]);
            }


                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var converter = new ImageSourceConverter();
            if (numeroImagenActual==numeroImagenTotal+1)
            {
                numeroImagenActual = 0;
                fotoPrincipalImage.Source = (ImageSource)converter.ConvertFromString(imagenes[numeroImagenActual]);
            }
            else
            {
                fotoPrincipalImage.Source = (ImageSource)converter.ConvertFromString(imagenes[numeroImagenActual + 1]);
                numeroImagenActual++;
            }
            
        }
    }
}
