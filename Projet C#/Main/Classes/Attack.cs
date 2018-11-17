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
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace Main
{
	/// <summary>
	/// Description of Attack.
	/// </summary>
	public class Attack
	{
		protected List<Attacker> dataAttacker;
	
		
		public Attack() //Constructeur
		{
			dataAttacker=new List<Attacker>();
		}
		
		//public abstract void analyze(string fichier);
		//public abstract void makeReport();
		
		public void alert(string mail){
			string to=mail;
			string from="opsieapplicsharp@gmail.com";// Créer une boite mail et la rentrer ici
			string subject="Alert, attack detected !";
			string body="We notify you that an attack has been detected on your network ! you can check the attachment file to see the report";
			
			Attachment data = new Attachment("/Infos/report.txt");
			MailMessage message = new MailMessage(from, to, subject, body);
			message.Attachments.Add(data);
			SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
			
			smtp.Credentials= new System.Net.NetworkCredential("opsieapplicsharp@gmail.com", "opsie20182019");
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
		
	}
}