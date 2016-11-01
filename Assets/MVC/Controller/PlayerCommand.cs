using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class PlayerCommand : SimpleCommand
{

    public new const string NAME = "PlayerCommand";
    PlayerProxy proxy;

    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
        proxy = (PlayerProxy)Facade.RetrieveProxy("PlayerProxy");//通过名字获取Proxy

        PastSingle recive = notification.Body as PastSingle;

        switch (notification.Name)
        {
            case NotificationConstant.playerCommand.PlayerMove:
                {
                    proxy.Move();
                }
                break;

            case NotificationConstant.playerCommand.JumpCommond:
                {
                    proxy.Jump();
                }
                break;

            case NotificationConstant.playerCommand.CollisionBaseCommond:
                {
                    proxy.CollisionBase();
                }
                break;

            case NotificationConstant.playerCommand.DiedCommond:
                {
                    proxy.Died();
                }
                break;

            case NotificationConstant.playerCommand.CollisionStay:
                {
                    proxy.CollisionStay();

                }
                break;

            case NotificationConstant.playerCommand.MouseLeftDown:
                {
                    proxy.MouseDown();

                }
                break;

            case NotificationConstant.playerCommand.MouseLeftUP:
                {
                    proxy.MouseUp();
                }
                break;

            case NotificationConstant.playerCommand.OnChainCommand:
                {
                    proxy.OnChain(recive);
                }
                break;

            case NotificationConstant.playerCommand.AtkMonsterArea:
                {
                    proxy.inAtkArea(recive);
                }
                break;

            case NotificationConstant.playerCommand.JuageMonsterDistance:
                {
                    proxy.JuageMonsterDis(recive);
                }
                break;

            case NotificationConstant.playerCommand.AtkMonster:
                {
                    proxy.atkMonster(recive);
                }
                break;

            case NotificationConstant.playerCommand.ChangeHp:
                {
                    Debug.Log(recive.i);
                    proxy.ChangeHp(recive);
                }
                break;
            case NotificationConstant.playerCommand.ChangeCoin:
                {
                    proxy.ChangeCoin(recive);
                }
                break;


        }
    }
}