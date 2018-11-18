/*
 * Crée par SharpDevelop.
 * Utilisateur: magic
 * Date: 22/10/2018
 * Heure: 19:42
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;


namespace Main
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public Computer computer;
		public ShellConsole shell = new ShellConsole();
		public string ip;
		public string res;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			File.SetAttributes("Infos/",FileAttributes.Hidden);
			
			string[] allLinesPro = File.ReadAllLines(@"Infos/lbProtection.txt"); // reads all lines from text file
			lbProtection.Items.AddRange(allLinesPro);
			
			string[] allLinesInfo = File.ReadAllLines(@"Infos/lbInfo.txt"); // reads all lines from text file
			lbInfo.Items.AddRange(allLinesInfo);
			
			
			
			shell.getDevice();
			System.Threading.Thread.Sleep(1000);
			getDevice();
			System.Threading.Thread.Sleep(1000);
			shell.getIpMac();

			
		}
		void BtActiverClick(object sender, EventArgs e)
		{
			string interfa = cbInterface.Text;
			initComput(interfa);
			
			if(!string.IsNullOrEmpty(computer.getIp())){//Si on a bien récuperé une ip via l'interface
				Supervision sup = new Supervision(this); //on initialise le second formulaire
				sup.Show();
			}else{
				MessageBox.Show("Il semblerait que votre carte ne soit pas activée, ou que vous n'êtes raccordé à aucun réseau");
			}
		}
		
		
		
		public void getDevice(){ //On récupère l'interface et on la formate
			string[] allLinesDevice = File.ReadAllLines(@"Infos/devices.txt");
			foreach(string line in allLinesDevice){
				if(!line.Contains("WAN") && !line.Contains("RAS Async")  //On enlève des cartes réseaux qui ne sont pas importante
				   && !line.Contains("Microsoft Kernel") && !line.Contains("Description"))
					cbInterface.Items.Add(line);
			}
		}

		public void initComput(String device){ //On crée notre machine avec ses informatiuons
			computer = new Computer(device,tbEmail.Text);
			ip = computer.getIp();
			if(!string.IsNullOrEmpty(ip)){
				string[] ipSplit=ip.Split('.');
				res = ipSplit[0]+'.'+ipSplit[1]+'.'+ipSplit[2];
			}
		}
		
		public MainForm getMainForm(){
			return this;
		}
		
	}
}
