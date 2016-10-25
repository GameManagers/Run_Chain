using UnityEngine;
using System.Collections;

public enum PlayerState{//人物状态
	Running,
	Jumping,
	Atking,
	OnChain,
	Died
}

public class PlayerBasic{
	static PlayerBasic instance;
	public static PlayerBasic getInstance{//单例模式      在其他类中调用方法： Player.getInstance.函数();
		get{
			if(instance==null) instance=new PlayerBasic();
			return instance;
		}
	}
	
	public int Level{ get; set;} //等级
	public int Hp { get; set; }//血量 
	public int Coin{get;set;}//获得金币数量
	public int Monster{get;set;}//消灭怪兽数量

	public PlayerState curPlayState{get;set;}//人物当前所处状态

	public float run_speed{get;set;}//奔跑速度
	public float jump_Velocity{get;set;}//跳跃加速度
	public float atk_distance{get;set;}//攻击距离
	public float heavy_atk_distance{get;set;}//重击攻击距离
	public float chain_max_long{get;set;}//锁链最大长度；
	public float chain_min_long{get;set;}//锁链最小长度；
	

	 public PlayerBasic(){
		Level = 0;
		Hp = 100;
		Coin = 0;
		Monster = 0;

		curPlayState = PlayerState.Running;
		
		run_speed = 6f;
		jump_Velocity = 8;
		atk_distance=3f;
		heavy_atk_distance=4f;
		chain_max_long = 5f;
		chain_min_long = 1f;
	}

}
