/*
 * Crée par SharpDevelop.
 * Utilisateur: magic
 * Date: 22/10/2018
 * Heure: 19:44
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.IO;


namespace Main
{
	/// <summary>
	/// Description of Attack.
	/// </summary>
	public abstract class Attack
	{
		protected List<Attacker> dataAttacker;
		public ShellConsole shell = new ShellConsole();
		protected MainForm mainform;
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		
		public Attack() //Constructeur
		{
			dataAttacker=new List<Attacker>();
			
			
			timer.Interval = 300000;
			timer.Tick += new EventHandler(resetList);
			timer.Enabled=true;
       		timer.Start();
		}
		
		public abstract void analyze();
		public abstract void makeReport(int numb);
		
		public void alert(string mail, string report){
			string to=mail;
			string from="OpsieAppliCsharpProjet@gmail.com";
			string subject="Alerte, attaque détécté sur votre machine !";
			string body="Bonjour, \n\nNous vous informons que votre machine a subi une attaque. \nVous trouverez en pièce jointe les informations necessaire des machines impactée \n\nCordialement,\nLes développeurs. ";
			
			Attachment data = new Attachment("Rapports/"+report);
			data.Name= report;
			MailMessage message = new MailMessage(from, to, subject, body);
			message.Attachments.Add(data);
			SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
			
			smtp.Credentials= new System.Net.NetworkCredential("OpsieAppliCsharpProjet@gmail.com", "Opsie20182019");
			smtp.EnableSsl=true;
			
			try{
				smtp.Send(message);
			}
			catch (Exception e){
				Console.WriteLine("Exception caught int alert(): {0}", e.ToString());
			}
			
		}
		
		/*public void showReport(){
			
		}*/
		
		public void resetList(Object sender, EventArgs e){
			dataAttacker.Clear();
		}
		

		public int numberLine(string fichier){ //Permet de retourner le nombre de ligne d'un fichier
			using (StreamReader r = new StreamReader(fichier))
			{
				int i = 0;
				while (r.ReadLine() != null)
					i++; 
				return i;
			}
		}

		
				
	}
}