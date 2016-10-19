using UnityEngine;
using System.Collections;

public class Parameter{

	float run_speed=4f;
	float jump=8f;
	//地形中 top位置和bottom位置中间的距离是y=10.3
	
	//未确定，需根据情况更改
	int blood=100;//血量
	
	float atk_distance=5f;//攻击距离
	float heavy_atk_distance=4f;//重击攻击距离
	float heavy_atk_range=0.1f;//重击范围   heavy_atk_distance +/- heavy_atk_range
	
	float chain_long=5f;//锁链最大长度；


}
