using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace AdminPersonas
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Persona persona = new Persona();
                persona.nombre_persona = textbox1.Text;
                persona.apellido_persona = textbox2.Text;
                persona.edad_persona = textBox3.Text;
                persona.fecha_hora = DateTime.Now.ToString();
                EjemploDataContext.current.people.InsertOnSubmit(persona);
                EjemploDataContext.current.SubmitChanges();
                textbox1.Text = string.Empty;
                textbox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception)
            {
                MessageBox.Show("No se puedo almacenar los dato datos");
            }

        }

        private void buttonMostrar_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/MostrarDatos.xaml", UriKind.Relative));

        }
    }
}