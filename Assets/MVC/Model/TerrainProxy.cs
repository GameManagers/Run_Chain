using UnityEngine;
using System.Collections;
using PureMVC.Patterns;  

public class TerrainProxy : Proxy {
	public new const string NAME = "TerrainProxy"; 
	public TerrainBasic Data { get; set; }  

	public GameObject UpdateTerrain;
	public TerrainProxy() : base(NAME)  
	{  
		Data = new TerrainBasic();   
	} 

	public void SetMapBasic(PastTerrains recive){//ok
		Data.TerrainCount = recive.TerrainCount;
		Data.Terrains = recive.terrains;
		Data.MapTextAsset=Resources.Load<TextAsset>(Tags.resources.TextAsset);
	}

	public void InitMap(){//OK
		string str =Data.MapTextAsset.ToString();
        string[] hangstr = str.Split('|');
        foreach (string hang in hangstr)
        {
			Debug.Log(NAME+" "+hang);
            Map map = new Map();
            string[] liestr = hang.Split(',');
                map.id = int.Parse(liestr[0]);
                switch (liestr[1])
                {
                    case Tags.map_type.Normal:
                        map.mapType = MapType.Normal;
                        break;
			        case Tags.map_type.Double:
                        map.mapType = MapType.Double;
                        break;
			        case Tags.map_type.Chains:
                        map.mapType = MapType.Chains;
                        break;
                }
                map.name = liestr[2];

			Data.maps.Add(map.id,map);
	    }
   }

	public void UpdateMap(PastSingle recive){
		float x = 200 * Data.TerrainCount;
		int index = Random.Range(101, 103);

		Map map;
		Data.maps.TryGetValue (index, out map);

		switch (map.mapType) {
			case MapType.Normal:{
				UpdateTerrain=Resources.Load(Tags.prb_path.Map_Normal_path + map.name) as GameObject;
			}break;
			case MapType.Double:{
				UpdateTerrain=Resources.Load(Tags.prb_path.Map_Double_path + map.name) as GameObject;
			}break;
			case MapType.Chains:{
				UpdateTerrain=Resources.Load(Tags.prb_path.Map_Chains_path + map.name) as GameObject;
			}break;
		}

		Data.TerrainCount += 1;
		Data.Terrains [0] = Data.Terrains [1];
		Data.Terrains[1] = UpdateTerrain.GetComponent<Map>();

		UpdateTerrain.transform.position = new Vector3(x,0,0);//更改的是预制体中的内容
		UpdateTerrain.transform.rotation = Quaternion.identity;

 		recive.obj.GetComponent<Terrains> ().InstanceTerrain (UpdateTerrain);

	}

}
