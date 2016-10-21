using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {
    private Transform player;
    // ID
    private int id;
    // 地图类型
    private MapType mapType;
    // 地图名字
    private string name;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public MapType MapType
    {
        get
        {
            return mapType;
        }

        set
        {
            mapType = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }


    void Start()
    {
        GameObject playerGo = GameObject.FindGameObjectWithTag(Tags.tag.Player);
        if (playerGo != null)
        {
            player = playerGo.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > this.gameObject.transform.position.x + 250)
        {
            Destroy(this.gameObject);
            //  Camera.main.SendMessage("UpdateMap", SendMessageOptions.DontRequireReceiver);
            Camera.main.SendMessage(Tags.send_message.UpdateMap);
        }
    }
}
