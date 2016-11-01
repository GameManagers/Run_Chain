using UnityEngine;
using System.Collections;

public class CreatRope : MonoBehaviour {

	GameObject rope;
	GameObject player;
	GameObject chain;

	Vector3 ConnectPoint;
	bool isConnect=false;
	Tool tool;

	PastPlayerCompenetState past=new PastPlayerCompenetState();
	PastAddJointCompnent pastAdd;
	// Use this for initialization
	void Start () {
		chain = this.transform.parent.gameObject;
		rope = this.transform.parent.parent.gameObject;
		player = GameObject.FindGameObjectWithTag (Tags.tag.Player);
		transform.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up*9000f);

		tool = new Tool ();
	}

	// Update is called once per frame
	void Update () {
		if (isConnect) {
			if (new Tool ().getAngle (ConnectPoint - player.transform.position, Vector3.right) > 90f) {
				past.mass=1f;
				RunFacade.getInstance.SendNotification(NotificationConstant.playerMediator.ChangePlayerCompnentState,past);
				if (player.GetComponent<Rigidbody> ().velocity.x < 1) {
					Destroy (rope);
					RunFacade.getInstance.SendNotification(NotificationConstant.playerCommand.ChainStateToFallState);

				}
			}
		}

		if (!chain.transform.GetChild (0).GetChild (0).GetComponent<BoxCollider> ().isTrigger && !isConnect) {
			past.mass=1f;
			past.isKinematic=false;
			past.isTrigger=false;
			RunFacade.getInstance.SendNotification(NotificationConstant.playerMediator.ChangePlayerCompnentState,past);

			Destroy (rope);

			RunFacade.getInstance.SendNotification (NotificationConstant.playerCommand.ChainStateToFallState);
		}
	}

	void OnCollisionEnter(Collision other) {
		ConnectPoint = other.contacts [0].point;
		if (other.collider.tag.Equals (Tags.tag.top)) {
			  
			CharacterJoint cj=this.gameObject.AddComponent<CharacterJoint>();
			cj.connectedBody=other.collider.GetComponent<Rigidbody>();

			for(int i=chain.transform.childCount-1; i>=0; i--){
				if(chain.transform.GetChild(i).GetChild(0).GetComponent<BoxCollider>().isTrigger){
					chain.transform.GetChild(i).gameObject.SetActive(false);
					if(!isConnect) {

						pastAdd=new PastAddJointCompnent("FixedJoint",chain.transform.GetChild(i+1).GetComponent<Rigidbody>());
						RunFacade.getInstance.SendNotification(NotificationConstant.playerMediator.AddPlayerJointCompnent,pastAdd);

						past.isKinematic=false;
						past.isTrigger=false;
						past.mass=8f;
						RunFacade.getInstance.SendNotification(NotificationConstant.playerMediator.ChangePlayerCompnentState,past);
						RunFacade.getInstance.SendNotification (NotificationConstant.playerCommand.ResetJumpData);

						isConnect=true;
					}
				}
					
				else{
					chain.transform.GetChild(i).GetComponent<Rigidbody>().velocity=Vector3.zero;
					chain.transform.GetChild(i).GetComponent<Rigidbody>().AddForce(Vector3.right*500f);
 					chain.transform.GetChild(i).GetComponent<Rigidbody>().useGravity=true;

				}
			}

		}

	}
}
