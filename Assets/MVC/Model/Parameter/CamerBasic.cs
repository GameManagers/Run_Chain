using UnityEngine;
using System.Collections;

public class CamerBasic{

	static CamerBasic instance;
	public static CamerBasic getInstance{//单例模式      在其他类中调用方法： Player.getInstance.函数();
		get{
			if(instance==null) instance=new CamerBasic();
			return instance;
		}
	}

	public Vector3 player_camera_distance{get;set;}//摄像机和主角的初始相对位置
}
