using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns; 

public class PlayerCommand : SimpleCommand{  
	
	public new const string NAME = "PlayerCommand";  

	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		switch (notification.Name) {
		case NotificationConstant.playerCommand.PlayerMove:
		{
			PlayerProxy proxy = (PlayerProxy)Facade.RetrieveProxy("PlayerProxy");//通过名字获取Proxy
			proxy.Move();
		}break;

		}  
	}
}  