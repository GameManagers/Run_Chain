using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

//	Vector3 position;
	// Use this for initialization
	LineRenderer lineRenderer;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		StartCoroutine (destroyLine());//启动协程
	}

	public void setPosition(Vector3 start,Vector3 end){
		//position = v;
		lineRenderer = this.GetComponent<LineRenderer>();
		lineRenderer.SetPosition (0,start);
		lineRenderer.SetPosition (1,end);

	}

	IEnumerator destroyLine(){
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}
}
