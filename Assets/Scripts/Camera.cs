using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	void Start () {
		RunFacade.getInstance.InitGameObject(this.gameObject);
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.CameraMediator.SetCameraPlayerDistance);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.CameraCommand.CameraMove);
	}

	public GameObject getPlayer(){
		return player;
	}
}
