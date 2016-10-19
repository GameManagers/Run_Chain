using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns;  

public class MonsterCommand : SimpleCommand {  
	
	public new const string NAME = "MonsterCommand";  
	
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		switch (notification.Name)
		{
		case NotificationConstant.LevelUp:
			MonsterProxy proxy_1 = (MonsterProxy)Facade.RetrieveProxy("MonsterProxy");  
			proxy_1.ChangeLevel(1); 
			break;
			
		}
	}  
}  