using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  

public class CameraProxy : Proxy {
	public new const string NAME = "CameraProxy"; 
	public CamerBasic Data { get; set; }  

	public CameraProxy() : base(NAME)  
	{  
		Data = new CamerBasic();   
	} 


	public void setCameraPlayerDistance(GameObject player,GameObject camera){
		Data.player_camera_distance= camera.transform.position - player.transform.position;
	}

	public void CamerMove(){
		SendNotification(NotificationConstant.CameraMediator.CameraFollowMove, Data);  
	}

	public void ReStart(){
		Data.isReStart = true;
	}

}
