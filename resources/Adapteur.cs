using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Adapter
{
    interface Document
    {
        void setContenu(string setContenu);
        string dessine();

        void imprime();
    }

    public class DocumentHtml : Document
    {
        public string contenu;

        public string getContenue() {
            Console.WriteLine("Voici le contenu HTML " + this.contenu);
            return this.contenu;
        }

        public void setContenu(string contenu) {
            this.contenu = contenu;
        }

        public string dessine() {
            Console.WriteLine("Votre dessin HTML <h1>:)</h1>");
            return "<h1>:)</h1>";
        }

        public void imprime() {
            Console.WriteLine("Impression en cours ...");
        }
    }
}
