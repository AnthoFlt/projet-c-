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
	
		List<Control> controlToRemove = new List<Control>();
		//Image pcImage = Image.FromFile ("Infos/Icon_pc.png"); 
		
		
		public Supervision(MainForm mainform)
		{
			
			InitializeComponent();
			this.mainform=mainform;
			mapping = new Mapping(this.mainform.computer);
			arpspoof = new ArpSpoof(this.mainform);
			
			arpspoof.getArp(mainform.res);
			arpspoof.analyze();
			/*this.mainform.shell.clearTxt("scan.txt");
			this.mainform.shell.clearTxt("scanForm.txt");
			
			scanRes(this.mainform.res);
			analyseMapping();
			
			affichage(mapping.getLips(), mapping.getLmacs());*/
			
			timer.Interval = 10000;
			timer.Tick += new EventHandler(mappingTime);
			timer.Enabled=true;
       		timer.Start();
			
		}
		
		public void scanRes(string res){
			this.mainform.shell.scan(res);
			this.mapping.formatScan(res);
		}
		
		public void analyseMapping(){
			this.mapping.analyseMapping();
		}
		
		
		public void mappingTime(Object sender, EventArgs e){
			timer.Enabled=false;
			
			//this.mainform.shell.clearTxt("scan.txt");
			//this.mainform.shell.clearTxt("scanForm.txt");
			
			//scanRes(this.mainform.res);
			//analyseMapping();
			arpspoof.getArp(mainform.res);
			arpspoof.analyze();
			Thread.Sleep(1000);
			//affichage(mapping.getLips(), mapping.getLmacs());
			
			timer.Enabled=true;
		}
		
		void ArreterLaProtectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}	
		
			
			
			
		public void affichage(Dictionary<int, string> Ips, Dictionary<int, string> Macs){
				
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
			
			for(int i = 0; i<Ips.Count;i++){
				var temp = new Label();
				temp.Location = new Point(x,y);
				temp.Text = "Ip : "+Ips[i];
				temp.Name = Ips[i];

				Controls.Add(temp);	
				
				
				var tempMac = new Label();
				tempMac.Location = new Point(x,z);
				tempMac.Text = "Mac : "+Macs[i];
				
				tempMac.Size = new Size(200,72);
				tempMac.Font = new Font("defaut",7);
				tempMac.Name = Macs[i];
					
			    Controls.Add(tempMac);
				
			    x+=200;
			   	nbligne++;
			   	
			   	if(nbligne==7){
					y+= 100;
					z+= 100;
					x=40;
					nbligne=0;
			   	}
			}
			
			var tempNb = new Label();
			tempNb.Location = new Point(100,80);
    			tempNb.Text = "Nombre de machine présente sur le réseau : " + Ips.Count;
    			tempNb.Size = new Size(400,50);
    			tempNb.Font = new Font("default",10);
    			tempNb.Name = "nbReseau";
    			
    			Controls.Add(tempNb);
		}	
	}
}
