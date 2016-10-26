using UnityEngine;
using System.Collections;

public class CreatChainPast{
	public float distance;
	public Vector3 connect_point;
	public float angle;
}

public class PastSingle{
	public GameObject obj;
	public Vector3 vect;
	public float f;
	public int i;
	public bool b;
	public string s;
	public Color c;

	public PastSingle(GameObject o){
		obj = o;
	}
	public PastSingle(){
	}
}

public class PastBtnColor{
	public Color color;
	public PastBtnColor(Color c){
		color=c;
	}
}

public class PastTerrains{
	public int TerrainCount;
	public Map[] terrains;
	public PastTerrains(int c,Map[] m){
		TerrainCount=c;
		terrains = m;
	}
}

public class PastMonsters{
	public int MonsterCount;
	public GameObject[] monsters;
	public PastMonsters(int c,GameObject[] m){
		MonsterCount=c;
		monsters = m;
	}
}

public class PastMonsterCompent{
	public GameObject monster;
	public bool isTrigger;
	public bool isKinematic;
	public PastMonsterCompent(GameObject m,bool t,bool k){
		monster = m;
		isTrigger=t;
		isKinematic =k;
	}
}

public class PastAnimator{
	public GameObject monster;
	public string type;
	public string name;
	public bool boolState;
	public PastAnimator(GameObject m,string t,string n){
		monster = m;
		type = t;
		name = n;
	}
	public PastAnimator(GameObject m,string t,string n,bool s){
		monster = m;
		type = t;
		name = n;
		boolState = s;
	}
}


