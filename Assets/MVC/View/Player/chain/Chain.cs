using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour {
	

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
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.PlayerMove);
			Destroy (this.gameObject);
		}
	}

}
