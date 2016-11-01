using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using UnityEngine.UI;

public class TerrainMediator : Mediator
{
    public new const string NAME = "TerrainMediator";
    //static GameObject coin;
    public TerrainMediator(GameObject root) : base(NAME)
    {
        //coin = GameObject.FindGameObjectWithTag(Tags.tag.coin);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        //添加和显示有关的命令
        //list.Add(NotificationConstant.TerrainMediator.ChangeCoinCompent);

        return list;
    }

    public override void HandleNotification(PureMVC.Interfaces.INotification notification)
    {
        //switch (notification.Name)
        //{
        //    //执行和显示有关的命令
        //    case NotificationConstant.TerrainMediator.ChangeCoinCompent:
        //        {
        //            PastCoinCompent recive = notification.Body as PastCoinCompent;
        //            GameObject CoinItem = recive.coin;
        //            CoinItem.GetComponent<SphereCollider>().isTrigger = recive.isTrigger;
        //        }
        //        break;
        //}
    }
}