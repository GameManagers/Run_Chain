using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	private int count = 0;
	private int num = 0;
	GameObject player;
	PastSingle past;
	public GameObject[] groups;
	private int k;
	// Use this for initialization
	void Start () {
		k=GameObject.Find ("shengchengdian").GetComponent<shengchengboss> ().getk ();
		//string d =Read.Instance.GetString (0, 2);
		string[] str = Read.Instance.GetHang (k);
		string str1 = str [1];
		string str2 = str [2];
		string str3 = str [3];
		int m = int.Parse (str1);
		int n = int.Parse (str2);
		float t = float.Parse (str3);


		//for (int i = 0; i < str.Length; i++) {
		//Debug.LogError (str [i]);
		//}

		//int s = int.Parse (d);
		StartCoroutine(wait(t));

		player = GameObject.FindGameObjectWithTag (Tags.tag.Player);

		past = new PastSingle (this.gameObject);
		past.f = this.transform.position.x - player.transform.position.x;
	}


	void LateUpdate () {

		RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.MonsterMove, past);
	}


	void OnCollisionEnter(Collision other){
		k=GameObject.Find ("shengchengdian").GetComponent<shengchengboss> ().getk ();
		string [] str = Read.Instance.GetHang(k);
		string str1 = str [1];
		string str2 = str [2];
		string str3 = str [3];
		int m = int.Parse (str1);
		int n = int.Parse (str2);
		float t = float.Parse (str3);
		if(other.collider.name.Equals(Tags.monster_type.smallBoss)){
			count++;
			//if(count==1){
			//	past.c=Color.black;
			//	RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.ChangeBossColor, past);
			//} 
			//if(count==2){
			//	past.c=Color.blue;
			//	RunFacade.getInstance.sendNotificationCommand (NotificationConstant.MonsterMediator.ChangeBossColor, past);
			//} 
			if (count == n) {
				Destroy (this.gameObject);
			}
		}
	}

	public void spawnNext() {
		k=GameObject.Find ("shengchengdian").GetComponent<shengchengboss> ().getk ();
		string [] str = Read.Instance.GetHang(k);
		string str1 = str [1];
		string str2 = str [2];
		string str3 = str [3];
		int m = int.Parse (str1);
		int n = int.Parse (str2);
		float t = float.Parse (str3);
		int i = Random.Range(0, groups.Length);

		Instantiate(groups[i],transform.GetChild(0).position,Quaternion.identity);
		StartCoroutine(wait(t));
		num++;
		if (num > m) {
			Destroy (this.gameObject);
		}
	} 

	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		spawnNext();

	} 
}