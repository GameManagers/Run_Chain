using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using PureMVC.Patterns;  
using UnityEngine.UI;  

public class MonsterMdiator : Mediator{  
	
	public new const string NAME = "MonsterMdiator";  

	static GameObject Player;
	float fly_x;
	float water_x;

	public MonsterMdiator(GameObject root) : base(NAME)  
	{  
		Player = GameObject.FindGameObjectWithTag (Tags.tag.Player);
	}  
	
	public override IList<string> ListNotificationInterests()  
	{  
		IList<string> list = new List<string>();  
		//添加和显示有关的命令
		list.Add (NotificationConstant.MonsterMediator.ChangeMonsterCompent);
		list.Add (NotificationConstant.MonsterMediator.ChangeMonsterAnimation);
		list.Add (NotificationConstant.MonsterMediator.BossMove);
		list.Add (NotificationConstant.MonsterMediator.MonsterMove);
		list.Add (NotificationConstant.MonsterMediator.ChangeBossColor);
		list.Add (NotificationConstant.MonsterMediator.SpawnSmallBoss);
		
		return list;  
	}  
	
	public override void HandleNotification(PureMVC.Interfaces.INotification notification)  
	{  
		
		switch (notification.Name)  
		{ 
			//执行和显示有关的命令
		case NotificationConstant.MonsterMediator.ChangeMonsterCompent:
		{
			PastMonsterCompent recive=notification.Body as PastMonsterCompent;
			GameObject MonsterItem=recive.monster;
			MonsterItem.GetComponent<Rigidbody>().isKinematic = recive.isKinematic;
			MonsterItem.GetComponent<CapsuleCollider>().isTrigger = recive.isTrigger;
		}break;

		case NotificationConstant.MonsterMediator.ChangeMonsterAnimation:
		{
			PastAnimator recive=notification.Body as PastAnimator;
			GameObject MonsterItem=recive.monster;
			switch(recive.type){
			case Tags.animator_type.Trigger: MonsterItem.GetComponent<Animator>().SetTrigger(recive.name);	break;
			case Tags.animator_type.Bool: MonsterItem.GetComponent<Animator>().SetBool(recive.name,recive.boolState);	break;
			}

		}break;


		case NotificationConstant.MonsterMediator.MonsterMove:
		{
			PastSingle recive=notification.Body as PastSingle;
			switch(recive.obj.name){
				case Tags.monster_type.fly:{
				    Vector3 fly_position = recive.obj.transform.position;
					fly_position.y = 1.5f + (float)Mathf.Sin(fly_x) * 0.5f;
				    recive.obj.transform.position = fly_position;
				    fly_x=0;
				}break;
					
				case Tags.monster_type.water:{
				    water_x+= Time.deltaTime;
				   if (water_x >= 3.5)
					{
					  recive.obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
					  water_x = 0;
					}	
				}break;

				case Tags.monster_type.Boss:{
				   Vector3 pos=new Vector3(Player.transform.position.x+recive.f,recive.obj.transform.position.y,recive.obj.transform.position.z);
				   recive.obj.transform.position = pos;
				}break;

				case Tags.monster_type.smallBoss:{
				   recive.obj.GetComponent<Rigidbody>().AddForce(recive.vect);
				}break;

			}
			
		}break;

		case NotificationConstant.MonsterMediator.ChangeBossColor:
		{
			PastSingle recive=notification.Body as PastSingle;
			Renderer rend=recive.obj.GetComponent<Renderer>();
			rend.material.shader = Shader.Find("Specular");
			rend.material.SetColor("_SpecColor", recive.c);
			
		}break;

		case NotificationConstant.MonsterMediator.SpawnSmallBoss:
		{
			PastSingle recive=notification.Body as PastSingle;

			
		}break;

		

			
			
		}  
		
	}  
	
	
}  