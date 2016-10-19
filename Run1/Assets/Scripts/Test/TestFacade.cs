using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns;  

public class TestFacade : Facade {  
	static TestFacade instance;
	public static TestFacade getInstance{
		get{
			if(instance==null) instance=new TestFacade();
			return instance;
		}
	}

	TestFacade() {

	}
	/*public TestFacade(GameObject obj)  
	{  
		//RegisterCommand(NotificationConstant.LevelUp,typeof(TestCommand));  //typeof(TestCommand)
	
		RegisterMediator(new TestMediator(obj));  
		RegisterProxy(new TestProxy());

	}  */

	public void Init(GameObject obj){
		RegisterMediator(new PlayerMediator(obj));  
		RegisterProxy(new PlayerProxy());

		RegisterMediator(new MonsterMediator(obj));  
		RegisterProxy(new MonsterProxy());

		RegisterMediator(new TerrainMediator(obj));  
		RegisterProxy(new TerrainProxy());

	    
	}

	public void addRegisterCommand(string name){
		RegisterCommand(name,typeof(PlayerCommand));
		RegisterCommand(name,typeof(TerrainCommand));
		RegisterCommand(name,typeof(MonsterCommand));
		SendNotification(NotificationConstant.LevelUp);  
	}

}