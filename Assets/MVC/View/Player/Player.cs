using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    PastSingle past;
    void Start()
    {
        RunFacade.getInstance.InitGameObject(this.gameObject);
        past = new PastSingle(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.PlayerMove);

        RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.JuageMonsterDistance, past);
    }

    void OnCollisionEnter(Collision other)
    {//任务碰撞检测

        if (other.collider.CompareTag(Tags.tag.Base))
        {//碰到地面
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.CollisionBaseCommond);
        }

        if (other.collider.CompareTag(Tags.tag.bottom))
        {//碰到底部 死亡
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.DiedCommond);
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.CameraCommand.ReStartCameraCommond);
        }


        if (other.collider.tag.Equals(Tags.tag.Monster))
        {//碰到怪兽
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.MonsterCommand.MonsterAtk);
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerMediator.HitMediator);
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag(Tags.tag.zhangaiwu))
        {
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.CollisionStay);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag(Tags.tag.Monster))
           && other.transform.position.x > this.transform.position.x)
        {
            PastSingle past = new PastSingle(other.gameObject);
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.AtkMonsterArea, past);
        }
        if (other.gameObject.tag.Equals(Tags.tag.coin))
        {//碰到金币
            //PastCoinCompent pastA = new PastCoinCompent(other.gameObject, true);
            //RunFacade.getInstance.sendNotificationCommand(NotificationConstant.TerrainMediator.ChangeCoinCompent, pastA);
            PastSingle past = new PastSingle(other.gameObject);
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.ChangeCoin, past);
            Destroy (other.gameObject);
        }
    }


    /*攻击*/
    public void AtkButtonDown()
    {
        RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.AtkMonster, past);
        RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerMediator.AtkMediator, past);
    }

	public void DestroyObject(Object obj){
		Destroy (obj);
	}
	
	public void InstantiateGameOjbect(GameObject obj){
		Instantiate (obj);
	}
}
