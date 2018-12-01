/*
 * Crée par SharpDevelop.
 * Utilisateur: magic
 * Date: 22/10/2018
 * Heure: 19:47
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Main
{
	/// <summary>
	/// Description of ArpSpoof.
	/// </summary>
	public class ArpSpoof:Attack
	{
		private string name="arpspoof";
		Dictionary <string, int> dictionary = new Dictionary<string, int>();
		string fichier;
		Random rnd;
		public ArpSpoof(MainForm mainform) // Constructeur
		{
			this.mainform=mainform;
		}
		
		
		public override void analyze(){
			int linenumber=numberLine(@"Infos/arpTab.txt");
			string[] data = new string[linenumber]; // Tableau qui contiendra ip et mac de la table arp
		
			string line;
			string[] lineForm;
			
			int i=0;
			bool attack=false;
			
			StreamReader file = new StreamReader(@"Infos/arpTab.txt");  //on formate les données du fichier pour les mettre dans notre tableau
			while((line = file.ReadLine()) != null)  
			{  
				line = Regex.Replace(line,  @"\s+", " ");
				line = line.Trim(' ');
				data[i] =line;
				i++;
			}  
			file.Close(); 
			
			for (i=0; i<linenumber; i++){ //Dans cette boucle, on va compter le nombre d'occurence des adresses MAC
				lineForm=data[i].Split(' ');
				
				if (dictionary.ContainsKey(lineForm[1])) //Si le dictionnaire posséde déjà une adresse mac, on augmente l'occurence
		        {
		            dictionary[lineForm[1]] += 1; 
		        }
		        else
		        {
		            dictionary.Add(lineForm[1],1); //Sinon on l'ajoute au dico
		        }
		        
			}
			
			
			for (i=0; i<dictionary.Count; i++){ // Après avoir rempli le dictionnaire, on regarde si des MAC sont en double
				lineForm=data[i].Split(' ');
				if(dictionary[lineForm[1]] > 1){ // Si 2 MAC Sont en double, on subit une attaque
					attack=true;
					if(dataAttacker.Count > 1){
						foreach(Attacker dataAttaquant in dataAttacker){ //On verifie que l'attaque n'ait pas déjà été prévenue					
							if(dataAttaquant.getMac().Contains(lineForm[1]) && dataAttaquant.getIp().Contains(lineForm[0])){
								attack=false;
								break;
							}
						}
						if(attack){
							Attacker attaquant = new Attacker(lineForm[0], lineForm[1]); //On instancie alors nos attaquant avec ip et mac.
					        dataAttacker.Add(attaquant); // Et on les ajoute à la liste
						}
					}else{
						Attacker attaquant = new Attacker(lineForm[0], lineForm[1]); //On instancie alors nos attaquant avec ip et mac.
					    dataAttacker.Add(attaquant); // Et on les ajoute à la liste
					}
				}
			}
			
			
			if(attack){ // Si on subit une attaque
				rnd = new Random();
				int numb = rnd.Next(50000);//Nombre aléatoire pour éviter les duplications de fichier
				makeReport(numb); //On crée ensuite le rapport
				alert(mainform.computer.getMail(), fichier); //Et on envois une alerte par mail
				MessageBox.Show("Une attaque a été détécté sur votre réseau, un rapport vous a été envoyé par mail"); //On affiche ensuite un message sur l'application
				attack=false;
			}
			
			dictionary.Clear(); //On reformat le dictionnaire pour la prochaine analyse
			
		}
		
		
		
		public override void makeReport(int numb){
			StreamWriter wr = new StreamWriter(@"Rapports/Rapport du "+ DateTime.Now.ToString("dd-MM-yyyy HH'h'mm'min'")+ " [" +numb+"].txt"); // On crée un fichier avec la date
			
			wr.WriteLine("Rapport d'attaque du " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
			wr.WriteLine("");
			wr.WriteLine("les adresses ip et mac impactées sont les suivantes : ");
			int number = dataAttacker.Count;
			int j=0;
			foreach(Attacker attaquant in dataAttacker){ //On va piocher les informations précedemment renseignée 
				if(j == number-1 || j == number- 2){
					wr.WriteLine("Adresse Ip : " + attaquant.getIp());
					wr.WriteLine("Adresse Mac : " + attaquant.getMac());
					wr.WriteLine("");
				}
				j++;
			}
			wr.Close();
			
			fichier = "Rapport du "+ DateTime.Now.ToString("dd-MM-yyyy HH'h'mm'min'")+ " [" +numb+"].txt";
		}
		
		public void getArp(string res){
			shell.arpTab(res);
		}
		
	}
}
