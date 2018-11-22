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
		
		public Supervision(MainForm mainform)
		{
			InitializeComponent();
			this.mainform=mainform;
			mapping = new Mapping(this.mainform.computer);
			
			//this.mainform.shell.clearTxt("scan.txt");
			//this.mainform.shell.clearTxt("scanForm.txt");
			
			scanRes(this.mainform.res);
			//analyseMapping();
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
			timer.Enabled=true;
		}
		
		void ArreterLaProtectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
	}
}
