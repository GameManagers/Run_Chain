using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  
using PureMVC.Interfaces;  

public class RunFacade : Facade,IFacade {
	private static RunFacade instance;
	public static RunFacade getInstance{//单例模式
		get{
			if(instance==null) instance=new RunFacade();
			return instance;
		}
	}

	RunFacade(){
	}

	public void InitGameObject(GameObject obj){
		switch (obj.name) {
		case Tags.obj_name.Player:
		{
			addRegisterPlayerCommand();
			RegisterProxy(new PlayerProxy());
			RegisterMediator(new PlayerMediator(obj)); 
		}break;
		case Tags.obj_name.Main_Camera:
		{
			addRegisterCameraCommand();
			RegisterProxy(new CameraProxy());
			RegisterMediator(new CameraMediator(obj)); 
		}break;
		}
	}



	void addRegisterPlayerCommand(){
		RegisterCommand(NotificationConstant.playerCommand.PlayerMove,typeof(PlayerCommand));
	}

	void addRegisterCameraCommand(){
		RegisterCommand(NotificationConstant.CameraCommand.CameraMove,typeof(CameraCommand));
	}

	public void sendNotificationCommand(string name){
		SendNotification(name);  
	}


}
