using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour {

	// Use this for initialization
	GameObject child_cube;
	GameObject child_sphere;
	float angle;
	void Start () {
		child_sphere = this.transform.GetChild(0).gameObject;
		child_cube = this.transform.GetChild(0).GetChild(0).gameObject;
		angle = 360f - this.transform.eulerAngles.z;
	}

	void Update () {
		if (child_sphere.transform.localEulerAngles.z>angle && child_sphere.transform.localEulerAngles.z<=2*angle 
		    && child_cube.GetComponent<Rigidbody> ().velocity.x<0) {
			Player.getInstance.setPlayerState (PlayerState.Running);
			Destroy (this.gameObject);
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
