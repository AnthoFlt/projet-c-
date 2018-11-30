using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Main
{
	public class Computer
	{
		private String ip; //ip PC courant
		private String interf; //nom interface sélectionnée
		private String mac; //mac PC courant
		private String mail; //mail sur lequel seront envoyés les rapports
		
		ShellConsole shell = new ShellConsole();
		public Computer(){}

		
		public Computer(String interf, String mail)
		{
			setInterf(interf);
			this.mail = mail;
		}
		
		public void setMail(String newMail)
			//changement de mail
		{
			this.mail = newMail;
		}	

		
		void setInterf(String interf)
			//changement d'interface sélectionnée
		{
			this.interf = interf;
			this.ip = getInfo("ip", interf);
			this.mac = getInfo("mac", interf);
		}
		
		
		void FilesUpdate()
			//maj des fichiers avec les interfaces et les correspondances ip/mac
		{
			shell.getIpMac();
			shell.getDevice();
		}
		
		String getInfo(String addr, String choix)
			//récupération de l'ip ou de la mac selon l'argument choix:
			//choix = "ip" sinon récupère la mac
		{
			FilesUpdate();	      

			string[] lines = System.IO.File.ReadAllLines(@"Infos/infoIpMac.txt");
	        int nb = 1;
	        String avant = "";
	        String avantavant = "";
	        String macRetour = "";
	        String ipRetour = "";
	        foreach (string line in lines)
	        {
	        	if(avantavant.Contains(choix.Trim()))
	        	{
	        		macRetour = avant.Substring(44, 17); //récupération mac
	        		string line2 = line.Substring(44);
	        		string pattern = "\\b\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\b"; //regex ip
	        		Match m2 = Regex.Match(line2, pattern);
	        		ipRetour = m2.Value;
	        	}
	        	avantavant = avant;
	        	avant = line;	
	        }
	        
	        if(addr == "ip")
	        	return ipRetour;
	        return macRetour;
		}
		
		
		
		public String getInterf()
		{
			return this.interf;
		}
		
		public String getIp()
		{
			return this.ip;
		}
		
		public String getMac()
		{
			return this.mac;
		}
		
		public String getMail()
		{
			return this.mail;
		}
		
		
	}
}