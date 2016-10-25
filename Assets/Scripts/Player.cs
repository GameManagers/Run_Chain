using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RunFacade.getInstance.InitGameObject(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.PlayerMove);
	}
}
