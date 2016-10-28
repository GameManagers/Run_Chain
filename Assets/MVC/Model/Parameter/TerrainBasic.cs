using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MapType 
{
	Normal, // 普通
	Double, // 双层
	Chains  // 锁链
}

public class TerrainBasic{

	
	public int TerrainCount{get;set;}
	public Map[] Terrains{get;set;}

    private static TerrainBasic _instance;
    private int forestCount = 2;

    public static TerrainBasic Instance
    {
        get
        {
            return _instance;
        }
    }
    public string[] JinbiStrings;
    public Dictionary<int, MonsterItem> enemys;
    public Dictionary<int,Map> maps ;

	public TerrainBasic(){
		maps = new Dictionary<int, Map>();
    //    enemys = new Dictionary<int, MonsterAttack>();
	}
}
