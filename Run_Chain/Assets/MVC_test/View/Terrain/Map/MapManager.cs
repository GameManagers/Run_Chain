using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.iOS.Xcode;

public enum MapType 
    {
         Normal, // 普通
         Double, // 双层
         Chains  // 锁链
    }
public class MapManager : MonoBehaviour
{
    //zidian用来存储map
    //private  List<Map> maps = new List<Map>();
    public Dictionary<int,Map> maps = new Dictionary<int, Map>();
    private TextAsset MapTextAsset;


    private static MapManager _instance;

    public static MapManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        MapTextAsset = Resources.Load<TextAsset>(Tags.resources.TextAsset);
        
    }

    // Use this for initialization
    void Start () {
	    InitMap();
		print("maps.Count:   "+maps.Count);
        foreach (KeyValuePair<int, Map> keyValuePair in maps)
        {
			print("ID: "+keyValuePair.Value.Id+" Name: "+keyValuePair.Value.Name+" MapType: "+keyValuePair.Value.MapType);
        }
	}
	

    void InitMap()
    {
        string str = MapTextAsset.ToString();
        string[] hangstr = str.Split('|');
        foreach (string hang in hangstr)
        {
            print(hang);
            Map map = new Map();
            string[] liestr = hang.Split(',');
          
                map.Id = int.Parse(liestr[0]);
                switch (liestr[1])
                {
                    case Tags.map_type.Normal:
                        map.MapType = MapType.Normal;
                        break;
			        case Tags.map_type.Double:
                        map.MapType = MapType.Double;
                        break;
			        case Tags.map_type.Chains:
                        map.MapType = MapType.Chains;
                        break;
                }
                map.Name = liestr[2];

            
            maps.Add(map.Id,map);
        }
        
    }

    public Map GetMapFromDic(int id)
    {
        Map map ;
        maps.TryGetValue(id, out map);
        return map;
    }

   public  GameObject GetMap(int id)
   {
       

        GameObject go = null;
       Map map = GetMapFromDic(id);
       
        if (map.MapType == MapType.Normal)
        {
            
            go = Instantiate(Resources.Load( Tags.prb_path.Map_Normal_path+map.Name)) as GameObject;
            return go;
        }
        // double 地图
        if (map.MapType == MapType.Double)
        {
			go = Instantiate(Resources.Load(Tags.prb_path.Map_Double_path + map.Name)) as GameObject;
            return go;
        }
        // Chains 地图
        if (map.MapType == MapType.Chains)
        {
			go = Instantiate(Resources.Load(Tags.prb_path.Map_Chains_path + map.Name)) as GameObject;
            return go;
        }
        
        return null;
    }


}
