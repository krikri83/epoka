using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace epoka
{
    public class LesRevues
    {
        private List<Revue> mesRevues;
        public LesRevues()
        {
            this.mesRevues = new List<Revue>();
        }
        public void ajouterRevue(Revue revue) {this.mesRevues.Add(revue); }

        // retourne le montant total perçu pour tous les abonnements encore en cours et cela pour toutes les revues
        public double getMontantTotal()
        {
            double montantTotal = 0;
            foreach (Revue r in mesRevues)
            {
                montantTotal += r.getMontant();
            }
            return montantTotal;
        }

    }
}
