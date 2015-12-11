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
    public partial class Modificar : PhoneApplicationPage
    {
        Persona antiguo;
        public Modificar()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Modificar_Loaded);
        }
        void Modificar_Loaded(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona();
            string id = NavigationContext.QueryString["id"];
            int Id = Convert.ToInt32(id);
            antiguo = this.obtenerDatos(Id);
            textbox1.Text = antiguo.nombre_persona;
            textbox2.Text = antiguo.apellido_persona;
            textBox3.Text = antiguo.edad_persona;
        }
        public Persona obtenerDatos(int codigo)
        {
            var query = from Persona in EjemploDataContext.current.people
                        where Persona.id_persona == codigo
                        select Persona;
            return query.ToList()[0];
        }
        public void modificarDatos(Persona antigua, Persona nueva)
        {
            contenedor conte = new contenedor(); 
            conte.CObsCollection.Remove(antigua);
            conte.CObsCollection.Add(nueva);
            EjemploDataContext.current.people.DeleteOnSubmit(antigua);
            EjemploDataContext.current.people.InsertOnSubmit(nueva);
            EjemploDataContext.current.SubmitChanges();
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (textbox1.Text != string.Empty.Trim() && textbox2.Text != string.Empty.Trim() && textBox3.Text != string.Empty.Trim()){
                try
                {
                    Persona nuevo = new Persona()
                    {
                        nombre_persona = textbox1.Text.Trim(),
                        apellido_persona = textbox2.Text.Trim(),
                        edad_persona = textBox3.Text.Trim(),
                        fecha_hora = DateTime.Now.ToString()
                    };
                    this.modificarDatos(antiguo, nuevo);
                    textbox1.Text = string.Empty;
                    textbox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    MessageBox.Show("Dato modificado exitosamente.");
                    NavigationService.GoBack();
                }catch (Exception)
                {
                    MessageBox.Show("no se pudo modificar los datos");
                }
            }else
            {
                MessageBox.Show("los campos no deben estar vacios");
            }
        }
    }
}