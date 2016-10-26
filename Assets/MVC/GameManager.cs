using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	void Start () {
		RunFacade.getInstance.InitGameObject(player);

	}
	
	// Update is called once per frame
	void Update () {
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.PlayerMove);
	}


}
