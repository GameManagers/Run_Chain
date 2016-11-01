using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using PureMVC.Patterns;  
using UnityEngine.UI;  

public class PlayerMediator : Mediator{  
	
	public new const string NAME = "PlayerMediator";  

	static GameObject player;   
	static Animator player_ac;
	static Rigidbody player_rigidboy; 


	

	public PlayerMediator(GameObject root) : base(NAME)  
	{  
		player = root;
		player_ac=GameUtility.GetComponent<Animator>(root);
		player_rigidboy=GameUtility.GetComponent<Rigidbody>(root);


	}  
	
	public override IList<string> ListNotificationInterests()  
	{  
		IList<string> list = new List<string>();  
		//添加和显示有关的命令
		list.Add (NotificationConstant.playerMediator.PlayerRunMove);
		list.Add (NotificationConstant.playerMediator.JumpMediator);
		list.Add (NotificationConstant.playerMediator.ResetJumpAnimator);
		list.Add (NotificationConstant.playerMediator.ReStart);


		list.Add (NotificationConstant.playerMediator.CreatRope);
		list.Add (NotificationConstant.playerMediator.ChangePlayerCompnentState);
		list.Add (NotificationConstant.playerMediator.AddPlayerJointCompnent);
		list.Add (NotificationConstant.playerMediator.DeletePlayerCompnent);


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

				
			case NotificationConstant.playerMediator.JumpMediator:
			{   
				if(player_ac.GetBool (Tags.animator_player.Jump)==false){
					player_rigidboy.velocity=new Vector3(0,pb.jump_Velocity,0);
					player_ac.SetBool(Tags.animator_player.Jump,true);
				}else if(player_ac.GetBool (Tags.animator_player.Jump2)==false){//二段跳
				    player_rigidboy.velocity=new Vector3(0,pb.jump_Velocity,0);
				    player_ac.SetBool(Tags.animator_player.Jump2,true);
				    player_ac.SetBool(Tags.animator_player.Jump,false);
				} 
			}break;


		case NotificationConstant.playerMediator.ResetJumpAnimator:
			{   
			   player_ac.SetBool (Tags.animator_player.Jump, false);
			   player_ac.SetBool (Tags.animator_player.Jump2, false);
			}break;

			case NotificationConstant.playerMediator.ReStart:
			{   
			   Application.LoadLevel(Application.loadedLevel);
			}break;


			case NotificationConstant.playerMediator.CreatRope:
			{   
			    GameObject obj=Resources.Load(Tags.prb_path.Rope) as GameObject;
			    obj.transform.position=player.transform.GetChild(Tags.PlayerChilds.Send_target).position;
			    obj.transform.eulerAngles=new Vector3(0,0,pb.angle-90f);
			    player.GetComponent<Player>().InstantiateGameOjbect(obj);

			}break;

			case NotificationConstant.playerMediator.ChangePlayerCompnentState:
			{   
			    PastPlayerCompenetState recive=notification.Body as PastPlayerCompenetState;
				player.GetComponent<Rigidbody>().isKinematic=recive.isKinematic;
				player.GetComponent<Rigidbody>().mass=recive.mass;
			    player.GetComponent<CapsuleCollider> ().isTrigger=recive.isTrigger;
			}break;

		     case NotificationConstant.playerMediator.AddPlayerJointCompnent:
			{   
			    PastAddJointCompnent recive=notification.Body as PastAddJointCompnent;
				if(recive.Compnent_type.Equals("FixedJoint")){
				   FixedJoint fiexd=player.AddComponent<FixedJoint>();
				   fiexd.connectedBody=recive.connect;
				}
			}break;

			case NotificationConstant.playerMediator.DeletePlayerCompnent:
			{   
				if(player.GetComponent<FixedJoint> ()){
				player.GetComponent<Player>().DestroyObject(player.GetComponent<FixedJoint> ());
				}
			}break;



		}  
		
	} 


}  