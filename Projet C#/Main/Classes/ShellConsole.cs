/*
 * Created by SharpDevelop.
 * User: VmWindows
 * Date: 31/10/2018
 * Time: 15:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace Main
{
	/// <summary>
	/// Description of ShellConsole.
	/// </summary>
	public class ShellConsole
	{
		Process process;
		
		public ShellConsole() //Lance l'initialisation quand la classe est appelée
		{
			makeProcess();
		}
		
		Process makeProcess(){ //Initialisation du processus pour la console
			process = new Process();
	        process.StartInfo.FileName = "cmd.exe";
	        process.StartInfo.RedirectStandardInput = false;
	        process.StartInfo.UseShellExecute = true;
	        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
	        return process;
		}
		
		
		
		public void scan(string res){ // Récupère la résolution ARP d'une adresse et la place dans un fichier text
			process.StartInfo.Arguments= "/C nmap -sn " +res+ ".0/24 | findstr \"MAC "+res+ "\" >> Infos/scan.txt";
			process.Start();
			process.WaitForExit();
		}
		
		public void clearTxt(string file){ // efface le fichier arp
			process.StartInfo.Arguments= "/C del Infos\\"+file;
			process.Start();
			process.WaitForExit();
		}
		
		public void getDevice(){ // Récupère les interfaces de la machine
			process.StartInfo.Arguments= "/C wmic NICCONFIG get Description > Infos/devices.txt";
			process.Start();
			process.WaitForExit();
		}
		
		public void getIpMac(){ // Récupére l'adresse ip, mac et le nom de la carte
			process.StartInfo.Arguments= "/C ipconfig -all | findstr /i \"ipv4 description physi\" > Infos/infoIpMac.txt";
			process.Start();
			process.WaitForExit();
		}
		
	}
}