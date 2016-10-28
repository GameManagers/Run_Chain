using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	PastSingle past;
	void Start () {
		RunFacade.getInstance.InitGameObject(this.gameObject);
		past = new PastSingle (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.PlayerMove);

		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.JuageMonsterDistance,past);
	}
	
	void OnCollisionEnter(Collision other) {//任务碰撞检测

		if (other.collider.CompareTag (Tags.tag.Base)) {//碰到地面
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.CollisionBaseCommond);
		}

		if(other.collider.CompareTag(Tags.tag.surfice)){//碰到底部 死亡
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.DiedCommond);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.CameraCommand.ReStartCameraCommond);
		}

		if (other.collider.tag.Equals (Tags.tag.Chain)) {//碰到锁链
			PastSingle past=new PastSingle(other.collider.gameObject);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.OnChainCommand,past);
		}

		if (other.collider.tag.Equals (Tags.tag.Monster)) {//碰到怪兽
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.MonsterCommand.MonsterAtk);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerMediator.HitMediator);
		}

		
	}

	void OnCollisionStay(Collision other)
	{   
		if (other.collider.CompareTag(Tags.tag.zhangaiwu))
		{
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.CollisionStay);
	    }
    }

	void OnTriggerEnter(Collider other){

 		if ((other.gameObject.CompareTag (Tags.tag.Monster))
		    && other.transform.position.x>this.transform.position.x) {
			PastSingle past=new PastSingle(other.gameObject);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.AtkMonsterArea,past);
	
		}
	}

	public void CreatChain(Vector3 connect_point,float angle){
		 GameObject prb = Resources.Load<GameObject> (Tags.prb_path.Chain);//取预制体 
		 Instantiate (prb, connect_point, Quaternion.Euler (new Vector3 (0, 0, angle)));
     }

	/*攻击*/
	public void AtkButtonDown(){
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.AtkMonster,past);
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerMediator.AtkMediator,past);
	}


	public void DestroyPlayerCharacterJoint(CharacterJoint cj){
		Destroy (cj);
	}

	public void DestroyGameObject(GameObject obj){
		Destroy (obj);
	}

	public void InstantiateGameOjbect(GameObject obj){
		Instantiate (obj);
	}


}
