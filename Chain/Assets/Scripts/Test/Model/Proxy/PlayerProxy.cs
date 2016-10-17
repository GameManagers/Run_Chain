using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  

public class PlayerProxy :Proxy{
	public new const string NAME = "PlayerProxy";  
	public PlayerInfo Data { get; set; }  
	
	public PlayerProxy() : base(NAME)  
	{  
		Data = new PlayerInfo(0);  
	} 
	
	public void ChangeLevel(int changelevel)  
	{  
		Data.Level += changelevel;  
		SendNotification(NotificationConstant.LevelChange, Data);  
		
	}  
	public void movecube(){

	}
	
	
}
