using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.State
{
    public class Produit
    {
        public string label;
        public Produit (string productLabel) {
            label = productLabel;
        }
    }

    public class Commande
    {
        private EtatCommande etatCommande;
        protected List<Produit> produits;
        

        public Commande() {
            this.etatCommande = new CommandeEnCours(this);
            this.produits = new List<Produit>();
        }

        public void ajoutProduit(Produit produit) {
            this.produits.Add(produit);
        }

        public void retireProduit(String label) {
            var itemToRemove = this.produits.Single(r => r.label == label);
            this.produits.Remove(itemToRemove);
        }

        public List<Produit> getProduits() {
            Console.WriteLine("Dans mon panier il y a :");
            if (!this.produits.Any())
            {
                Console.WriteLine("Aucun article");
            } else
            {
                foreach (var item in this.produits)
                {
                    Console.WriteLine(" - " + item.label);
                }
            }
            
            return this.produits;
        }

        public void etatSuivant() {
            this.etatCommande =  etatCommande.etatSuivant();
        }

        public void efface() {
            this.produits = new List<Produit>();
        }
    }
    

    abstract public class EtatCommande
    {
        protected Commande commande;

        public EtatCommande(Commande commande) {
            this.commande = commande;
        }

        abstract public EtatCommande etatSuivant();
        abstract public void efface();
        abstract public void retireProduit(string labelProduct);
        abstract public void ajoutProduit(Produit product);
    }
    
    class CommandeEnCours : EtatCommande
    {
        public CommandeEnCours(Commande commande) : base(commande) {}

        public override void efface() {
            this.commande.efface();
            Console.WriteLine("Votre commande à bien était supprimé");
        }

        public override void retireProduit(string labelProduct) {
            this.commande.retireProduit(labelProduct);
            Console.WriteLine("Votre produit à bien était retiré");
        }

        public override void ajoutProduit(Produit produit) {
            commande.ajoutProduit(produit);
            Console.WriteLine("Votre produit à bien était ajouté");
        }
        
        public override EtatCommande etatSuivant() {
            Console.WriteLine("Votre commande et en status validée");
            return new CommandeValidee(commande);
        }
    }

    class CommandeValidee : EtatCommande
    {
        public CommandeValidee(Commande commande) : base(commande) {}

        public override void efface() {
            this.commande.efface();
            Console.WriteLine("Votre commande à bien était supprimé");
        }

        public override void retireProduit(string labelProduct) {
            this.commande.retireProduit(labelProduct);
            Console.WriteLine("Votre produit à bien était retiré");
        }

        public override void ajoutProduit(Produit produit) {
            commande.ajoutProduit(produit);
            Console.WriteLine("Votre produit à bien était ajouté");
        }
        
        public override EtatCommande etatSuivant() {
            Console.WriteLine("Votre commande et en status Livrée");
            return new CommandeLivree(commande);
        }
    }

    class CommandeLivree : EtatCommande
    {
        public CommandeLivree(Commande commande) : base(commande) {}

        public override void efface() {
            this.commande.efface();
            Console.WriteLine("Votre commande à bien était supprimé");
        }

        public override void retireProduit(string labelProduct) {
            this.commande.retireProduit(labelProduct);
            Console.WriteLine("Votre produit à bien était retiré");
        }

        public override void ajoutProduit(Produit produit) {
            commande.ajoutProduit(produit);
            Console.WriteLine("Votre produit à bien était ajouté");
        }
        
        public override EtatCommande etatSuivant() {
            Console.WriteLine("Votre commande et déjà en status livrée");
            return new CommandeLivree(commande);
        }
    }
}
