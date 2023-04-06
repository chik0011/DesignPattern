using DesignPatternsSamples.Singleton;
using DesignPatternsSamples.Bridge;
using DesignPatternsSamples.Strategy;
using DesignPatternsSamples.Decorator;
using DesignPatternsSamples.State;
using DesignPatternsSamples.TemplateMethod;
using DesignPatternsSamples.Observeur;
using DesignPatternsSamples.Proxy;
using DesignPatternsSamples.Facade;
using DesignPatternsSamples.Composite;

namespace LearnDesignPattern;
class Program
{
    static void Main(string[] args)
    {
        // Singleton Pattern
        Console.WriteLine("-- Singleton Pattern --");
        LiasseVierge singletonA = LiasseVierge.GetInstance();
        LiasseVierge singletonB = LiasseVierge.GetInstance();

        if (singletonA == singletonB)
            Console.WriteLine("The value is single");
        else
            Console.WriteLine("The value is not single");

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");

        // Bridge Pattern
        Console.WriteLine("-- Bridge Pattern --");
        FormulaireImmatriculation formFrance = new FormulaireImmatriculationFrance();
        formFrance.affiche();

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");

        // Strategy Pattern
        Console.WriteLine("-- Strategy Pattern --");
        List<string> maListeDeChaines = new List<string>();
        maListeDeChaines.Add("Renault");
        maListeDeChaines.Add("Audi");
        maListeDeChaines.Add("BMW");

        DessinUnVehiculeLigne unVehiculeLigne = new DessinUnVehiculeLigne();
        DessinTroisVehiculesLigne troisVehiculeLigne = new DessinTroisVehiculesLigne();
        
        VueCatalogue catalog1 = new VueCatalogue(unVehiculeLigne);
        catalog1.dessine(maListeDeChaines);

        VueCatalogue catalog2 = new VueCatalogue(troisVehiculeLigne);
        catalog2.dessine(maListeDeChaines);

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");

        // Decorator Pattern
        Console.WriteLine("-- Decorator Pattern --");
        VueVehicule decorateur = new VueVehicule();
        Console.WriteLine(decorateur.affiche());

        MarqueDecorateur marqueDecorateur = new MarqueDecorateur(decorateur);
        Console.WriteLine(marqueDecorateur.affiche());

        ModeleDecorateur modeleDecorateur = new ModeleDecorateur(marqueDecorateur);
        Console.WriteLine(modeleDecorateur.affiche());
        
        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");
    
        // State Pattern
        Console.WriteLine("-- State Pattern --");
        Produit banane = new Produit("banane");
        Produit carotte = new Produit("carotte");

        DesignPatternsSamples.State.Commande commande = new DesignPatternsSamples.State.Commande();
        commande.ajoutProduit(banane);
        commande.getProduits();
        
        commande.ajoutProduit(carotte);
        commande.getProduits();

        commande.retireProduit("banane");
        commande.getProduits();

        commande.efface();
        commande.getProduits();

        commande.ajoutProduit(carotte);
        commande.ajoutProduit(banane);

        commande.etatSuivant();
        commande.etatSuivant();
        commande.etatSuivant();

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");
    
        // TemplateMethod Pattern
        Console.WriteLine("-- TemplateMethod Pattern --");

        CommandeFrance commandeFrance = new CommandeFrance(1000);
        commandeFrance.calculeTva();
        commandeFrance.calculeMontantTTC();
        commandeFrance.affiche();

        CommandeLuxembourg commandeLuxembourg = new CommandeLuxembourg(10);
        commandeLuxembourg.calculeTva();

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");
    
        // Observer Pattern
        Console.WriteLine("-- Observer Pattern --");
        Vehicule vehicule = new Vehicule("ma voiture", 15000);
        Observer observer = new VueCehicule(vehicule);
        vehicule.ajoute(observer);
        vehicule.setPrice(20000);

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");
    
        // Proxy Pattern
        Console.WriteLine("-- Proxy Pattern --");
        Film film = new Film();
        AnimationProxy animationProxy = new AnimationProxy("Django");
        animationProxy.click();
        animationProxy.dessine();

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");
    
        // Facade Pattern
        Console.WriteLine("-- Facade Pattern --");
        WebServiceAuto webServiceAuto = new WebServiceAuto();
        webServiceAuto.chercheVehicule(5000, 300);

        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("");
    
        // Composite Pattern
        Console.WriteLine("-- Composite Pattern --");
        SocieteSansFiliale societeSansFiliale = new SocieteSansFiliale(500);
        societeSansFiliale.calculeCoutEntretien();

        SocieteSansFiliale societeSansFiliale1 = new SocieteSansFiliale(300);
        SocieteMere societeMere1 = new SocieteMere(122);

        SocieteMere societeMere = new SocieteMere(600);
        societeMere.ajouteFiliale(societeSansFiliale);
        societeMere.ajouteFiliale(societeSansFiliale1);
        societeMere.ajouteFiliale(societeSansFiliale1);
        societeMere.calculeCoutEntretien();
    }
}
