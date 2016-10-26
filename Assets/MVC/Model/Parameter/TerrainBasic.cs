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

	public TextAsset MapTextAsset{get;set;}
	public int TerrainCount{get;set;}
	public Map[] Terrains{get;set;}

	public Dictionary<int,Map> maps ;

	public TerrainBasic(){
		maps = new Dictionary<int, Map>();
	}
}
