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
using System.Data.Linq;
namespace AdminPersonas
{
    public class EjemploDataContext: DataContext
    {
        public Table<Persona> people; 
        private EjemploDataContext(string connectionString):base(connectionString) 
        {
        }
        private static EjemploDataContext Ejedatacontext = null;
        public static EjemploDataContext current
        {
            get
            {
                if (Ejedatacontext==null)
                {
                    Ejedatacontext=new EjemploDataContext("isostore:/BD_Personas.sdf");
                    if (!Ejedatacontext.DatabaseExists())
                    {
                        Ejedatacontext.CreateDatabase();
                    }
                }
                return Ejedatacontext;
            }
        }
    }
}