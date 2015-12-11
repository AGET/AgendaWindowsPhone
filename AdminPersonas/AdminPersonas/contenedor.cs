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
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace AdminPersonas
{
    public class contenedor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Persona> CObsCollection = new
        ObservableCollection<Persona>();
        public Persona CPersonaSelected = new Persona();
        public void NotifyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public ObservableCollection<Persona> PObsCollection
        {
            get { return CObsCollection; }
            set
            {
                CObsCollection = value;
                NotifyChanged("PObsCollection");
            }
        }
        public Persona PPersonaSelected
        {
            get { return CPersonaSelected; }
            set
            {
                CPersonaSelected = value;
                NotifyChanged("PPersonaSelected");
            }
        }
    }
}