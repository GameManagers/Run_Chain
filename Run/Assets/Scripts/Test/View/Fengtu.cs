using UnityEngine;
using System.Collections;

public class Fengtu : MonoBehaviour {
    float t;
    bool isHurt = false;
    bool isDead;
    bool isFight;
    Transform other;
    Animator anim;
    CapsuleCollider capsuleCollider;
    // Use this for initialization
    void Awake ()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        other = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isDead)
            return;        
        //如果受伤
        if (isHurt)
        {
            Death();
        }

        //判断与主角的距离，进行攻击
        float dist = (transform.position - other.position).magnitude;
        if (-0.1 < dist -1.5  && dist - 1.5 < 0.1&&!isFight)
        {
            anim.SetBool("atk",true); isFight = true;
        }
        else
        {
            anim.SetBool("atk", false);
        }
    }

    //死亡
    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Die");

        Destroy(gameObject, 1f);

    }

    //被主角攻击
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shoot")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            isHurt = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            capsuleCollider.isTrigger = true;
        }
    }
}
