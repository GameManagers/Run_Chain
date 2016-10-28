using UnityEngine;
using System.Collections;

public class Terrains : MonoBehaviour {
	public Map[] terrains;
	int forestCount;
	// Use this for initialization
	void Awake () {
		forestCount = terrains.Length;
		PastTerrains past = new PastTerrains (forestCount, terrains);
		RunFacade.getInstance.InitGameObject(this.gameObject);
		RunFacade.getInstance.sendNotificationCommand (NotificationConstant.TerrainCommand.SetMapBasic,past);

	}

	void Start(){
		RunFacade.getInstance.sendNotificationCommand (NotificationConstant.TerrainCommand.InitMap);
	}

	public void InstanceTerrain(GameObject terrain){
		Instantiate (terrain);
	}
    public void InstanceCoin(GameObject coin,Transform parenTransform)
    {
        Instantiate(coin).transform.SetParent(parenTransform);
    }

}
