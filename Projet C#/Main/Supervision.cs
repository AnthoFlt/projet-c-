﻿/*
 * Created by SharpDevelop.
 * User: VmWindows
 * Date: 12/11/2018
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Main
{
	/// <summary>
	/// Description of Supervision.
	/// </summary>
	public partial class Supervision : Form
	{
		MainForm mainform;
		Mapping mapping;
		public Supervision(MainForm mainform)
		{
			InitializeComponent();
			this.mainform=mainform;
			
			mapping = new Mapping(this.mainform.computer);
		
			while(true){
				this.mainform.shell.clearTxt("scan.txt");
				this.mainform.shell.clearTxt("scanForm.txt");
				System.Threading.Thread.Sleep(1000);
				scanRes(this.mainform.res);
				System.Threading.Thread.Sleep(2500);
				analyseMapping();
				System.Threading.Thread.Sleep(10000);
			}
			
		}
		
		public void scanRes(string res){
			this.mainform.shell.scan(res);
			System.Threading.Thread.Sleep(2500);
			this.mapping.formatScan(res);
		}
		
		public void analyseMapping(){
			this.mapping.analyseMapping();
		}
		
	}
}