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
using System.Windows.Forms;
using System.Threading;


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

			InitializeComponent();
			
			File.SetAttributes("Infos/",FileAttributes.Hidden);
			
			string[] allLinesPro = File.ReadAllLines(@"Infos/lbProtection.txt"); // reads all lines from text file
			lbProtection.Items.AddRange(allLinesPro);
			
			string[] allLinesInfo = File.ReadAllLines(@"Infos/lbInfo.txt"); // reads all lines from text file
			lbInfo.Items.AddRange(allLinesInfo);
			
			
			
			shell.getDevice(); //On récupère les device via une commande shell
			getDevice();
			
		}
		
		void BtActiverClick(object sender, EventArgs e)
		{
			Thread t = new Thread(new ThreadStart(startLoad));
			string interfa = cbInterface.Text;
			initComput(interfa);
			
			
			if(!string.IsNullOrEmpty(computer.getIp())){//Si on a bien récuperé une ip via l'interface
				if(computer.mailIsValid(tbEmail.Text)){
					this.Hide();
					t.Start();
					Supervision sup = new Supervision(this); //on initialise le second formulaire
					while(t.IsAlive){
						Thread.Sleep(1000);
					}
					sup.ShowDialog();
				}
				else{
					MessageBox.Show("Veuillez rentrer une adresse mail valide");
				}
			}else{
				MessageBox.Show("Il semblerait que votre carte ne soit pas activée, ou que vous n'êtes raccordé à aucun réseau");
			}
		}
		
		
		
		public void getDevice(){ //On récupère l'interface, on la formate et on l'ajoute à l'interface
			string[] allLinesDevice = File.ReadAllLines(@"Infos/devices.txt");
			foreach(string line in allLinesDevice){
				if(!line.Contains("WAN") && !line.Contains("RAS Async")  //On enlève des cartes réseaux qui ne sont pas importante
				   && !line.Contains("Microsoft Kernel") && !line.Contains("Description")
				   && !line.Contains("Microsoft Wi-Fi Direct Virtual"))
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
		
		public void startLoad(){
			Application.Run(new SplashForm());
		}
		
	}
}
