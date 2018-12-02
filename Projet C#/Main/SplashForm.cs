/*
 * Created by SharpDevelop.
 * User: Anthony
 * Date: 02/12/2018
 * Time: 16:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Main
{
	/// <summary>
	/// Description of SplashForm.
	/// </summary>
	public partial class SplashForm : Form
	{
		bool ok=false;
		public SplashForm()
		{
		
			InitializeComponent();
		
		}
		
		
		void TimerTick(object sender, EventArgs e)
		{
			progressBar1.Increment(1);
			if(progressBar1.Value == 100){
				timer.Stop();
				ok=true;
				Thread.Sleep(500);
				Close();
			}
		}
		
		public bool getOk(){
			return ok;
		}
	}
}
