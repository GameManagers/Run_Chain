using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] groups;


	// Use this for initialization
	void Start () {
		//spawnNext();

		StartCoroutine(wait(3f));

	}
	// Update is called once per frame
	void Update () {

	}

	public void spawnNext() {
		// Random Index
		int i = Random.Range(0, groups.Length);

		// Spawn Group at current Position
		Instantiate(groups[i],transform.position,Quaternion.identity);
		StartCoroutine(wait(3f));
	} 
	IEnumerator wait(float time){
		yield return new WaitForSeconds(time);
		spawnNext();
	}
}
