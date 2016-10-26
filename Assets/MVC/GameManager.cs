using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		pressKey ();//按键相关
	}
	
	void pressKey(){
		
		if (Input.GetKeyDown (KeyCode.Space)){/*空格键跳跃*/
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.JumpCommond);
		}
		
		//鼠标获取锁链角度
		if (Input.GetMouseButtonDown (0)) {
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.MouseLeftDown);
		}
		
		if (Input.GetMouseButtonUp (0)) {
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.MouseLeftUP);
		}
	}





}
