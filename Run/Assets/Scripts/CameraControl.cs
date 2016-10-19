using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	public GameObject target;//拍摄目标
	Vector3 player_camera_distance;
	void Start () {
		player_camera_distance = this.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {//在其他所有脚本的Update执行结束后调用，防止震荡
		this.transform.position = player_camera_distance+new Vector3(target.transform.position.x,0,0);
	}
}
