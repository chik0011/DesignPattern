using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Bridge
{
    public interface FormulaireImpl
    {
        string dessineTexte();
        string gereZoneSaisie();
    }

    class FormHtmlImpl : FormulaireImpl
    {
        public string dessineTexte()
        {
            return "FormHtml";
        }

        public string gereZoneSaisie()
        {
            return "Immatricule : AA-895-NT";
        }
    }

    class FormAppleImpl : FormulaireImpl
    {
        public string dessineTexte()
        {
            return "FormApple";
        }

        public string gereZoneSaisie()
        {
            return "Immatricule : BG-002-OP";
        }
    }

    public abstract class FormulaireImmatriculation
    {
        protected FormulaireImpl form;

        public void affiche()
        {
            Console.WriteLine(this.genereDocument());
        }

        public string genereDocument()
        {
            return "C'est mon document";
        }

        public string gereSaisie()
        {
            return "La saisie";
        }

        public abstract string controleSaisie();
    }

    class FormulaireImmatriculationFrance : FormulaireImmatriculation
    {
        public override string controleSaisie() {
            return "controle France";
        }
    }

    class FormulaireImmatriculationLuxembourg : FormulaireImmatriculation
    {
        public override string controleSaisie() {
            return "controle Luxembourg";
        }
    }
}
