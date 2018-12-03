/*
 * Crée par SharpDevelop.
 * Utilisateur: magic
 * Date: 22/10/2018
 * Heure: 19:42
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace Main
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.ListBox lbInfo;
		private System.Windows.Forms.Label lblTitre;
		private System.Windows.Forms.ComboBox cbInterface;
		private System.Windows.Forms.ListBox lbProtection;
		private System.Windows.Forms.Button btActiver;
		
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
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.lbInfo = new System.Windows.Forms.ListBox();
			this.lblTitre = new System.Windows.Forms.Label();
			this.cbInterface = new System.Windows.Forms.ComboBox();
			this.lbProtection = new System.Windows.Forms.ListBox();
			this.btActiver = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbEmail
			// 
			this.tbEmail.Location = new System.Drawing.Point(63, 252);
			this.tbEmail.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(363, 35);
			this.tbEmail.TabIndex = 0;
			this.tbEmail.Text = "Rentrez votre e-mail";
			// 
			// lbInfo
			// 
			this.lbInfo.FormattingEnabled = true;
			this.lbInfo.ItemHeight = 29;
			this.lbInfo.Location = new System.Drawing.Point(525, 252);
			this.lbInfo.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(375, 323);
			this.lbInfo.TabIndex = 1;
			// 
			// lblTitre
			// 
			this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitre.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTitre.Location = new System.Drawing.Point(161, 36);
			this.lblTitre.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.lblTitre.Name = "lblTitre";
			this.lblTitre.Size = new System.Drawing.Size(602, 85);
			this.lblTitre.TabIndex = 2;
			this.lblTitre.Text = "OPSIEProtect";
			this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbInterface
			// 
			this.cbInterface.FormattingEnabled = true;
			this.cbInterface.Location = new System.Drawing.Point(65, 149);
			this.cbInterface.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this.cbInterface.Name = "cbInterface";
			this.cbInterface.Size = new System.Drawing.Size(835, 37);
			this.cbInterface.TabIndex = 3;
			this.cbInterface.Text = "Choississez une interface";
			// 
			// lbProtection
			// 
			this.lbProtection.FormattingEnabled = true;
			this.lbProtection.ItemHeight = 29;
			this.lbProtection.Location = new System.Drawing.Point(63, 366);
			this.lbProtection.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this.lbProtection.Name = "lbProtection";
			this.lbProtection.Size = new System.Drawing.Size(363, 207);
			this.lbProtection.TabIndex = 4;
			// 
			// btActiver
			// 
			this.btActiver.Location = new System.Drawing.Point(65, 631);
			this.btActiver.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this.btActiver.Name = "btActiver";
			this.btActiver.Size = new System.Drawing.Size(838, 74);
			this.btActiver.TabIndex = 5;
			this.btActiver.Text = "Lancer la protection";
			this.btActiver.UseVisualStyleBackColor = true;
			this.btActiver.Click += new System.EventHandler(this.BtActiverClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(964, 792);
			this.Controls.Add(this.btActiver);
			this.Controls.Add(this.lbProtection);
			this.Controls.Add(this.cbInterface);
			this.Controls.Add(this.lblTitre);
			this.Controls.Add(this.lbInfo);
			this.Controls.Add(this.tbEmail);
			this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this.Name = "MainForm";
			this.Text = "OPSIEProtect";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
