using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using UnityEngine.UI;

public class UIMediator : Mediator
{

    public new const string NAME = "UIMediator";

    static GameObject canvas;
    static Button button;
    static Text monsterCount;
    static Text coinCount;
    static Slider HpSlider;

    public UIMediator(GameObject root) : base(NAME)
    {
        canvas = root;
        button = GameUtility.GetChildComponent<Button>(root, Tags.UI.AtkButton);
        monsterCount = GameUtility.GetChildComponent<Text>(root, Tags.UI.MonsterCount);
        coinCount = GameUtility.GetChildComponent<Text>(root, Tags.UI.CoinCount);
        HpSlider = GameUtility.GetChildComponent<Slider>(root, Tags.UI.HpSlider);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        //添加和显示有关的命令
        list.Add(NotificationConstant.UIMediator.ChangeButtonColor);
        list.Add(NotificationConstant.UIMediator.ChangeMonsterCount);
        list.Add(NotificationConstant.UIMediator.ChangeHpUI);
        list.Add(NotificationConstant.UIMediator.ChangeCoinCount);

        return list;
    }

    public override void HandleNotification(PureMVC.Interfaces.INotification notification)
    {

        switch (notification.Name)
        {
            //执行和显示有关的命令

            case NotificationConstant.UIMediator.ChangeButtonColor:
                {
                    PastBtnColor recive = notification.Body as PastBtnColor;
                    Image img = button.GetComponent<Image>();
                    img.color = recive.color;
                }
                break;

            case NotificationConstant.UIMediator.ChangeMonsterCount:
                {
                    PlayerBasic pb = notification.Body as PlayerBasic;
                    monsterCount.text = "" + pb.Monster;
                }
                break;

            case NotificationConstant.UIMediator.ChangeHpUI:
                {
                    PlayerBasic pb = notification.Body as PlayerBasic;
                    HpSlider.value = pb.Hp;

                }
                break;
            case NotificationConstant.UIMediator.ChangeCoinCount:
                {
                    PlayerBasic pb = notification.Body as PlayerBasic;
                    coinCount.text = "" + pb.Coin;
                }
                break;
        }

    }


}