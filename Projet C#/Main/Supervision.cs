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

namespace Main
{
	/// <summary>
	/// Description of Supervision.
	/// </summary>
	public partial class Supervision : Form
	{
		Timer timer = new Timer();
		MainForm mainform;
		Mapping mapping;
		Dictionary<string, Label> lbl = new Dictionary<string, Label>();
		Image pcImage = Image.FromFile ("Infos/Icon_pc.png"); 
		
		public Supervision(MainForm mainform)
		{
			InitializeComponent();
			this.mainform=mainform;
			mapping = new Mapping(this.mainform.computer);
			
			this.mainform.shell.clearTxt("scan.txt");
			this.mainform.shell.clearTxt("scanForm.txt");
			
			scanRes(this.mainform.res);
			analyseMapping();
			affichage(mapping.getLips(), mapping.getLmacs());
			
			/*timer.Interval = 10000;
			timer.Tick += new EventHandler(mappingTime);
			timer.Enabled=true;
       		timer.Start();*/
			
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
			this.mainform.shell.clearTxt("scan.txt");
			this.mainform.shell.clearTxt("scanForm.txt");
			
			scanRes(this.mainform.res);
			analyseMapping();
			//affichage(mapping.getLips(), mapping.getLmacs());
			timer.Enabled=true;
		}
		
		void ArreterLaProtectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}	
		
		
		public void affichage(Dictionary<int, string> Ips, Dictionary<int, string> Macs){
			int x = 40;
			int y = 140;
			int z = 165;
			int nbligne=0;
			for(int i = 0; i<Ips.Count;i++){
				if(!lbl.ContainsKey(Ips[i])){
					var temp = new Label();
					temp.Location = new Point(x,y);
    					temp.Text = "Ip : "+Ips[i];
   
    					Controls.Add(temp);
				    lbl.Add(Ips[i],temp);
				    nbligne++;
				}
				
				if(!lbl.ContainsKey(Macs[i])){
					var temp = new Label();
					temp.Location = new Point(x,z);
					temp.Text = "Mac : "+Macs[i];
					temp.Size = new Size(200,72);
    					temp.Font = new Font("defaut",7);
    					Controls.Add(temp);
				    lbl.Add(Macs[i],temp);
				    x+=200;
				   
				}
				
				if(nbligne==7){
					y+= 100;
					z+= 100;
					x=40;
					nbligne=0;
				}	
			}
			
			var tempRes = new Label();
			tempRes.Location = new Point(450,40);
    			tempRes.Text = "Reseau : "+this.mainform.res+".0 /24";
    			tempRes.Size = new Size(300,50);
    			tempRes.Font = new Font("defaut",15);
    			Controls.Add(tempRes);
			lbl.Add("Res",tempRes);
			
		}
		
	}
}
