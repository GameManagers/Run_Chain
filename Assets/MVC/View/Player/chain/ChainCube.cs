using UnityEngine;
using System.Collections;

public class ChainCube : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if (!other.collider.name.Equals (Tags.tag.Player)) {
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.PlayerMove);
			GameObject obj=this.transform.parent.parent.gameObject;
			Destroy(obj);
		}
	}
}
