using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	// Use this for initialization
	public GameObject[] monsters;
	void Awake(){
		RunFacade.getInstance.InitGameObject(this.gameObject);
	}

	void Start () {
		PastMonsters past = new PastMonsters (monsters.Length,monsters);
		RunFacade.getInstance.sendNotificationCommand(NotificationConstant.MonsterCommand.SetMonsters,past);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
