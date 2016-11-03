using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    PastSingle past;
    // Use this for initialization
    void Start()
    {
        RunFacade.getInstance.InitGameObject(this.gameObject);
        past = new PastSingle(this.gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Tags.tag.Male))
        {
            PastSingle past = new PastSingle(other.gameObject);
            RunFacade.getInstance.sendNotificationCommand(NotificationConstant.playerCommand.ChangeCoin, past);
            Destroy(this.gameObject);
        }
    }
}
