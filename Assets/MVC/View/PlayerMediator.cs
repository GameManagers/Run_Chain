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
		list.Add (NotificationConstant.playerMediator.JudgeCreatChain);
		list.Add (NotificationConstant.playerMediator.AddCharacterJoint);
		list.Add (NotificationConstant.playerMediator.DeleteCharacterJoint);

		list.Add(NotificationConstant.playerMediator.AtkMediator);
		list.Add(NotificationConstant.playerMediator.HitMediator);



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

		case NotificationConstant.playerMediator.AtkMediator:
		{
			player_ac.SetTrigger(Tags.animator_player.isAtk);
		}break;
		case NotificationConstant.playerMediator.HitMediator:
		{
			player_ac.SetTrigger(Tags.animator_player.isHit);

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

			case NotificationConstant.playerMediator.JudgeCreatChain:
		   {   
			    float chain_angle=pb.angle-90f;
			    Vector3 c=(player.transform.GetChild(0).GetChild(3).position-player.transform.position);//计算倾斜角度，算人物身上点相关的距离
				Vector3 b=Quaternion.AngleAxis(chain_angle, Vector3.forward)*c;
			    Vector3 connect_point=b+player.transform.position;//获取人物身上的连接点

				float y = Tags.chain.chain_position_y - connect_point.y;
			    float distance = y / Mathf.Sin ((Mathf.PI / 180) *pb.angle);

			    if (pb.chain_min_long <= distance && distance <=pb.chain_max_long) { 

					Vector3 temp=player.transform.eulerAngles;//使人物按锁链角度倾斜
					temp.z=chain_angle;
					player.transform.eulerAngles=temp;

				    GameObject prb = Resources.Load<GameObject> (Tags.prb_path.Chain);//取预制体 
				    Transform child_cube=prb.transform.GetChild(0).GetChild(0);
				    Transform child_sphere=prb.transform.GetChild(0);

				    //设置预制体
					Vector3 scale = child_cube.transform.localScale;
					scale.y = distance * 10;
					child_cube.transform.localScale = scale;
					
					Vector3 position = child_cube.transform.localPosition;
					position.y = -scale.y/2;
					child_cube.transform.localPosition = position;
					
					Vector3 sphere_p = child_sphere.transform.localPosition;
					sphere_p.y = scale.y / 10;
					child_sphere.transform.localPosition = sphere_p;
				    
				    player.GetComponent<Player>().CreatChain(connect_point,chain_angle);
		
				}else {
					//获取线的尾端
					Vector3 a = new Vector3 (0, pb.chain_max_long, 0);
					Vector3 d = Quaternion.AngleAxis (chain_angle, Vector3.forward) * a;
					Vector3 end = d + connect_point;
				
					//画线
					GameObject line = Resources.Load<GameObject> (Tags.prb_path.line);//取预制体
					line.GetComponent<Line> ().setPosition (connect_point, end);
				    player.GetComponent<Player>().InstantiateGameOjbect(line);
			    }
			}break;




		   case NotificationConstant.playerMediator.AddCharacterJoint:
			{   
			   PastSingle recive=notification.Body as PastSingle;
			    if(!player.GetComponent<CharacterJoint>()){//添加链接关节
				    CharacterJoint c_joint=player.gameObject.AddComponent<CharacterJoint>();
				    c_joint.connectedBody=recive.obj.GetComponent<Rigidbody>();
					player_rigidboy.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezePositionZ;
				    player_rigidboy.AddForce(Vector3.right*50f);
			   }
				
			}break;

			case NotificationConstant.playerMediator.DeleteCharacterJoint:
			{   
				if (player.GetComponent<CharacterJoint> ()) {
					player.transform.eulerAngles=Vector3.zero;
					player.GetComponent<Player>().DestroyPlayerCharacterJoint(player.GetComponent<CharacterJoint> ());
					player.transform.rotation=Quaternion.Euler(Vector3.zero);
					player_rigidboy.constraints = RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.FreezePositionZ;
				  
			   }
				
			}break;



		}  
		
	} 


}  