using UnityEngine;  
using System.Collections;  
using PureMVC.Patterns; 

public class UICommand : SimpleCommand{  
	
	public new const string NAME = "UICommand";  
	
	public override void Execute(PureMVC.Interfaces.INotification notification)  
	{  
		UIProxy proxy = (UIProxy)Facade.RetrieveProxy("UIProxy");//通过名字获取Proxy
		
		switch (notification.Name) {
		
			
		}  
	}
}  