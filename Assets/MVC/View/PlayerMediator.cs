using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using PureMVC.Patterns;  
using UnityEngine.UI;  

public class PlayerMediator : Mediator{  
	
	public new const string NAME = "PlayerMediator";  

	GameObject player;
	Animator player_ac;
	Rigidbody player_rigidboy;  
	
	
	public PlayerMediator(GameObject root) : base(NAME)  
	{  
		//levelText = GameUtility.GetChildComponent<Text>(root, "Text/LevelText");  //通过名字
		player = root;
		player_ac=GameUtility.GetComponent<Animator>(root);
		player_rigidboy=GameUtility.GetComponent<Rigidbody>(root);
	}  
	
	public override IList<string> ListNotificationInterests()  
	{  
		IList<string> list = new List<string>();  
		//添加和显示有关的命令
		list.Add (NotificationConstant.playerMediator.PlayerRunMove);

		return list;  
	}  
	
	public override void HandleNotification(PureMVC.Interfaces.INotification notification)  
	{  
		PlayerBasic pb=notification.Body as PlayerBasic;
		switch (notification.Name)  
		{  
			//执行和显示有关的命令
			case NotificationConstant.playerMediator.PlayerRunMove:
			{   
			   player.transform.Translate (Vector3.right*pb.run_speed* Time.deltaTime,Space.World);
			}break;


		}  
		
	}  
}  