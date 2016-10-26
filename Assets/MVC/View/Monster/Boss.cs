using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	
	private int count = 0;
	GameObject player;
	PastSingle past;

	public GameObject[] groups;

	// Use this for initialization
	void Start () {
		StartCoroutine(wait(3f));

		player = GameObject.FindGameObjectWithTag (Tags.tag.Player);

		past = new PastSingle (this.gameObject);
		past.f = this.transform.position.x - player.transform.position.x;
	}
	

	void LateUpdate () {
	
		RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.MonsterMove, past);
	}


	void OnCollisionEnter(Collision other){
		if(other.collider.name.Equals(Tags.monster_type.smallBoss)){
			count++;
			if(count==1){
				past.c=Color.black;
				RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.ChangeBossColor, past);
			} 
			if(count==2){
				past.c=Color.blue;
				RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.ChangeBossColor, past);
			} 
			if(count==3) Destroy(this.gameObject);
		}

	}

	public void spawnNext() {
		int i = Random.Range(0, groups.Length);

		Instantiate(groups[i],transform.GetChild(0).position,Quaternion.identity);
		StartCoroutine(wait(3f));
	} 

	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		spawnNext();
	}

}
