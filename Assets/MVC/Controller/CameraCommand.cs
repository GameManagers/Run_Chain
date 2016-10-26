using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns; 

public class CameraCommand : SimpleCommand{  
	
	public new const string NAME = "CameraCommand";  
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		CameraProxy proxy = (CameraProxy)Facade.RetrieveProxy("CameraProxy");//通过名字获取Proxy

		switch (notification.Name) {
		case NotificationConstant.CameraCommand.CameraMove:
		{
			proxy.CamerMove();
		}break;

		case NotificationConstant.CameraCommand.ReStartCameraCommond:
		{
			proxy.ReStart();
		}break;


			
		}  
	}
}  