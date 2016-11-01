using UnityEngine;
using System.Collections;

public class NotificationConstant{



	/**
	 * 
	 * 
	 * Command命令
	 * 
	 */


	public struct playerCommand{
		public const string PlayerMove = "PlayerMove";
		public const string JumpCommond = "JumpCommond";
		public const string CollisionBaseCommond = "CollisionBaseCommond";
		public const string DiedCommond = "DiedCommond";
		public const string CollisionStay = "CollisionStay";


		public const string AtkCommand="AtkCommand";

		public const string MouseLeftDown = "MouseLeftDown";
		public const string MouseLeftUP = "MouseLeftUP";


		public const string AtkMonsterArea = "AtkMonsterArea";
		public const string JuageMonsterDistance = "JuageMonsterDistance";
		public const string AtkMonster = "AtkMonster";

		public const string ChangeHp = "ChangeHp";

		public const string ChainStateToFallState = "ChainStateToFallState";
		public const string ResetJumpData = "ResetJumpData";


	}


	public struct UICommand{
		
	}

	public struct CameraCommand{
		public const string CameraMove = "CameraMove";
		public const string ReStartCameraCommond = "ReStartCameraCommond";

	}

	public struct TerrainCommand{
		public const string SetMapBasic = "SetMapBasic";
		public const string InitMap = "InitMap";
		public const string UpdateMap = "UpdateMap";
	}

	public struct MonsterCommand{
		public const string SetMonsters = "SetMonsters";
		public const string SetMonsterFirstFloat = "SetMonsterFirstFloat";
		public const string MonsterAtk = "MonsterAtk";
	}







	/**
	 * 
	 * 
	 * Mediator命令
	 * 
	 */


	public struct playerMediator{
		public const string PlayerRunMove = "PlayerRunMove";
		public const string JumpMediator = "JumpMediator";
		public const string ResetJumpAnimator = "ResetJumpAnimator";
		public const string ReStart = "ReStart";


		public const string AtkMediator="AtkMediator";
		public const string HitMediator="HitMediator";

		public const string CreatRope="CreatRope";
		public const string ChangePlayerCompnentState="ChangePlayerCompnentState";
		public const string AddPlayerJointCompnent="AddPlayerJointCompnent";
		public const string DeletePlayerCompnent="DeletePlayerCompnent";
		


	}



	public struct UIMediator{
		public const string ChangeButtonColor= "ChangeButtonColor";
		public const string ChangeMonsterCount= "ChangeMonsterCount";
		public const string ChangeHpUI= "ChangeHpUI";
	}



	
	public struct CameraMediator{
		public const string CameraFollowMove = "CameraFollowMove";
		public const string SetCameraPlayerDistance = "SetCameraPlayerDistance";

		public const string GetMouseLeftDown = "GetMouseLeftDown";
		public const string GetMouseLeftUP = "GetMouseLeftUP";

	}


	
	public struct TerrainMediator{

	}


	public struct MonsterMediator{
		public const string ChangeMonsterCompent = "ChangeMonsterCompent";
		public const string ChangeMonsterAnimation = "ChangeMonsterAnimation";
		public const string BossMove = "BossMove";
		public const string MonsterMove = "MonsterMove";
		public const string ChangeBossColor = "ChangeBossColor";
		public const string SpawnSmallBoss = "SpawnSmallBoss";
	}
}
