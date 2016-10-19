using UnityEngine;
using System.Collections;

public class Shuidi : MonoBehaviour {
    float t;
    bool isHurt=false;
    bool isDead;
    bool isFight;
    Transform other;
    Animator anim;
    CapsuleCollider capsuleCollider;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        other = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        //如果受伤
        
        t += Time.deltaTime;
        if (t >= 3)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            t = 0;
        }
        //判断与主角的距离，进行攻击
        if (isHurt)
        {
            Death();
        }
        float dist = (transform.position - other.position).magnitude;
        if (-0.1 < dist - 1.3 && dist - 1.3 < 0.1&&!isFight)
        {
            anim.SetBool("atk", true); isFight = true;
        }
        else
        {
            anim.SetBool("atk", false);
        }
    }
    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Die");

        Destroy(gameObject, 1f);
    }

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
