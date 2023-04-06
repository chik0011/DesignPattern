using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Proxy
{

    interface Animation
    {
        public void clic() {}
        public void dessine() {}
    }

    public class Film
    {
        public void clic() {
            Console.WriteLine("Tu as cliqué sur se film");
        }
        
        public void dessine() {
            Console.WriteLine("Tu as dessiné se film");
        }

        public void charge() {
            Console.WriteLine("Le Film est chargé");
        }

        public void joue() {
            Console.WriteLine("Le Film est joué");
        }
    }

    public class AnimationProxy : Animation
    {
        private string photo;
        protected Film film;

        public AnimationProxy(string photo, Film film=null) {
            this.film = film;
            this.photo = photo;
        }

        public void dessine() {
            if (this.film != null)
            {
                film.dessine();
            } else
            {
                this.dessinePhoto(this.photo);
            }
        }
        
        public void click() {
            if(this.film == null) {
                this.film = new Film();
                this.film.charge();
            }

            film.joue();
        }

        public void dessinePhoto(string photo) {
            Console.WriteLine("Voici la photo du film " + photo);
        }
    }

}
