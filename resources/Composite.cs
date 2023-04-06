using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Composite
{
    abstract public class Societe
    {
        protected List<Societe> societes = new List<Societe>();

        public virtual void calculeCoutEntretien() {}
        public virtual void ajouteFiliale() {}
    }

    public class SocieteSansFiliale : Societe
    {
        protected Societe societe;
        protected double coutEntretient;
        public SocieteSansFiliale(double coutEntretient) {
            this.coutEntretient = coutEntretient;
        }

        public override void calculeCoutEntretien() {
            Console.WriteLine(coutEntretient);        
        }
    }

    public class SocieteMere : Societe
    {
        protected double coutEntretient;    
        protected Societe societe;    
        public SocieteMere(double coutEntretient) {
            this.coutEntretient = coutEntretient;
        }

        public void ajouteFiliale(Societe societe) {
            this.societes.Add(societe);
            Console.WriteLine("Votre filiale à était ajouté");
        }

        public void calculeCoutEntretien() {
            foreach (Societe societe in this.societes) {
                societe.calculeCoutEntretien();
            }
        }

    }

}
