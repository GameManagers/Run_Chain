using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI{
	static UI instance;
	public static UI getInstance{
		get{
			if(instance==null) instance=new UI();
			return instance;
		}
	}

	static GameObject canvas;
	static Button atk_bn;

	UI(){
		canvas = GameObject.Find(Tags.obj_name.Canvas);
		atk_bn = canvas.transform.GetChild (0).GetComponent<Button>();
	}
	
	public void changeAtkBtnColor(Color color){

		Image img=canvas.transform.GetChild (0).GetComponent<Image>();
		img.color = color;
	}
}
