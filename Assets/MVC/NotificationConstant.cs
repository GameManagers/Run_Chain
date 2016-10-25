using UnityEngine;
using System.Collections;

public class NotificationConstant{

	public struct playerCommand{
		public const string PlayerMove = "PlayerMove";
	}

	public struct playerMediator{
		public const string PlayerRunMove = "PlayerRunMove";
	}


	public struct CameraCommand{
		public const string CameraMove = "CameraMove";
		//public const string SetCameraPlayerDistance = "SetCameraPlayerDistance";
	}
	
	public struct CameraMediator{
		public const string CameraFollowMove = "CameraFollowMove";
		public const string SetCameraPlayerDistance = "SetCameraPlayerDistance";
	}
}
