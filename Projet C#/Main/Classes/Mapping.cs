/*
 * Crée par SharpDevelop.
 * Utilisateur: VmWindows
 * Date: 10/11/2018
 * Heure: 17:29
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
	/// <summary>
	/// Description of Mapping.
	/// </summary>
	public class Mapping
	{
		
		
		List <string> lIps;
		List <string> LMacs;
		Computer computer;
		string line;
	
		public Mapping(Computer computer)
		{
			lIps=new List<string>();
			LMacs=new List<string>();
			this.computer=computer;
		}
		
		
		public void formatScan(string res){
			int linenumber=numberLine(@"Infos/scan.txt")/2;
			
			string[] ips = new string[linenumber];
			string[] macs= new string[linenumber];
			int i=0;
			int j=0;
			
			Regex rIp = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
			
			StreamReader file = new StreamReader(@"Infos/scan.txt");  
			while((line = file.ReadLine()) != null)  
			{  
				if(line.Contains(res) && !line.Contains(this.computer.getIp())){
					if(rIp.IsMatch(line)){
						ips[i] = rIp.Match(line).Groups[0].Value;
						i++;
					}
				}
				
				if(line.Contains("MAC")){
					macs[j]=line.Substring(13,17);
					j++;
				}
				
			}  
			file.Close();  
			
			StreamWriter wr = new StreamWriter(@"Infos/scanForm.txt");
			for(i=0; i<macs.Length; i++){
				wr.WriteLine(ips[i]);
				wr.WriteLine(macs[i]);
			}
			wr.Close();
		}
		
		
		
		int numberLine(string fichier){
			using (StreamReader r = new StreamReader(fichier))
			{
				int i = 0;
				while (r.ReadLine() != null)
					i++; 
				return i;
			}
		}
		
		
		public void analyseMapping(){
			string[] lines = File.ReadAllLines(@"Infos/scanForm.txt");			
			if(LMacs != null){
				foreach(string str in LMacs){ //A partir d'une liste définie lors de la première itération
					if(!Array.Exists(lines, element => element == str)){ //On vérfie si la mac n'est pas dans le fichier
						int bina = LMacs.BinarySearch(str);//Dans ce cas on récupère son index
						LMacs.RemoveAt(bina);//Et on le retire de sa liste
						
						if(!Array.Exists(lines, element => element == lIps.ElementAt(bina))){//On verfie que l'adresse à aussi disparu
							lIps.RemoveAt(bina); //Si c'est le cas, on retir aussi l'ip de la liste
						}
					}
				}
			}
			
			for(int i = 0; i<=(numberLine(@"Infos/scanForm.txt")/2); i=i+2){ // A partir du fichier de scan
				
				if(lIps==null || !lIps.Contains(lines[i])){ // On verifie si la list ne contient pas l'adresse ip
					lIps.Add(lines[i]); // Si c'est vrai on ajoute l'ip dans la liste
					LMacs.Add(lines[i+1]); // Ainsi que la mac
				}
				///////////////////////////////////////////////////////////////////////////////// ne marche pas encore
				if(lIps.Contains(lines[i])){ // Si on à bien une adresse ip
					int binari = lIps.BinarySearch(lines[i]); //On récupère son index
					if(LMacs.ElementAt(binari) != lines[i+1]){
						LMacs.ElementAt(binari).Replace(LMacs.ElementAt(binari),lines[i+1]);
					}
				}
				///////////////////////////////////////////////////////////////////////////////
			}
			
			StreamWriter wrIp = new StreamWriter(@"Infos/testIp.txt");
			foreach(string ip in lIps){
				wrIp.WriteLine(ip);
			}
			wrIp.Close();
			
			StreamWriter wrMac = new StreamWriter(@"Infos/testMac.txt");
			foreach(string mac in LMacs){
				wrMac.WriteLine(mac);
			}
			wrMac.Close();
		}
		
	}
}
