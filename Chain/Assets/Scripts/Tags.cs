using UnityEngine;
using System.Collections;

public class Tags{


	public struct terrain{
		public const float top_position=10.3f;
		public const float bottom_position=0;
	}

	/*标签设置*/
	public struct tag{
		public const string Player = "Player";
		public const string Base = "Base";
		public const string Bg = "Bg";
	};


	/*动画变量*/
	public struct animator{
		public const string isIdle = "isIdle";
		public const string Velocity = "Velocity";
		public const string Velocity2 = "Velocity2";
		public const string Jump = "Jump";
		public const string Jump2 = "Jump2";
		public const string Fall = "Fall";
		public const string Fall2 = "Fall2";
	};


	/*预制体*/
	public struct prb{
		public const string Chain="chain";
	};


	/*锁链的内部物体*/
	public struct chain{
		public const string Sphere="Sphere"; 
		public const string Cube="Cube"; 
		public const float  chain_position_y=terrain.top_position-0.2f;
	}


	
}
