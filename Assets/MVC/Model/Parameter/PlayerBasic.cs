using UnityEngine;
using System.Collections;

public enum PlayerState{//人物状态
	Running,
	Jumping,
	Atking,
	OnChain,
	Fall,
	Died
}

public class PlayerBasic{

	public int Level{ get; set;} //等级
	public int Hp { get; set; }//血量 
	public int Cover{get;set;}//防守力
	public int Coin{get;set;}//获得金币数量
	public int Monster{get;set;}//消灭怪兽数量
	public int CurJump{get;set;}// 当前几段跳： 1 一段跳   2 二段跳
	public int TriggerTimes{get;set;}// 1 进入重击范围   2 进入普击范围

	public PlayerState curPlayState{get;set;}//人物当前所处状态

	public float run_speed{get;set;}//奔跑速度
	public float jump_Velocity{get;set;}//跳跃加速度
	public float atk_distance{get;set;}//攻击距离
	public float heavy_atk_distance{get;set;}//重击攻击距离
	public float chain_max_long{get;set;}//锁链最大长度；
	public float chain_min_long{get;set;}//锁链最小长度；
	public float timer{get;set;}//被卡住的时间

	public GameObject curMonster{get;set;}//当前进入攻击范围的怪兽
    public GameObject Coins { get; set; }//当主角收获金币
    public Vector3 smallBossRe{get;set;}//使小怪返回的力
	//past
	public float angle{get;set;}//要创建的锁链的角度
	public Vector3 mouse_down{get;set;}//按下时的位置


	 public PlayerBasic(){
		Level = 0;
		Hp = 100;
		Cover = 2;
		Coin = 0;
		Monster = 0;
		CurJump = 0;
		TriggerTimes = 0;

		curPlayState = PlayerState.Running;
		
		run_speed = 6f;
		jump_Velocity = 8;
		atk_distance=3f;
		heavy_atk_distance=4f;
		chain_max_long = 5f;
		chain_min_long = 1f;
		timer = 0;

		curMonster = null;
        Coins = null;

        mouse_down = Vector3.zero;
		smallBossRe=new Vector3 (2000,520,0);

	}

}
