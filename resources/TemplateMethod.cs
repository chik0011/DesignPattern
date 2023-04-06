using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.TemplateMethod
{
    public class Commande
    {
        protected double montantHt;
        protected double montantTva;
        protected double montantTTC;

        public Commande(float montantHt) {
            this.montantHt = montantHt;
            this.montantTTC = 0;
            this.montantTva = 0;
        }

        public double calculeMontantTTC() {
            this.montantTTC = this.montantTva + this.montantHt;
            return this.montantTTC;
        }

        public void affiche() {
            Console.WriteLine("Montant HT : " + this.montantHt);
            Console.WriteLine("Montant TTC : " + this.montantTTC);
            Console.WriteLine("Montant TVA : " + this.montantTva);
        }
        
        public virtual void calculeTva() {}
    }

    class CommandeFrance : Commande
    {
        public CommandeFrance(float montantHt) : base(montantHt) {}

        public override void calculeTva()
        {
            this.montantTva = this.montantHt*0.196;
            Console.WriteLine("TVA France : " + this.montantTva);
        }
    }

    class CommandeLuxembourg : Commande
    {
        public CommandeLuxembourg(float montantHt) : base(montantHt) {}

        public override void calculeTva()
        {
            this.montantTva = this.montantHt*0.15;
            Console.WriteLine("TVA Luxembourg : " + this.montantTva);
        }
    }
}
