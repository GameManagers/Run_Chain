using UnityEngine;
using System.Collections;

public class CreatChain : MonoBehaviour {

	Vector3 prePoint;
	bool ifPress=false;
	RaycastHit hit = new RaycastHit(); 

	// Update is called once per frame
	void Update   () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hit, 100); 
			if (null != hit.transform && hit.transform.tag.Equals(Tags.tag.Bg)) { 
				prePoint=hit.point;
				ifPress=true;
			} 
		}

		if (Input.GetMouseButtonUp (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hit, 100); 
			if (null != hit.transform && ifPress && hit.transform.tag.Equals(Tags.tag.Bg)) { 
				Vector3 direction=(hit.point-prePoint).normalized;
				float distance=(hit.point-prePoint).magnitude;

				if((direction.x>=0 && direction.y>=0 && direction.z>=0) //确保抛锁链的方向是前上方
				   && Player.getInstance.getChainMinLong()<= distance)
				{
					if(distance>= Player.getInstance.getChainMaxLong()) distance=Player.getInstance.getChainMaxLong();
					GameObject obj=Resources.Load<GameObject>(Tags.prb.Chain);//取预制体
					Chain chain=obj.GetComponent<Chain>();
					Instantiate (obj, new Vector3(hit.point.x,hit.point.y,0),Quaternion.Euler(setAngle(direction)));//创建锁链Quaternion.identity
					chain.setLong(distance);
				}
			} 
			ifPress=false;
		}

	}

	 Vector3 setAngle(Vector3 direction){
		//点积的返回值
		float c = Vector3.Dot (direction.normalized, Vector3.right.normalized);
		//向量a,b的夹角,得到的值为弧度，我们将其转换为角度，便于查看！
		float angle = Mathf.Acos (c) * Mathf.Rad2Deg;
		return new Vector3 (0, 0, -angle); 
	}
	

	
}
