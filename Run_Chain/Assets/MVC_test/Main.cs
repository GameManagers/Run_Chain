using UnityEngine;  
using System.Collections;  

public class Main : MonoBehaviour {  
	//public GameObject obj;
//	private TestMediator mediator;
	
	void Start ()   
	{  
		//new TestFacade(gameObject); 
		TestFacade.getInstance.Init(gameObject);

	}  
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			TestFacade.getInstance.addRegisterCommand(NotificationConstant.LevelUp);


		}
	}

}  