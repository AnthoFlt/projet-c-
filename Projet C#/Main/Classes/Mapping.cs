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
using System.Windows.Forms;

namespace Main
{
	/// <summary>
	/// Description of Mapping.
	/// </summary>
	public class Mapping
	{
		
		
		Dictionary <int, string> lIps;
		Dictionary <int, string> LMacs;
		Computer computer;
		string line;
	
		public Mapping(Computer computer)
		{
			lIps=new Dictionary<int, string>();
			LMacs=new Dictionary<int, string>();
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
				if(line.Contains(res) && !line.Contains(this.computer.getIp()) ){
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
			for(i=0; i<ips.Length; i++){
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
				for(int i = 0; i<LMacs.Count; i++){
					if(!Array.Exists(lines, element => element == LMacs[i])){ //On vérfie si la mac n'est pas dans le fichier
						int bina = KeyByValue(LMacs, LMacs[i]);//Dans ce cas on récupère son index
						LMacs.Remove(bina);//Et on le retire de sa liste
						
						if(!Array.Exists(lines, element => element == lIps[bina])){//On verfie que l'adresse à aussi disparu
							lIps.Remove(bina); //Si c'est le cas, on retir aussi l'ip de la liste
						}
					}
				}
			}
				
			int j=0;
			for(int i = 0; i<=(numberLine(@"Infos/scanForm.txt")-1); i=i+2){ // A partir du fichier de scan	
				
				if(lIps!=null && lIps.ContainsValue(lines[i])){ // Si on à bien une adresse ip
					int binari = KeyByValue(lIps, lines[i]); //On récupère son index
					if(LMacs[binari]!= lines[i+1]){
						LMacs[binari] = lines[i+1];
					}
				}

				else if(lIps==null || !lIps.ContainsValue(lines[i])){ // On verifie si la list ne contient pas l'adresse ip
					for(j=0; j<lIps.Count; j++){ // On verifie quel emplacement est disponible
						if(!lIps.Keys.Contains(j))
							if(!LMacs.Keys.Contains(j))
								break;
					}
					
					lIps.Add(j,lines[i]); // Si c'est vrai on ajoute l'ip dans la liste
					LMacs.Add(j,lines[i+1]); // Ainsi que la mac
				}
				
			}
			
			StreamWriter wrIp = new StreamWriter(@"Infos/testIp.txt");
			foreach(KeyValuePair<int, string> ip in lIps){
				wrIp.Write(ip.Key + " - ");
				wrIp.WriteLine(ip.Value);
			}
			wrIp.Close();
			
			StreamWriter wrMac = new StreamWriter(@"Infos/testMac.txt");
			foreach(KeyValuePair<int, string> mac in LMacs){
				wrMac.Write(mac.Key + " - ");
				wrMac.WriteLine(mac.Value);
			}
			wrMac.Close();
		}
		
		
		public int KeyByValue(Dictionary<int, string> dict, string val)
		{
		    int key=0;
		    foreach (KeyValuePair<int, string> pair in dict)
		    {
		        if (pair.Value == val)
		        { 
		            key = pair.Key; 
		            break; 
		        }
		    }
		    return key;
		}
		
	}
}
