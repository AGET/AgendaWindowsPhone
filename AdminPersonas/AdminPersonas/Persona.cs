/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;*/
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;


namespace AdminPersonas
{
    [Table(Name = "Persona")]
    public class Persona
    {
        private int id_Persona;
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true,
        CanBeNull = false)]
        public int id_persona
        {
            get { return id_Persona; }
            set { id_Persona = value; }
        }
        private string Nombre_Persona;
        [Column(CanBeNull = true)]
        public string nombre_persona
        {
            get { return Nombre_Persona; }
            set { Nombre_Persona = value; }
        }
        private string Apellido_Persona;
        [Column(CanBeNull = true)]
        public string apellido_persona
        {
            get { return Apellido_Persona; }
            set { Apellido_Persona = value; }
        }
        private string Edad_Persona;
        [Column(CanBeNull = true)]
        public string edad_persona
        {
            get { return Edad_Persona; }
            set { Edad_Persona = value; }
        }
        private string Fecha_Hora;
        [Column(CanBeNull = true)]
        public string fecha_hora
        {
            get { return Fecha_Hora; }
            set { Fecha_Hora = value; }
        }

    }
}