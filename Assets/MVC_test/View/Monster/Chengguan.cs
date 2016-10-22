using UnityEngine;
using System.Collections;
using System;

public class Chengguan : MonoBehaviour {
    Vector3 tf;
    bool isFight;
    double x;
    bool isHurt = false;
    Transform other;
    bool isDead;
    Animator anim;
    CapsuleCollider capsuleCollider;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        other = GameObject.FindWithTag(Tags.tag.Player).transform;
    }

    // Update is called once per frame
    void Update () {
        if (isDead)
            return;
        //如果受伤
        if (isHurt)
        {
            Death();
        }
        x += Time.deltaTime;
        tf= GetComponent<Transform>().position;
        tf.y = 1.5f+ (float) Math.Sin(x)*0.5f;
        GetComponent<Transform>().position=tf;
     
        //判断与主角的距离，进行攻击
        float dist = (transform.position - other.position).magnitude;
        if (-0.1 < dist - 2.5 && dist - 2.5 < 0.1&&!isFight)
        {
            anim.SetBool(Tags.animator_monster.atk, true);
            isFight = true;
        }
        else
        {
			anim.SetBool(Tags.animator_monster.atk, false);
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

		anim.SetTrigger(Tags.animator_monster.Die);

        Destroy(gameObject, 1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Tags.tag.Shoot)
        {
            isHurt = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }
		if (collision.gameObject.tag == Tags.tag.Player)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            capsuleCollider.isTrigger = true;
        }
    }
}
