using UnityEngine;
using System.Collections;


public class Map : MonoBehaviour {

    private Transform player;
	private GameObject Terrain;
	public int id{ get; set;}// ID
	public MapType mapType{ get; set;} // 地图类型
	public string name{ get; set;}  // 地图名字
    

    void Start () {
         GameObject playerGo = GameObject.FindGameObjectWithTag(Tags.tag.Player);
		 Terrain = GameObject.FindGameObjectWithTag(Tags.tag.Terrain);
        if (playerGo != null)
        {
            player = playerGo.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (player.transform.position.x > this.gameObject.transform.position.x+250)
	    {
            Destroy(this.gameObject);
			PastSingle past=new PastSingle(Terrain);
			RunFacade.getInstance.sendNotificationCommand (NotificationConstant.TerrainCommand.UpdateMap,past);
        }
	}
}
