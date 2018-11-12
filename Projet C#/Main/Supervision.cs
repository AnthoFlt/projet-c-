/*
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
		public Supervision(MainForm mainform)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.mainform=mainform;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		
			label1.Text=this.mainform.computer.getIp();
		}
		
		
		
	}
}
