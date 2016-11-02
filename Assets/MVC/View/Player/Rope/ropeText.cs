using UnityEngine;
using System.Collections;

public class ropeText : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.CompareTag(Tags.tag.Rope)){
			other.transform.GetChild(0).gameObject.SetActive(true);
			other.GetComponent<BoxCollider> ().isTrigger = false;
		}
			
	}
}
