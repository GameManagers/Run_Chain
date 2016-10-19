using UnityEngine;
using System.Collections;

public class MapMove : MonoBehaviour
{


    private int forestCount = 2;

    public Map forest1;
    public Map forest2;

    // Use this for initialization
    Map GenerateMap()
    {
        
        float x = 200 * forestCount;
      //  Random.InitState(System.DateTime.Now.Millisecond);
        int index = Random.Range(101, 103);// 101 102 103
        GameObject go = MapManager.Instance.GetMap(index);
        go.transform.position = new Vector3(x,0,0);
        go.transform.rotation = Quaternion.identity;

        forestCount++;
        return go.GetComponent<Map>();
    }

    public void UpdateMap()
    {
        forest1 = forest2;
        forest2 = GenerateMap();
    }


}
