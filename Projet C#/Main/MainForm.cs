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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Main
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			string[] allLinesPro = File.ReadAllLines(@"Infos/lbProtection.txt"); // reads all lines from text file
			lbProtection.Items.AddRange(allLinesPro);
			
			string[] allLinesInfo = File.ReadAllLines(@"Infos/lbInfo.txt"); // reads all lines from text file
			lbInfo.Items.AddRange(allLinesInfo);
			
			ShellConsole shell = new ShellConsole();
			shell.getDevice();
			
			getDevice();
			System.Threading.Thread.Sleep(1000);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtActiverClick(object sender, EventArgs e)
		{
			
			string[] interfa = cbInterface.SelectedIndex.ToString().Split('.');
			int device = int.Parse(interfa[0]);
			device++;
			
			initComput(device);
			ShellConsole shell = new ShellConsole();
			shell.scan("192.168.1");
		
			System.Threading.Thread.Sleep(2000);
			
			//lbProtection.Items.Add(computer.getMail());
			//lbProtection.Items.Add(device);
		
			//Supervision form = new Supervision();
			//form.Show();
			
			
		}
		
		
		
		public void getDevice(){
			string[] allLinesDevice = File.ReadAllLines(@"Infos/devices.txt");
			foreach(string line in allLinesDevice){
				string[] newline = line.Split('}');
				cbInterface.Items.Add(newline[1]);
			}
		}

		public void initComput(int device){
			Computer computer = new Computer(device,tbEmail.Text);
		}
	}
}
