using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using PureMVC.Patterns;  
using UnityEngine.UI;  

public class TerrainMediator : Mediator,ITestMediator {  
	
	public new const string NAME = "TerrainMediator";  
	
	private Text levelText;  
	private Button levelUpButton;  
	
	
	public TerrainMediator(GameObject root) : base(NAME)  
	{  
		levelText = GameUtility.GetChildComponent<Text>(root, "Text/LevelText");  
		levelUpButton = GameUtility.GetChildComponent<Button>(root, "LevelUpButton");  
		
		
		levelUpButton.onClick.AddListener(OnClickLevelUpButton); 
		
	}  
	
	private void OnClickLevelUpButton()  
	{  
		SendNotification(NotificationConstant.LevelUp);  
	}  
	
	public void test(){
		Debug.Log("test");
	}
	
	
	public override IList<string> ListNotificationInterests()  
	{  
		IList<string> list = new List<string>();  
		list.Add(NotificationConstant.LevelChange);
		
		
		return list;  
	}  
	
	public override void HandleNotification(PureMVC.Interfaces.INotification notification)  
	{  
		switch (notification.Name)  
		{  
		case NotificationConstant.LevelChange :  
			PlayerInfo ci_1= notification.Body as PlayerInfo;  
			levelText.text = ci_1.Level.ToString();  
			break;
			
			
		default :  
			break;  
		}  
		
	}  
}  