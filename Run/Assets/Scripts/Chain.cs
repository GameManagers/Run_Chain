using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour {

	// Use this for initialization
	GameObject child_cube;
	GameObject child_sphere;
	float preAngle;
	void Start () {
		child_sphere = this.transform.FindChild (Tags.chain.Sphere).gameObject;
		preAngle = child_sphere.transform.localEulerAngles.z;
	}

	void Update () {
		if (child_sphere.transform.localEulerAngles.z < preAngle) {//运行到最高处，销毁
			//Player.getInstance.setPlayerState(PlayerState.Running);  //销毁时改变状态
			//Destroy (this.gameObject);
		}
	    else
			preAngle = child_sphere.transform.localEulerAngles.z;
	}

	public void setLong(float distance){
		child_cube = this.transform.FindChild (Tags.chain.Sphere).FindChild (Tags.chain.Cube).gameObject;
		Vector3 scale = child_cube.transform.localScale;
		scale.y = distance * 10;
		child_cube.transform.localScale = scale;
	
		Vector3 position = child_cube.transform.localPosition;
		position.y = -scale.y/2;
		child_cube.transform.localPosition = position;

		child_sphere = this.transform.GetChild (0).gameObject;
		Vector3 sphere_p = child_sphere.transform.localPosition;
		sphere_p.y = scale.y / 10;
		child_sphere.transform.localPosition = sphere_p;

	}



	

}
