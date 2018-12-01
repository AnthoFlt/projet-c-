/*
 * Created by SharpDevelop.
 * User: VmWindows
 * Date: 31/10/2018
 * Time: 15:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Main
{
	/// <summary>
	/// Description of Attacker.
	/// </summary>
	public class Attacker
	{
		private string ip;
		private string mac;
		private string hourAttack;
		
		
		public Attacker(string ip, string mac) //Constructeur
		{
			this.ip = ip;
			this.mac = mac;
			this.hourAttack = DateTime.Now.ToString("dd/MM/yy HH:mm");
		}
		
		
		//Getter & Setter
		public string getMac(){
			return this.mac;
		}
		
		public void setMac(string mac){
			this.mac = mac;
		}
		
		public string getIp(){
			return this.ip;
		}
		
		public void setIp(string ip){
			this.ip=ip;
		}
		
		public string gethourAttack(){
			return this.hourAttack;
		}
		
		public void sethourAttack(string hourAttack){
			this.hourAttack=hourAttack;
		}
		
	}
}