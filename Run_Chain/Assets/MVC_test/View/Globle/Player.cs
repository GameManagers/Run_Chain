using UnityEngine;
using System.Collections;

public enum PlayerState{//人物状态
	Idling,
	Running,
	Jumping,
	Atking,
	OnChain,
	Died
}

public class Player{
	
	//单例模式      在其他类中调用方法： Player.getInstance.函数();
	static Player instance;
	public static Player getInstance{
		get{
			if(instance==null) instance=new Player();
			return instance;
		}
	}
	
	static PlayerState curPlayerState=PlayerState.Running;
	
	//已经确定
	float run_speed=6f;
	float jump=8f;
	//地形中 top位置和bottom位置中间的距离是y=10.3
	
	//未确定，需根据情况更改
	int blood=100;//血量
	
	float atk_distance=5f;//攻击距离
	float heavy_atk_distance=4f;//重击攻击距离
	float heavy_atk_range=0.1f;//重击范围   heavy_atk_distance +/- heavy_atk_range
	
	float chain_max_long=5f;//锁链最大长度；
	float chain_min_long=1f;//锁链最小长度；

	public int Monster{get;set;}
	
	public void setInstanceNull(){
		instance=null;
	}

	public void setPlayerState(PlayerState ps){
		curPlayerState = ps;
	}
	
	public PlayerState getPlayerState(){
		return curPlayerState;
	}
	
	
	public float getRunSpeed(){
		return run_speed;
	}
	
	public void setRunSpeed(float s){
		run_speed = s;
	}
	
	public float getJump(){
		return jump;
	}
	
	public void changeBlood(int changeValue){//改变人物的血量
		blood += changeValue;
	}
	
	public int getBlood(){
		return blood;
	}
	
	
	public float getAtkDistance(){
		return atk_distance;
	}
	
	public void setAtkDistance(float ad){
		atk_distance = ad;
	}
	
	public float getHeavyAtkDistance(){
		return heavy_atk_distance;
	}
	
	public void setHeavyAtkDistance(float had){
		heavy_atk_distance = had;
	}
	
	public float getHeavyAtkRange(){
		return heavy_atk_range;
	}
	
	public void setHeavyAtkRange(float har){
		heavy_atk_range = har;
	}
	
	public float getChainMaxLong(){
		return chain_max_long;
	}
	
	public float getChainMinLong(){
		return chain_min_long;
	}
	
	public void setChainLong(float cl){
		chain_max_long=cl;
	}
	
	
	
	
	
	
}
