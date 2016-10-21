using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns;  

public class PlayerCommand : SimpleCommand {  
	
	public new const string NAME = "PlayerCommand";  
	
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		switch (notification.Name)
		{
		case NotificationConstant.LevelUp:
			PlayerProxy proxy_1 = (PlayerProxy)Facade.RetrieveProxy("PlayerProxy");  
			proxy_1.ChangeLevel(1); 
			break;
			
		}
	}  
}  