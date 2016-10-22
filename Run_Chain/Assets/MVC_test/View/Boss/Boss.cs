using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public GameObject player;
	public GameObject boss;
	private Vector3 offset;
	private Vector3 pos;
	private int count;

	Renderer rend;

	// Use this for initialization
	void Start () {
		offset.x=this.transform.position.x-player.transform.position.x;
		offset.y = 0f;
		offset.z = 0f;
		count=0;

		rend = this.gameObject.GetComponent<Renderer>();
		rend.material.shader = Shader.Find("Specular");
	}
	
	// Update is called once per frame
	void LateUpdate () {
			PlayerMove();

	}

	void PlayerMove(){
		pos=new Vector3(player.transform.position.x+offset.x,this.transform.position.y,this.transform.position.z);
		this.transform.position = pos;
	}
	void OnCollisionEnter(Collision other){
		if(other.collider.tag.Equals(Tags.tag.smallBoss)){
			rend.material.SetColor("_SpecColor", Color.black);
			count++;
		}
		if(count==2){
			rend.material.SetColor("_SpecColor", Color.green);
		}
		if(count==3){
			rend.material.SetColor("_SpecColor", Color.gray);
		}
		if(count==4){
			rend.material.SetColor("_SpecColor", Color.blue);
		}

		if(count==5)
			Destroy(this.gameObject);

	}

}
