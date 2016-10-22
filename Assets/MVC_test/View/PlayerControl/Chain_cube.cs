using UnityEngine;
using System.Collections;

public class Chain_cube : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if (!other.collider.name.Equals (Tags.obj_name.Player)) {
			Player.getInstance.setPlayerState(PlayerState.Running);
			GameObject obj=this.transform.parent.parent.gameObject;
			Destroy(obj);
		}
	}
}
