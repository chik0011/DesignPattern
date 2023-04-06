using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Observeur
{

    public interface Observer 
    {
        public void actualise() {}
    }

    class VueCehicule : Observer
    {
        protected Vehicule vehicule;

        public VueCehicule(Vehicule vehicule) {
            this.vehicule = vehicule;
        }
        public void actualise() {
            this.redessine();
        }

        public void redessine() {
            Console.WriteLine("Le vehicule à était actualisé " + vehicule.getPrice());
        }
    }

    class Sujet
    {
        protected List<Observer> observers;

        public Sujet() {
            this.observers = new List<Observer>();
        }

        public void ajoute(Observer observer) {
            this.observers.Add(observer);
        }

        public void retire(Observer observer) {
            this.observers.Remove(observer);
        }

        protected void notifie()
        {
            foreach (Observer observer in this.observers)
                observer.actualise();
        }
    }

    class Vehicule : Sujet
    {
        protected string description;
        protected double price;

        public Vehicule(string description, double price) {
            this.description = description;
            this.price = price;
        }

        public string getDescription() {
            Console.WriteLine("Description : " + this.description);
            return this.description;
        }

        public void setDescription(string description) {
            this.description = description;
            this.notifie();
            Console.WriteLine("La description du vehicule à était modifiée");
        }

        public double getPrice() {
            Console.WriteLine("Prix : " + this.price);
            return this.price;
        }

        public void setPrice(double price) {
            this.price = price;
            this.notifie();
            Console.WriteLine("Le prix du véhicule à était modifié");
        }
    }



}
