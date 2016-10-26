using UnityEngine;
using System.Collections;

public class MonsterItem : MonoBehaviour {
	

	bool isFight;
	bool playerInRange;
	GameObject player;

	PastSingle past;

	void Start () {
		past = new PastSingle (this.gameObject);
		player = GameObject.FindGameObjectWithTag(Tags.tag.Player);
	}
	
	// Update is called once per frame
	void Update () {


		RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.MonsterMove, past);
		JuageDistance ();

	}

	void JuageDistance(){

		//判断与主角的距离，进行攻击
		float dist = (transform.position - player.transform.position).magnitude;

		if (0 < dist - 3.5 && dist - 3.5 < 0.1 && !isFight) {//prophet改动
			PastAnimator pastA = new PastAnimator (this.gameObject, Tags.animator_type.Bool, Tags.animator_monster.atk,true);
			RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.ChangeMonsterAnimation, pastA);
			isFight = true;
		}else {
			PastAnimator pastA=new PastAnimator(this.gameObject,Tags.animator_type.Bool,Tags.animator_monster.atk,false);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.MonsterMediator.ChangeMonsterAnimation,pastA);
		}

	}



	void OnCollisionEnter(Collision collision)
	{
		switch (collision.collider.tag) {
		case Tags.tag.Player:{//撞到主角
			PastMonsterCompent past=new PastMonsterCompent(this.gameObject,true,true);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.MonsterMediator.ChangeMonsterCompent,past);

		}break;

		case Tags.tag.Shoot:{//受到攻击
			PastMonsterCompent past=new PastMonsterCompent(this.gameObject,GetComponent<CapsuleCollider>().isTrigger,true);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.MonsterMediator.ChangeMonsterCompent,past);

			PastAnimator pastA=new PastAnimator(this.gameObject,Tags.animator_type.Trigger,Tags.animator_monster.Die);
			RunFacade.getInstance.sendNotificationCommand(NotificationConstant.MonsterMediator.ChangeMonsterAnimation,pastA);

			Destroy(gameObject, 1f);
		}break;
		
		}

	}
}
