using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Facade
{
    public class WebServiceAuto
    {
        protected Catalogue catalogue;
        protected GestionDocument gestionDocument;
        protected RepriseVehicule repriseVehicule;

        public List<double> chercheVehicule(double prixMoyen, double ecartMax) {
            this.catalogue = new Catalogue();
            return catalogue.retrouveVehicule(prixMoyen-ecartMax, prixMoyen+ecartMax);
        }
    }

    public class Catalogue
    {
        private List<double> vehicules;

        public Catalogue() {
            this.vehicules =  CreateList(5000.32, 10263.5, 9800, 2300);
        }

        public List<double> retrouveVehicule(double prixMin, double prixMax) {

            List<double> resVehicule = new List<double>();

            foreach(double vehicule in this.vehicules)
            {
                if (vehicule > prixMin && vehicule < prixMax)
                {
                    resVehicule.Add(vehicule);
                    Console.WriteLine(vehicule);
                }
            }

            return resVehicule;
        }

        List<T> CreateList<T>(params T[] values)
        {
            return new List<T>(values);
        }
    }

    public class RepriseVehicule
    {
        
    }

    public class GestionDocument
    {
        
    }

}
