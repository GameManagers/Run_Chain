using UnityEngine;
using System.Collections;

public class Tool{

	public Vector3 RayPointBg(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit(); 
		
		//获取bg层级，避免与其他层的碰撞器产生冲突
		//层级在Inspector的Layer中设定
		//1<<10 打开第10层
		Physics.Raycast (ray, out hit, 100, (1 << LayerMask.NameToLayer(Tags.layer.bg)));
		if (null != hit.transform && hit.transform.tag.Equals (Tags.tag.Bg)) 
			return hit.point;
		else
			return Vector3.zero;
	}

	//获取鼠标点击和抬起与人物水平移动方向的角度
	public float getAngle(Vector3 direction,Vector3 anxis){
		//向量a,b的夹角,得到的值为弧度，我们将其转换为角度，便于查看！
		float angle = Mathf.Acos (Vector3.Dot (direction.normalized, anxis)) * Mathf.Rad2Deg;
		return angle;
	}
}
