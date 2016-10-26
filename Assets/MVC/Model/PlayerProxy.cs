﻿using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  

public class PlayerProxy : Proxy {
	public new const string NAME = "PlayerProxy";  
	public PlayerBasic Data { get; set; }  
	public Tool tool;
	public PlayerProxy() : base(NAME)  
	{  
		Data = new PlayerBasic();  
		tool = new Tool ();
	} 

	public void Move(){
		if(Data.curPlayState==PlayerState.Running || Data.curPlayState==PlayerState.Jumping){
			SendNotification(NotificationConstant.playerMediator.DeleteCharacterJoint, Data);  
			SendNotification(NotificationConstant.playerMediator.PlayerRunMove, Data);  
		}

	}

	public void Jump(){
		if (Data.curPlayState != PlayerState.Jumping) {
			Data.CurJump = 0;
			SendNotification(NotificationConstant.playerMediator.ResetJumpAnimator, Data);  
		}
		if (Data.CurJump<2) {
			Data.CurJump+=1;
			Data.curPlayState = PlayerState.Jumping;
			SendNotification(NotificationConstant.playerMediator.JumpMediator, Data);  
		}
	}	

	public void CollisionBase(){
		if(Data.curPlayState==PlayerState.Jumping){
			Data.CurJump = 0;
			Data.curPlayState = PlayerState.Running;
			SendNotification(NotificationConstant.playerMediator.ResetJumpAnimator, Data);  
		}
	}

	public void Died(){
		Data.curPlayState = PlayerState.Died;
		SendNotification(NotificationConstant.playerMediator.ReStart, Data);  
	}

	public void CollisionStay(){

		Data.timer += Time.deltaTime;
		if (Data.timer > 1)
		{
			SendNotification(NotificationConstant.playerMediator.ReStart, Data);  
		}
	}

	public void MouseDown(){
		Data.mouse_down=tool.RayPointBg ();
	}

	public void MouseUp(){
		Vector3 hit=tool.RayPointBg ();
		if(!Data.mouse_down.Equals(Vector3.zero) && !hit.Equals(Vector3.zero) && (hit-Data.mouse_down).magnitude>1f){
			Vector3 direction=(hit-Data.mouse_down).normalized;//松开处与人物的角度方向
			float angle = tool.getAngle (direction,Vector3.right);
			if (direction.x >= 0 && direction.y >= 0 && direction.z >= 0) {
				Data.angle=angle;
				SendNotification(NotificationConstant.playerMediator.JudgeCreatChain, Data);  
			}
		}
		Data.mouse_down=Vector3.zero;
	}

	public void OnChain(PastSingle past){
		Data.curPlayState=PlayerState.OnChain;
		SendNotification(NotificationConstant.playerMediator.AddCharacterJoint, past);  
	}

	public void inAtkArea(PastSingle past){
		Data.TriggerTimes += 1;
		if (Data.TriggerTimes == 1) {
			Data.curMonster=past.obj;
			PastBtnColor pastColor=new PastBtnColor(Color.red);
			SendNotification(NotificationConstant.UIMediator.ChangeButtonColor, pastColor);  
		}
		if(Data.TriggerTimes==2) {
			PastBtnColor pastColor=new PastBtnColor(Color.yellow);
			SendNotification(NotificationConstant.UIMediator.ChangeButtonColor, pastColor);  
			Data.TriggerTimes=0;
		} 
	}

	public void JuageMonsterDis(PastSingle past){
		if (Data.curMonster!=null && Data.curMonster.transform.position.x < past.obj.transform.position.x) {
			Data.curMonster=null;
			Data.TriggerTimes=0;
			PastBtnColor pastColor=new PastBtnColor(Color.white);
			SendNotification(NotificationConstant.UIMediator.ChangeButtonColor, pastColor);  
		}
	}

	public void atkMonster(PastSingle past){
		if (Data.curMonster!= null) {

			if(Data.curMonster.name.Equals(Tags.monster_type.smallBoss)){
				Data.curMonster.GetComponent<SmallBoss>().Rebound(Data.smallBossRe);
			}else{
				past.obj.GetComponent<Player>().DestroyGameObject(Data.curMonster);
			}

			Data.Monster+=1;
			Data.TriggerTimes=0;
			Data.curMonster=null;
			SendNotification(NotificationConstant.UIMediator.ChangeMonsterCount, Data);
			PastBtnColor pastColor=new PastBtnColor(Color.white);
			SendNotification(NotificationConstant.UIMediator.ChangeButtonColor, pastColor);
		}
	}

	public void ChangeHp(PastSingle past){
		if (past.i < 0) {
			int temp=past.i+Data.Cover;
			if(temp<0) Data.Hp += temp;
		}else Data.Hp += past.i;

		if (Data.Hp > 100)
			Data.Hp = 100;
		if(Data.Hp < 0)
			SendNotification(NotificationConstant.playerMediator.ReStart);

		//改变UI

		SendNotification(NotificationConstant.UIMediator.ChangeHpUI, Data);
	}
	


}