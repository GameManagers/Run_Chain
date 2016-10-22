using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	public GameObject target;//拍摄目标
	Vector3 player_camera_distance;



	float t;    
	
	Vector3 Move;
	Vector3 Move0;

	void Start () {
		player_camera_distance = this.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {//在其他所有脚本的Update执行结束后调用，防止震荡


		t += Time.deltaTime;
		if (t == Time.deltaTime)
			Move0 = transform.position;
		if (t > 0.5)
		{
			Move = transform.position;
			if ((Move - Move0).magnitude > -0.5 && (Move - Move0).magnitude < 0.5)
			{
				UI.getInstance.setInstanceNull();
				Player.getInstance.setInstanceNull();
				Application.LoadLevel(Application.loadedLevel);
			}
			t = 0;
		}

		this.transform.position = player_camera_distance+new Vector3(target.transform.position.x,0,0);
	}
}
