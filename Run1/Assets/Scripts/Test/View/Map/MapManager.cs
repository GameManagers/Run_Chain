﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS.Xcode;

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
        MapTextAsset = Resources.Load<TextAsset>("地图配置");
        
    }

    // Use this for initialization
    void Start () {
	    InitMap();
        print(maps.Count);
        foreach (KeyValuePair<int, Map> keyValuePair in maps)
        {
            print(keyValuePair.Key);
            print(keyValuePair.Value.Id+keyValuePair.Value.Name+keyValuePair.Value.MapType);
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
                    case "Normal":
                        map.MapType = MapType.Normal;
                        break;
                    case "Double":
                        map.MapType = MapType.Double;
                        break;
                    case "Chains":
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
            
            go = Instantiate(Resources.Load( "Normal/"+map.Name)) as GameObject;
            return go;
        }
        // double 地图
        if (map.MapType == MapType.Double)
        {
            go = Instantiate(Resources.Load("double/" + map.Name)) as GameObject;
            return go;
        }
        // Chains 地图
        if (map.MapType == MapType.Chains)
        {
            go = Instantiate(Resources.Load("chains/" + map.Name)) as GameObject;
            return go;
        }
        
        return null;
    }


}
