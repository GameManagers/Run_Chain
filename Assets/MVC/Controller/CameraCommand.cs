using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns; 

public class CameraCommand : SimpleCommand{  
	
	public new const string NAME = "CameraCommand";  
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		switch (notification.Name) {
		case NotificationConstant.CameraCommand.CameraMove:
		{
			CameraProxy proxy = (CameraProxy)Facade.RetrieveProxy("CameraProxy");//通过名字获取Proxy
			proxy.CamerMove();
		}break;
			
		}  
	}
}  