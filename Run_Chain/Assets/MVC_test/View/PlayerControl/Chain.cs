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

		InvokeRepeating("DestorySelf",0,0.1f);
	}

	void Update () {
		if (child_sphere.transform.localEulerAngles.z < preAngle) {//运行到最高处，销毁
			//Player.getInstance.setPlayerState(PlayerState.Running);  //销毁时改变状态
			//Destroy (this.gameObject);
		}
	    else
			preAngle = child_sphere.transform.localEulerAngles.z;
	}

	void DestorySelf()
	{
		Vector3 vector3 =  Camera.main.WorldToViewportPoint(this.gameObject.transform.position);
		if (vector3.x < 0 || vector3.y < 0)
		{
			DestroyImmediate(this.gameObject);
		}
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
