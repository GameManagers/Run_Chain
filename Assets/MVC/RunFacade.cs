using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  
using PureMVC.Interfaces;  

public class RunFacade : Facade,IFacade {
	static RunFacade instance;
	public static RunFacade getInstance{//单例模式
		get{
			if(instance==null) 
				instance=new RunFacade();
			return instance;
		}
	}


	public void InitGameObject(GameObject obj){
		switch (obj.tag) {
		case Tags.tag.Player:
		{
			addRegisterPlayerCommand();
			RegisterProxy(new PlayerProxy());
			RegisterMediator(new PlayerMediator(obj)); 
		}break;
		case Tags.tag.MainCamera:
		{
			addRegisterCameraCommand();
			RegisterProxy(new CameraProxy());
			RegisterMediator(new CameraMediator(obj)); 
		}break;
		case Tags.tag.UI:
		{
			addRegisterUICommand();
			RegisterProxy(new UIProxy());
			RegisterMediator(new UIMediator(obj)); 
		}break;

		case Tags.tag.Terrain:
		{
			addRegisterTerrainCommand();
			RegisterProxy(new TerrainProxy());
			RegisterMediator(new TerrainMediator(obj)); 
		}break;

		case Tags.tag.Monster:
		{
			addRegisterMonsterCommand();
			RegisterProxy(new MonsterProxy());
			RegisterMediator(new MonsterMdiator(obj)); 
		}break;

		}
	}


	void addRegisterPlayerCommand(){
		RegisterCommand(NotificationConstant.playerCommand.PlayerMove,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.JumpCommond,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.CollisionBaseCommond,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.DiedCommond,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.CollisionStay,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.MouseLeftDown,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.MouseLeftUP,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.AtkMonsterArea,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.JuageMonsterDistance,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.AtkMonster,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.ChangeHp,typeof(PlayerCommand));

		RegisterCommand(NotificationConstant.playerCommand.ChainStateToFallState,typeof(PlayerCommand));
		RegisterCommand(NotificationConstant.playerCommand.ResetJumpData,typeof(PlayerCommand));

	}

	void addRegisterCameraCommand(){
		RegisterCommand(NotificationConstant.CameraCommand.CameraMove,typeof(CameraCommand));
		RegisterCommand(NotificationConstant.CameraCommand.ReStartCameraCommond,typeof(CameraCommand));
	}



	void addRegisterTerrainCommand(){
		RegisterCommand(NotificationConstant.TerrainCommand.SetMapBasic,typeof(TerrainCommand));
		RegisterCommand(NotificationConstant.TerrainCommand.InitMap,typeof(TerrainCommand));
		RegisterCommand(NotificationConstant.TerrainCommand.UpdateMap,typeof(TerrainCommand));
	}

	void addRegisterUICommand(){
		
	}
	
	void addRegisterMonsterCommand(){
		RegisterCommand(NotificationConstant.MonsterCommand.SetMonsters,typeof(MonsterCommand));
		RegisterCommand(NotificationConstant.MonsterCommand.MonsterAtk,typeof(MonsterCommand));
		RegisterCommand(NotificationConstant.MonsterCommand.SetMonsterFirstFloat,typeof(MonsterCommand));
	}


	public void sendNotificationCommand(string name){
          SendNotification(name);  
	}

	public void sendNotificationCommand(string name,object past){
	   SendNotification(name,past);  
	}


}
