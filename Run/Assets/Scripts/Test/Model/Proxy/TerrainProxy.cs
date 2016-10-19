using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  

public class TerrainProxy :Proxy{
	public new const string NAME = "TerrainProxy";  
	public PlayerInfo Data { get; set; }  
	
	public TerrainProxy() : base(NAME)  
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
