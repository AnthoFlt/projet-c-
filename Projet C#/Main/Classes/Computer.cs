using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Main
{
	public class Computer
	{
		private String ip;
		private int interf;
		private String mac;
		private String mail;
		
		ShellConsole shell = new ShellConsole();
		public Computer(){}

		
		public Computer(int numInterf, String mail)
		{
			setInterf(numInterf);
			this.mail = mail;
		}
		
		public void setMail(String newMail)
		{
			this.mail = newMail;
		}	

		
		void setInterf(int numInterf)
		{
			this.interf = numInterf;
			this.ip = getInfo("ip", numInterf); 
			this.mac = getInfo("mac", numInterf); 
		}
		
		
		void FilesUpdate()
		{
			//shell.getIpMac();
			//shell.getDevice();
		}
		
		String getInfo(String addr, int choix)
		{
			FilesUpdate();
			System.Threading.Thread.Sleep(500);
	        string[] lines = System.IO.File.ReadAllLines(@"Infos/devices.txt");
	      
	        
	        int nb = 1;
	        string res = "";
	        foreach (string line in lines)
	        {
		        	if(nb == choix)
		        	{
		        		string pattern = "(\\((.*?)\\))";
		        		Match m = Regex.Match(line, pattern);
		        		res = m.Value;
		        		res = res.Substring(1, res.Length - 2);
		        	}
	        		
	        		nb++;
	        }
	        
	        lines = System.IO.File.ReadAllLines(@"Infos/infoIpMac.txt");
	        nb = 1;
	        String avant = "";
	        String avantavant = "";
	        String macRetour = "";
	        String ipRetour = "";
	        foreach (string line in lines)
	        {
	        	int nbOcc = (avantavant.Length - avantavant.Replace(res,"").Length) / res.Length;
	        	if(nbOcc > 0)
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
		
		
		
		public int getInterf()
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