using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Strategy
{
    interface DessinCatalogue {
        List<string> dessine(List<string> dessin);
    }

    class DessinUnVehiculeLigne : DessinCatalogue
    {
        public List<string> dessine(List<string> dessin)
        {
            foreach(string chaine in dessin)
            {
                Console.WriteLine(chaine);
            }

            return dessin;
        }
    }

    class DessinTroisVehiculesLigne : DessinCatalogue
    {
        public List<string> dessine(List<string> dessin)
        {
            var res = "";

            foreach(string chaine in dessin)
            {
                res += chaine + " ";
            }

            Console.WriteLine(res);

            return dessin;
        }
    }

    class VueCatalogue 
    {
        private readonly DessinCatalogue dessin;

        public VueCatalogue(DessinCatalogue dessinCat)
        {
            dessin = dessinCat;
        }

        public List<string> dessine(List<string> lstDessin)
        {
            Console.WriteLine("La liste des dessins");
            return dessin.dessine(lstDessin);
        }
    }

}
