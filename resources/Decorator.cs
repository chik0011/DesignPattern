using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Decorator
{
    public interface ComposantGraphiqueVehicule {
        public string affiche();
    }

    public class VueVehicule : ComposantGraphiqueVehicule
    {
        public string affiche() {
            return "class::VueVehicule method::affiche";
        }
    }

    public abstract class Decorateur : ComposantGraphiqueVehicule
    {
        public readonly ComposantGraphiqueVehicule graphVehicule;

        public Decorateur (ComposantGraphiqueVehicule vehicule) {
            graphVehicule = vehicule;
        }

        public virtual string affiche() {
            return "class::Decorateur method::affiche";
        }
    }
    
    public class ModeleDecorateur : Decorateur
    {
        public ModeleDecorateur(ComposantGraphiqueVehicule graph):base(graph){}

        public string afficheInfosTechniques(ComposantGraphiqueVehicule graphVehicule) {
            return graphVehicule.affiche() + " 120 cheveaux";
        }

        public override string affiche() {
            return graphVehicule.affiche() + " || model:4x4";
        }
    }

    class MarqueDecorateur : Decorateur
    {
        public MarqueDecorateur(ComposantGraphiqueVehicule graph):base(graph){}


        public string afficheLogo(ComposantGraphiqueVehicule graphVehicule) {
            return graphVehicule.affiche() + " Logo = :)";
        }

        public override string affiche() {
            return graphVehicule.affiche() + " || marque:Peugeot";
        }
    }

}
