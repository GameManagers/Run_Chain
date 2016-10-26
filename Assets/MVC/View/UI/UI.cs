using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RunFacade.getInstance.InitGameObject(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
