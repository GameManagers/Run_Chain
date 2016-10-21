using UnityEngine;
using System.Collections;

public class SmallBoss : MonoBehaviour {

	void Start () {
		GetComponent<Rigidbody>().AddForce(-200,-125,0);
        InvokeRepeating("DestorySelf",0,0.1f);
	}
	
	void OnCollisionEnter(Collision collision) {//开始碰撞
		if (collision.collider.name == Tags.obj_name.Boss) {
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

	public void Rebound(){
		GetComponent<Rigidbody>().AddForce(2000,520,0);
	}
}
