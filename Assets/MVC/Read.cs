using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Read : MonoBehaviour {

 private TextAsset MapTextAsset;
 private TextAsset JinbiTextAsset;
 private TextAsset EnemyTextAsset;
 private TextAsset BossTextAsset;
    private static Read _instance;

    public static Read Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
        MapTextAsset = Resources.Load<TextAsset>(Tags.resources.TextAsset);
        JinbiTextAsset = Resources.Load<TextAsset>(Tags.resources.JinbiAsset);
        EnemyTextAsset = Resources.Load<TextAsset>(Tags.resources.EnemyAsset);
        BossTextAsset = Resources.Load<TextAsset>(Tags.resources.BossAsset);
    }

    public Dictionary<int, Map> ReadMap()
    {
      
        Dictionary<int ,Map> maps = new Dictionary<int, Map>();


        string str = MapTextAsset.ToString();
       
        string[] hangstr = str.Split('\n');
        foreach (string hang in hangstr)
        {
          
            Map map = new Map();
            string[] liestr = hang.Split('\t');

            map.id = int.Parse(liestr[0]);
            switch (liestr[2])
            {
                case Tags.map_type.Normal:
                    map.mapType = MapType.Normal;
                    break;
                case Tags.map_type.Double:
                    map.mapType = MapType.Double;
                    break;
                case Tags.map_type.Chains:
                    map.mapType = MapType.Chains;
                    break;
            }
            map.name = liestr[1];


            maps.Add(map.id, map);
        }
        return maps;
    }

    public string[] ReadJinbi()
    {
        string str = JinbiTextAsset.ToString();
        string[] strings = str.Split('\n');
        return strings;
    }
    public Dictionary<int, MonsterItem> ReadEnemy()
    {
        Dictionary<int, MonsterItem> monsterAttacks = new Dictionary<int, MonsterItem>();


        string str = EnemyTextAsset.ToString();

        string[] hangstr = str.Split('\n');
        foreach (string hang in hangstr)
        {
            MonsterItem monsterAttack = new MonsterItem();
            string[] liestr = hang.Split('\t');

            monsterAttack.Id = int.Parse(liestr[0]);
            monsterAttack.Name = liestr[1];
            monsterAttack.timeBetweenAttacks = float.Parse(liestr[2]);
            monsterAttack.attackDamage = int.Parse(liestr[3]);

            monsterAttacks.Add(monsterAttack.Id, monsterAttack);
        }
        return monsterAttacks;
    }


    /// <summary>
    /// 读取文本中的制定行和列的字符串  从0开始
    /// </summary>
    /// <param name="h"> 行数</param>
    /// <param name="l"> 列数</param>
    /// <returns></returns>
    public string GetString(int h, int l)
    {
        string str = String.Empty;
        string s = BossTextAsset.ToString();

        string[] hang = s.Split('\n');
        string temp = hang[h];
        string[] lie = temp.Split('\t');
        str = lie[l];
        return str;

    }
    /// <summary>
    /// 取得指定行数的字符数组 返回数组保存制定行的字符串
    /// </summary>
    /// <param name="hangshu">行数</param>
    /// <returns></returns>

    public string[] GetHang(int hangshu)
    {
        string s = BossTextAsset.ToString();
        string[] temp = s.Split('\n');
        string[] str = temp[hangshu].Split('\t');
        return str;
    }
}
