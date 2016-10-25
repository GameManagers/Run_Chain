using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  

public class PlayerProxy : Proxy {
	public new const string NAME = "PlayerProxy";  
	public PlayerBasic Data { get; set; }  

	public PlayerProxy() : base(NAME)  
	{  
		Data = new PlayerBasic();  
	} 

	public void Move(){
		SendNotification(NotificationConstant.playerMediator.PlayerRunMove, Data);  
	}

	//以下为和改变数值有关的函数

	/*public void ChangeLevel(int changelevel)  
	{  
		Data.Level += changelevel;  
		SendNotification(NotificationConstant.LevelChange, Data);  
		
	}  */
}
