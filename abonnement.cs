using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace epoka
{
    public class Abonnement
    {
        private int numero;
        private string nom;
        private string prenom;
        private string adresse;
        private string codePostal;
        private DateTime dateDebut;
        private DateTime dateFin;
        private Revue laRevue;

        public Abonnement(int numero, string nom, string prenom, string adresse, string cp, DateTime debut, DateTime fin, Revue revue)
        {
            this.adresse = adresse;
            this.dateDebut = debut;
            this.dateFin = fin;
            this.nom = nom;
            this.codePostal = cp;
            this.prenom = prenom;
            this.numero = numero;
            this.laRevue = revue;
        }
        // retourne 'M' si le département en métropole,'C' s'il est en Corse, 'D' s'il est dans les TOM-DOM
        public char localisation()
        {
			char loco ='z';
			string debutCP = this.codePostal.Substring(0, 2);
			
			if (debutCP == "97")
				loco = 'D';
			else 
				if(debutCP == "2A" || debutCP == "2A")
				loco = 'C';

				else
				loco = 'M';
            return loco;
        }
        public DateTime getDateDebut() { return this.dateDebut; }
        public DateTime getDateFin() { return this.dateFin; }
		public string getNom() { return this.nom; }

		// retourne le prix d'abonnement en fonction du prix public et de la localisation
		//l’abonnement dans les DOM-TOM est 50 % plus élevé qu’en métropole et 25% de plus en Corse.
		public double prixAbonnement()
        {
			double prix = 0;
			double prixPublic = this.laRevue.getPrixAbonnement();

			char m = this.localisation();
			if (m == 'D')
				prix = prixPublic * 1.5;
			if (m == 'C')
				prix = prixPublic * 1.25;
			if(m == 'M')
				prix = prixPublic;
			return prix;
        }
    }
}
