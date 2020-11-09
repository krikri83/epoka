using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace epoka
{
    public class Revue
    {
        private string code;
        private string titre;
        private double prixAbonnement;
        private List<Abonnement> lesAbonnements;
        public Revue(string code, string titre, double prix)
        {
            this.code = code;
            this.titre = titre;
            this.prixAbonnement = prix;
            this.lesAbonnements = new List<Abonnement>();
        }
        public List<Abonnement> getLesAbonnements() { return this.lesAbonnements; }
        public double getPrixAbonnement() { return this.prixAbonnement; }

        // ajoute un nouvel abonnement
        public void ajouterAbonnement(int numero, string nom, string prenom, string adresse,
            string cp, DateTime debut, DateTime fin)
        {
			
			Abonnement a = new Abonnement(numero, nom, prenom, adresse, cp,
				debut, fin,this);
			this.lesAbonnements.Add(a);
        }
		// retourne une liste d'abonnements regroupant les abonnements nécessitant
		// un processus de relance. les abonnements pour lesquels la
		//date du jour est antérieure de moins de 30 jours à la date de fin d'abonnement.
        public List<Abonnement> relancerAbonnement()
        {
			List<Abonnement> l = new List<Abonnement>();
			foreach (Abonnement a in this.lesAbonnements)
			{

				if (a.getDateFin().Subtract(DateTime.Now).TotalDays <= 30)//30 j avant le fin d'abonnement
					l.Add(a);
					
			}
			return l;
        }


        // retourne le montant perçu pour tous les abonnements encore en cours
        public double getMontant()
        {
			double montant = 0;
			DateTime now = DateTime.Now;
			
			foreach (Abonnement a in this.lesAbonnements )
			{
				if (a.getDateFin() > now)
				montant = montant + a.prixAbonnement();
			}

            return montant;
        }
        // retourne le nombre d'abonnements arretés cette année
        public int nbAbonnementsArretes()
        {
			int arrete = 0;
			DateTime now = DateTime.Now;

			foreach (Abonnement a in this.lesAbonnements)
			{
				if (a.getDateFin() < now)
					arrete++;
			}
			return arrete;
        }
    }
}
