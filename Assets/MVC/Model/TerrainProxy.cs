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
		Data.maps= Read.Instance.ReadMap();
        Data.JinbiStrings = Read.Instance.ReadJinbi();
        Data.enemys = Read.Instance.ReadEnemy();
    }

	public void UpdateMap(PastSingle recive){
		float x = 50 * Data.TerrainCount;
		int index = Random.Range(101, 111);

		Map map;
		Data.maps.TryGetValue (index, out map);

		switch (map.mapType) {
			case MapType.Normal:{
				UpdateTerrain= GameObject.Instantiate(Resources.Load(Tags.prb_path.Map_Normal_path + map.name) as GameObject);
              
                    Map temp = UpdateTerrain.GetComponent<Map>();
                    //生成金币
                    for (int i = 0; i < temp.CoinTransforms.Length; i++)
                    {
                        string str = Data.JinbiStrings[Random.Range(0, 7)];

                        str = str.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");

                        GameObject game =GameObject.Instantiate(Resources.Load(Tags.prb_path.Jinbi_path + str) as GameObject);
                      
                        game.transform.SetParent(temp.CoinTransforms[i].transform);
                      
                        game.transform.localPosition = Vector3.zero;
                    }
                    for (int i = 0; i < temp.EnemyTransforms.Length; i++)
                    {
                        int xx = Random.Range(1, 4);
                        MonsterItem monster;
                        Data.enemys.TryGetValue(xx, out monster);

                        GameObject q = GameObject.Instantiate(Resources.Load<GameObject>(Tags.prb_path.Enemy_path + monster.Name));
                        q.transform.parent = temp.EnemyTransforms[i].transform;
                        q.transform.localPosition = Vector3.zero;

                    }

                }
                break;
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

     


    }

}
