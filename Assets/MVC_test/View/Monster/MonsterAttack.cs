using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
       
    bool isFight;
    bool isHurt = false;
    Transform other;
    bool isDead;
    Animator anim;
    CapsuleCollider capsuleCollider;

    GameObject player;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find(Tags.obj_name.Player);
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        other = GameObject.FindWithTag(Tags.tag.Player).transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = true;
        }
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

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        //如果受伤
        if (isHurt)
        {
            Death();
        }        //判断与主角的距离，进行攻击
        float dist = (transform.position - other.position).magnitude;
        if (-0.1 < dist - 3.5 && dist - 3.5 < 0.1 && !isFight)//prophet改动
        {
            anim.SetBool(Tags.animator_monster.atk, true);
            isFight = true;
        }
        else
        {
            anim.SetBool(Tags.animator_monster.atk, false);
        }

        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Attack();

            playerInRange = false;
        }
    }
    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger(Tags.animator_monster.Die);

        Destroy(gameObject, 1f);
    }


    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
