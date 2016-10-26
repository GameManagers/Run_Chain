using UnityEngine;
using System.Collections;

public class CamerBasic{

	public Vector3 player_camera_distance{get;set;}//摄像机和主角的初始相对位置
	public bool isReStart{get;set;}//摄像机和主角的初始相对位置

	public CamerBasic(){
		player_camera_distance = Vector3.zero;
		isReStart = false;
	}
}
