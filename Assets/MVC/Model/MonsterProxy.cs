using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  

public class MonsterProxy : Proxy {
	public new const string NAME = "MonsterProxy"; 
	public MonsterBasic Data { get; set; }  
   
	public MonsterProxy() : base(NAME)  
	{  
		Data = new MonsterBasic();   
	} 

	public void setMonsterBasic(PastMonsters recive){
		Data.monsters = recive.monsters;
		Data.monsterCount = recive.MonsterCount;
	}

	public void atk(){
		PastSingle past = new PastSingle ();
		past.i=-Data.monsterAtkForce;
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.ChangeHp,past);
	}
	

}
