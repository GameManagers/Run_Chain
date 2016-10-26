using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns; 

public class TerrainCommand : SimpleCommand{  
	
	public new const string NAME = "TerrainCommand";  
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		TerrainProxy proxy = (TerrainProxy)Facade.RetrieveProxy("TerrainProxy");//通过名字获取Proxy
		
		switch (notification.Name) {
		case NotificationConstant.TerrainCommand.SetMapBasic:
		{
			PastTerrains past=notification.Body as PastTerrains;
			proxy.SetMapBasic(past);
		}break;

		case NotificationConstant.TerrainCommand.InitMap:
		{
			proxy.InitMap();
		}break;

		case NotificationConstant.TerrainCommand.UpdateMap:
		{
			PastSingle past=notification.Body as PastSingle;
			proxy.UpdateMap(past);
		}break;
			
		}  
	}
}  