using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using PureMVC.Patterns;  
using UnityEngine.UI;  

public class TerrainMediator : Mediator{  
	
	public new const string NAME = "TerrainMediator";  
	
	public TerrainMediator(GameObject root) : base(NAME)  
	{  

	}  
	
	public override IList<string> ListNotificationInterests()  
	{  
		IList<string> list = new List<string>();  
		//添加和显示有关的命令

		
		return list;  
	}  
	
	public override void HandleNotification(PureMVC.Interfaces.INotification notification)  
	{  
		
		switch (notification.Name)  
		{ 
			//执行和显示有关的命令
			
		
			
		}  
		
	}  
	
	
}  