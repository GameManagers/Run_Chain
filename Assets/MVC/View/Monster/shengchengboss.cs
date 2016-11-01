using UnityEngine;
using System.Collections;

public class shengchengboss : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	private Vector3 pos;
	public GameObject kong;
	public GameObject[] boss;
	private int k=0;
	// Use this for initialization
	void Start () {
		//run_speed = Player.getInstance.getRunSpeed();
		offset.x=kong.transform.position.x-player.transform.position.x;
		offset.y = 0f;
		offset.z = 0f;
		spawnNext();
	}

	// Update is called once per frame
	void Update () {
		PlayerMove();

	}
	void PlayerMove(){
		//this.transform.Translate (Vector3.right*run_speed* Time.deltaTime,Space.World);
		//pos=player.transform.position+offset;
		pos=new Vector3(player.transform.position.x+offset.x,kong.transform.position.y,kong.transform.position.z);
		kong.transform.position = pos;

	}
	public void spawnNext() {
		// Random Index
		int i = Random.Range(0, boss.Length);

		// Spawn Group at current Position\
		Instantiate(boss[i],transform.position,Quaternion.identity);
		StartCoroutine (wait (40f));
	} 
	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		spawnNext();
		if (k <= 5) {
			k++;
		} else {
			k = 0;
		}
	}
	public int getk(){
		return k;
	}
}
