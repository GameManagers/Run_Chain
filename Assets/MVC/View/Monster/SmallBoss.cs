using UnityEngine;
using System.Collections;

public class SmallBoss : MonoBehaviour {

	PastSingle past;
	void Start () {
		past = new PastSingle (this.gameObject);
		past.vect = new Vector3 (-200,-200,0);

		RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.MonsterMove, past);

        InvokeRepeating("DestorySelf",0,0.1f);
	}
	
	void OnCollisionEnter(Collision collision) {//开始碰撞
		if (collision.collider.name == Tags.monster_type.Boss) {
			Destroy(gameObject);
		}
		if(collision.collider.name == Tags.tag.Player) {
			Destroy(gameObject);
		}
		
	}

    void DestorySelf()
    {
        Vector3 vector3 =  Camera.main.WorldToViewportPoint(this.gameObject.transform.position);
        if (vector3.x < 0 || vector3.y < 0)
        {
            DestroyImmediate(this.gameObject);
        }
    }

	public void Rebound(Vector3 force){
		past.vect = force;
		RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.MonsterMove, past);
	}
}
