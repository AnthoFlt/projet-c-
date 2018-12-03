/*
 * Created by SharpDevelop.
 * User: VmWindows
 * Date: 12/11/2018
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace Main
{
	/// <summary>
	/// Description of Supervision.
	/// </summary>
	public partial class Supervision : Form
	{
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		MainForm mainform;
		Mapping mapping;
		ArpSpoof arpspoof;
		Thread arpThread; 
		Thread mappingT; 
		List<Control> controlToRemove = new List<Control>();
		
		
		public Supervision(MainForm mainform)
		{
			
			InitializeComponent();
			
			this.mainform=mainform;
			mapping = new Mapping(this.mainform.computer);
			arpspoof = new ArpSpoof(this.mainform);
			arpThread = new Thread(new ThreadStart(arpAnalyse));
			mappingT = new Thread(new ThreadStart(mappingRes));
			
			arpThread.Start();
			mappingT.Start();
			
			
			while(arpThread.IsAlive || mappingT.IsAlive){
				Thread.Sleep(1000);
			}
			
			affichage(mapping.getLips(), mapping.getLmacs());
			
			timer.Interval = 10000;
			timer.Tick += new EventHandler(arpThreadStart);
			timer.Tick += new EventHandler(mappingThreadStart);
			timer.Tick += new EventHandler(mappingTime);
			timer.Enabled=true;
       		timer.Start();
			
		}
		
		public void arpThreadStart(Object sender, EventArgs e){
			timer.Enabled=false;
			if(!arpThread.IsAlive){
				arpThread = new Thread(new ThreadStart(arpAnalyse));
				arpThread.Start();
			}
		}
		
		
		
		public void mappingThreadStart(Object sender, EventArgs e){
			if(!mappingT.IsAlive){
				mappingT = new Thread(new ThreadStart(mappingRes));
				mappingT.Start();
			}
		}
		
		
		
		public void arpAnalyse(){
			arpspoof.getArp(mainform.res);
			arpspoof.analyze();
		}
		
		public void mappingRes(){
			scanRes(this.mainform.res);
			if(File.Exists("Infos/scan.txt")){
				analyseMapping();
			}else{
				MessageBox.Show("Il semblerait qu'une erreur soit survenue durant le scan. Merci de réessayer.\nSi le problème persiste, merci de contacter les developeurs" +
				                "\n(L'application se fermera dans 10 secondes)");
				Thread.Sleep(10000);
				this.Close();
			}
		}
		
		public void scanRes(string res){
			this.mainform.shell.scan(res);
			this.mapping.formatScan(res);
			
		}
		
		public void analyseMapping(){
			this.mapping.analyseMapping();
		}
		
		
		public void mappingTime(Object sender, EventArgs e){
			while(arpThread.IsAlive || mappingT.IsAlive){
				Thread.Sleep(2000);
			}
						
			affichage(mapping.getLips(), mapping.getLmacs());
			
			timer.Enabled=true;
		}
		
		
		
			
			
			
		public void affichage(Dictionary<int, string> Ips, Dictionary<int, string> Macs){
			int res = Ips.Count()+1;
			int count = Ips.Keys.Last();
			
			foreach(Control ctr in Controls){
				if(ctr is Label){
					controlToRemove.Add(ctr);
				}
			}
    			
    			foreach(Control ctr in controlToRemove){
    				Controls.Remove(ctr);
    			}
			
			
			var tempRes = new Label();
			tempRes.Location = new Point(500,40);
    			tempRes.Text = "Reseau : "+this.mainform.res+".0 /24";
    			tempRes.Size = new Size(300,50);
    			tempRes.Font = new Font("defaut",15);
    			tempRes.Name = this.mainform.res;
			Controls.Add(tempRes);
			
			int x = 40;
			int y = 140;
			int z = 165;
			int nbligne=0;
			
			for(int i = 0; i<count;i++){
				if(Ips.Keys.Contains(i)){
					var temp = new Label();
					temp.Location = new Point(x,y);
				
					temp.Text = "Ip : "+Ips[i];
					temp.Name = Ips[i];
				

					Controls.Add(temp);	
				}
				
				if(Macs.Keys.Contains(i)){
					var tempMac = new Label();
					tempMac.Location = new Point(x,z);
					tempMac.Text = "Mac : "+Macs[i];
					
					tempMac.Size = new Size(200,72);
					tempMac.Font = new Font("defaut",7);
					tempMac.Name = Macs[i];
						
				    Controls.Add(tempMac);
					
				    x+=200;
				   	nbligne++;
				}
			   	
			   	if(nbligne==7){
					y+= 100;
					z+= 100;
					x=40;
					nbligne=0;
			   	}
			}
			
			var tempNb = new Label();
			tempNb.Location = new Point(100,80);
			tempNb.Text = "Nombre de machines présentes sur le réseau : " + res;
    			tempNb.Size = new Size(400,50);
    			tempNb.Font = new Font("default",10);
    			tempNb.Name = "nbReseau";
    			
    			Controls.Add(tempNb);
    			
    			affichePc();
		}
		
		
		void affichePc(){
			var tempIpPc= new Label(); //Label pour l'ip de notre pc
    			tempIpPc.Location = new Point(900,50);
    			tempIpPc.Text = "Votre ip : " + mainform.computer.getIp();
    			tempIpPc.Size = new Size(200,20);
    			tempIpPc.Font = new Font("default",8);
    			tempIpPc.Name = "IpPc";
    			Controls.Add(tempIpPc);
    			
    			var tempMacPc= new Label(); //Label pour la mac de notre pc 
    			tempMacPc.Location = new Point(900,70);
    			tempMacPc.Text = "Votre mac : " +mainform.computer.getMac();
    			tempMacPc.Size = new Size(200,75);
    			tempMacPc.Font = new Font("default",8);
    			tempMacPc.Name = "MacPc";
				Controls.Add(tempMacPc);
		}
		
		void AfficherRapportsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Process.Start(@"Rapports");
		}	
		
		void ArreterLaProtectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
			mainform.Close();
		}
		void SupervisionFormClosing(object sender, FormClosingEventArgs e)
		{
			mainform.Close();
		}	
	}
}
