using UnityEngine;
using System.Collections;


public class PlayerInfo{
	static PlayerInfo instance;
	public static PlayerInfo getInstance{
		get{
			if(instance==null) instance=new PlayerInfo();
			return instance;
		}
	}

	public int Level { get; set; }  
	public int Hp { get; set; }  
	public int Coin{get;set;}

	public float run_speed{get;set;}
	public float jump_Velocity{get;set;}
	public float atk_distance{get;set;}
	public float chain_length{get;set;}
	public float blood{get;set;}
	public PlayerState curPlayState{get;set;}

	public PlayerInfo(int level)  
	{  
		Level = level;  
	}  
	public PlayerInfo(){


	}




}
