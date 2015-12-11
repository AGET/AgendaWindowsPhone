using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;




namespace AdminPersonas
{
    public partial class MostrarDatos : PhoneApplicationPage
    {
        public static contenedor content { set; get; }
        public MostrarDatos()
        {
            content = new contenedor();
            InitializeComponent();
            this.Loaded += (s, a) =>
            {
                this.mostrarDatos(ListPersonas);
            };
        }
        public void mostrarDatos(ListBox lista)
        { 
            var query = from Persona in EjemploDataContext.current.people orderby Persona.nombre_persona select Persona;
            content.PObsCollection = new  ObservableCollection<Persona>(query.ToList());
            lista.ItemsSource = content.PObsCollection;
        } 
        private void Eliminar_Click(object sender, EventArgs e)
        {
            Persona persona = ListPersonas.SelectedItem as Persona;
            if (ListPersonas.SelectedItem!=null)
            {
                try
                {
                    content.CObsCollection.Remove(persona);
                    EjemploDataContext.current.people.DeleteOnSubmit(persona);
                    EjemploDataContext.current.SubmitChanges();
                    MessageBox.Show("Se eliminó correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo eliminar el dato");
                }
            }
        }
        private void Modificar_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Modificar.xaml?id=" + 
                (ListPersonas.SelectedItem as Persona).id_persona,
                UriKind.RelativeOrAbsolute));
        }

        private void ListPersonas_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        } 
    }
}