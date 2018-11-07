/*
 * Created by SharpDevelop.
 * User: VmWindows
 * Date: 07/11/2018
 * Time: 17:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Main
{
	partial class Supervision
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem afficherLesRapportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopperLaProtectionToolStripMenuItem;
		private System.Windows.Forms.TextBox tbIp;
		private System.Windows.Forms.TextBox tbMac;
		private System.Windows.Forms.TextBox tbMail;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.afficherLesRapportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopperLaProtectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbIp = new System.Windows.Forms.TextBox();
			this.tbMac = new System.Windows.Forms.TextBox();
			this.tbMail = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label1.Location = new System.Drawing.Point(206, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(461, 57);
			this.label1.TabIndex = 0;
			this.label1.Text = "Console de supervision";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.optionToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(890, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// optionToolStripMenuItem
			// 
			this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.afficherLesRapportToolStripMenuItem,
			this.stopperLaProtectionToolStripMenuItem});
			this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
			this.optionToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionToolStripMenuItem.Text = "Options";
			// 
			// afficherLesRapportToolStripMenuItem
			// 
			this.afficherLesRapportToolStripMenuItem.Name = "afficherLesRapportToolStripMenuItem";
			this.afficherLesRapportToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.afficherLesRapportToolStripMenuItem.Text = "Afficher les rapport";
			// 
			// stopperLaProtectionToolStripMenuItem
			// 
			this.stopperLaProtectionToolStripMenuItem.Name = "stopperLaProtectionToolStripMenuItem";
			this.stopperLaProtectionToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.stopperLaProtectionToolStripMenuItem.Text = "Stopper la protection";
			// 
			// tbIp
			// 
			this.tbIp.Location = new System.Drawing.Point(43, 104);
			this.tbIp.Name = "tbIp";
			this.tbIp.Size = new System.Drawing.Size(154, 20);
			this.tbIp.TabIndex = 2;
			// 
			// tbMac
			// 
			this.tbMac.Location = new System.Drawing.Point(43, 152);
			this.tbMac.Name = "tbMac";
			this.tbMac.Size = new System.Drawing.Size(154, 20);
			this.tbMac.TabIndex = 3;
			// 
			// tbMail
			// 
			this.tbMail.Location = new System.Drawing.Point(43, 203);
			this.tbMail.Name = "tbMail";
			this.tbMail.Size = new System.Drawing.Size(154, 20);
			this.tbMail.TabIndex = 4;
			// 
			// Supervision
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(890, 431);
			this.Controls.Add(this.tbMail);
			this.Controls.Add(this.tbMac);
			this.Controls.Add(this.tbIp);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Supervision";
			this.Text = "Supervision";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
