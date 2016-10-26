using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns; 

public class MonsterCommand : SimpleCommand{  
	
	public new const string NAME = "MonsterCommand";  
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		MonsterProxy proxy = (MonsterProxy)Facade.RetrieveProxy("MonsterProxy");//通过名字获取Proxy
		
		switch (notification.Name) {
		
			case NotificationConstant.MonsterCommand.SetMonsters:{
			   PastMonsters past=notification.Body as PastMonsters;
			   proxy.setMonsterBasic(past);
			}break;

			case NotificationConstant.MonsterCommand.MonsterAtk:{
				proxy.atk();
			}break;
		

		}  
	}
}  