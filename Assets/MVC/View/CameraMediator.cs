using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using PureMVC.Patterns;  
using UnityEngine.UI;  

public class CameraMediator : Mediator{  
	
	public new const string NAME = "CameraMediator";  
	 
	static GameObject Main_Camera;  //必须加static，否则重新游戏时会出错
	static GameObject player;
	

	public CameraMediator(GameObject root) : base(NAME)  
	{  
		Main_Camera = root;
		player = GameUtility.GetComponent<MainCamera> (root).getPlayer ();
	}  
	
	public override IList<string> ListNotificationInterests()  
	{  
		IList<string> list = new List<string>();  
		//添加和显示有关的命令
		list.Add (NotificationConstant.CameraMediator.CameraFollowMove);
		list.Add (NotificationConstant.CameraMediator.SetCameraPlayerDistance);

		return list;  
	}  
	
	public override void HandleNotification(PureMVC.Interfaces.INotification notification)  
	{  
		CamerBasic cb=notification.Body as CamerBasic;
		switch (notification.Name)  
		{ 
			//执行和显示有关的命令

		/*初始时获取player和摄像机的相对位置*/
		case NotificationConstant.CameraMediator.SetCameraPlayerDistance:
		{  
			CameraProxy proxy = (CameraProxy)Facade.RetrieveProxy("CameraProxy");
			proxy.setCameraPlayerDistance(player,Main_Camera);
		}break;


		case NotificationConstant.CameraMediator.CameraFollowMove:
		{   
			if(!cb.isReStart){
				Main_Camera.transform.position = cb.player_camera_distance+new Vector3(player.transform.position.x,0,0);
			}

		}break;

		}  
		
	}  

	  
}  