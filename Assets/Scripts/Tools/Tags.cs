﻿using UnityEngine;
using System.Collections;

public class Tags
{

    public struct terrain
    {
        public const float top_position = 10.3f;
        public const float bottom_position = 0;
    }

    /*标签设置*/
    public struct tag
    {
        public const string MainCamera = "MainCamera";
        //地形
        public const string Base = "Base";
        public const string Bg = "Bg";
        public const string top = "Top";
        public const string bottom = "Bottom";
        public const string tool = "Tool";
        public const string coin = "Coin";
        public const string environment = "Environment";
        public const string zhangaiwu = "zhangaiwu";

        //人物
        public const string Player = "Player";
		public const string Rope = "Rope";
        public const string Male = "Male";

        //怪兽
        public const string Monster = "Monster";
        public const string Shoot = "Shoot";

        public const string UI = "UI";
        public const string Terrain = "Terrain";
    };

	public struct PlayerChilds{
		public const int PlayerSkin = 0;
		public const int Cover1 = 1;
		public const int Cover2 = 2;
		public const int Send_target = 3;
	};

    public struct layer
    {
        public const string Player = "Player";
        public const string bg = "bg";
	};

    /*Animator参数类型*/
    public struct animator_type
    {
        public const string Trigger = "Trigger";
        public const string Bool = "Bool";
    };

    /*预制体*/
    public struct prb_path
    {
		public const string Rope="pfb/Rope";
        public const string Map_Normal_path = "pfb/Normal/";
        public const string Map_Double_path = "pfb/double/";
        public const string Map_Chains_path = "pfb/chains/";
        public const string Jinbi_path = "pfb/jinbi/";
        public const string Enemy_path = "pfb/";


    };



    /*人物动画变量*/
    public struct animator_player
    {
        public const string isIdle = "isIdle";
        public const string Velocity = "Velocity";
        public const string Velocity2 = "Velocity2";
        public const string Jump = "Jump";
        public const string Jump2 = "Jump2";
        public const string Fall = "Fall";
        public const string Fall2 = "Fall2";
        public const string isAtk = "isAtk";
        public const string isHit = "isHit";
    };

    /*怪兽动画变量*/
    public struct animator_monster
    {
        public const string atk = "atk";
        public const string Die = "Die";
    };

    /*怪兽种类*/
    public struct monster_type
    {
        public const string fly = "fly";
        public const string rabbit = "rabbit";
        public const string water = "water";
		public const string Boss = "Boss(Clone)";
        public const string smallBoss = "smallBoss(Clone)";
    };




    public struct resources
    {
        public const string TextAsset = "地图配置";
        public const string JinbiAsset = "金币配置";
        public const string EnemyAsset = "敌人配置";
        public const string BossAsset = "BOSS难度";
    }



    public struct map_type
    {
        public const string Normal = "Normal";
        public const string Double = "Double";
        public const string Chains = "Chains";
    }


    /*发送消息*/
    public struct send_message
    {
        public const string UpdateMap = "UpdateMap";
    };



    /*锁链的内部物体*/
    public struct chain
    {
        public const string Sphere = "Sphere";
        public const string Cube = "Cube";
        public const float chain_position_y = terrain.top_position - 0.2f;
        public const string PlayerPoint = "PlayerPoint";
    }

    /*UI路径*/
    public struct UI
    {
        public const string AtkButton = "Atk_Button";
        public const string MonsterCount = "Monster_Count";
        public const string HpSlider = "Slider";
        public const string CoinCount = "Coin_Count";

    }



}
