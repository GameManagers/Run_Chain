using UnityEngine;
using System.Collections;

public class MonsterBasic{


	public int monsterCount{get;set;}
	public GameObject[] monsters{get;set;}
	public int monsterAtkForce{get;set;}


	public MonsterBasic(){

		monsterCount = 0;
		monsterAtkForce = 10;

	}
}
