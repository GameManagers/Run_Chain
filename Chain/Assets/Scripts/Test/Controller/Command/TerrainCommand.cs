using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns;  

public class TerrainCommand : SimpleCommand {  
	
	public new const string NAME = "TerrainCommand";  
	
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		switch (notification.Name)
		{
		case NotificationConstant.LevelUp:
			TerrainProxy proxy_1 = (TerrainProxy)Facade.RetrieveProxy("TerrainProxy");  
			proxy_1.ChangeLevel(1); 
			break;
			
		}
	}  
}  