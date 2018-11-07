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
	        process.StartInfo.UseShellExecute = false;
	        return process;
		}
		
		public void getArpByIp(string ip){ // Récupère la résolution ARP d'une adresse et la place dans un fichier text
			process.StartInfo.Arguments= "/C arp -a | findstr " +ip+ " >> arpTab.txt";
			process.Start();
		}
		
		public void clearArpTab(){ // efface le fichier arp
			process.StartInfo.Arguments= "/C del arpTab.txt";
			process.Start();
		}
		
		public void getDevice(){ // Récupère les interfaces de la machine
			process.StartInfo.Arguments= "/C WinDump -D > devices.txt";
			process.Start();
		}
		
		public void getIpMac(){ // Récupére l'adresse ip, mac et le nom de la carte
			process.StartInfo.Arguments= "/C ipconfig -all | findstr /i \"ipv4 description physi\" > infoIpMac.txt";
			process.Start();
		}
		
		public void ActiveSniff(int interfa){ // lance le sniffer en fonction de l'interface choisi
			process.StartInfo.Arguments= "/C WinDump -i "+interfa;
			process.Start();
		}
		
	}
}