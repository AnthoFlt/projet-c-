using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Main
{
	public class Computer
	{
		private String ip;
		private String interf;
		private String mac;
		private String mail;
		
		ShellConsole shell = new ShellConsole();
		public Computer(){}

		
		public Computer(String interf, String mail)
		{
			setInterf(interf);
			this.mail = mail;
		}
		
		public void setMail(String newMail)
		{
			this.mail = newMail;
		}	

		
		void setInterf(String interf)
		{
			this.interf = interf;
			this.ip = getInfo("ip", interf); 
			this.mac = getInfo("mac", interf); 
		}
		
		
		void FilesUpdate()
		{
			shell.getIpMac();
			shell.getDevice();
		}
		
		String getInfo(String addr, String choix)
		{
			FilesUpdate();
			System.Threading.Thread.Sleep(500);
	      

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
	        		macRetour = avant.Substring(44, 17);
	        		string line2 = line.Substring(44);
	        		string pattern = "\\b\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\b";
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