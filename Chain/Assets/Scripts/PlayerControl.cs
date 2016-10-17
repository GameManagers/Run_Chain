using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	 float run_speed;
	 float jump;
	 //bool isChain=false;

	//private
	Animator player_ac;
	Rigidbody player_rigidboy;
	
	void Start () {
		run_speed = Player.getInstance.getRunSpeed();
		jump = Player.getInstance.getJump ();
		player_ac=this.GetComponent<Animator>();//获取动画控制器
		player_rigidboy=this.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update  () {

		pressKey ();//按键相关


		switch(Player.getInstance.getPlayerState()){
		case PlayerState.Running:PlayerMove();
			break;
		case PlayerState.OnChain:{
			//if(isChain==false) CreatChain();
		}
			break;
		case PlayerState.Jumping:{
									PlayerMove();
									PlayerJump();
								}break;
		}
		
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.collider.tag.Equals (Tags.tag.Base)) {//碰到地面
			player_ac.SetBool (Tags.animator.Jump2, false);
			player_ac.SetBool (Tags.animator.Jump, false);
			Player.getInstance.setPlayerState(PlayerState.Running);
		}

	}

	void PlayerMove(){
		this.transform.Translate (Vector3.right*run_speed* Time.deltaTime,Space.World);
	}

	void PlayerJump(){
		if (player_ac.GetBool (Tags.animator.Jump))
			player_ac.SetFloat (Tags.animator.Velocity, player_rigidboy.velocity.y);
		if (player_ac.GetBool (Tags.animator.Jump2))
			player_ac.SetFloat (Tags.animator.Velocity2, player_rigidboy.velocity.y);	

	}
	



	void CreatChain(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit(); 
		Physics.Raycast(ray, out hit, 100); 
		if (null != hit.transform && hit.transform.tag.Equals(Tags.tag.Bg)) { 
			Vector3 point=hit.point;
			point.z=0;   point.y=Tags.chain.chain_position_y;
			Vector3 direction=(point-this.transform.position).normalized;
			float distance=(point-this.transform.position).magnitude;
		//	Debug.Log(distance);
			if((direction.x>=0 && direction.y>=0 && direction.z>=0) //确保抛锁链的方向是前上方
			   && Player.getInstance.getChainMinLong()<= distance
			   && distance<= Player.getInstance.getChainMaxLong())
			{
				//if(distance>= Player.getInstance.getChainMaxLong()) distance=Player.getInstance.getChainMaxLong();
				Player.getInstance.setPlayerState(PlayerState.OnChain);//成功创建时进入锁链状态
				GameObject obj=Resources.Load<GameObject>(Tags.prb.Chain);//取预制体
				Chain chain=obj.GetComponent<Chain>();
				Instantiate (obj, point,Quaternion.Euler(setAngle(direction)));//创建锁链Quaternion.identity
				chain.setLong(distance);
			}
		} 
		//Player.getInstance.setPlayerState(PlayerState.Running);
	}

	Vector3 setAngle(Vector3 direction){
		//点积的返回值
		float c = Vector3.Dot (direction, Vector3.right);
		//向量a,b的夹角,得到的值为弧度，我们将其转换为角度，便于查看！
		float angle = Mathf.Acos (Vector3.Dot (direction.normalized, Vector3.right)) * Mathf.Rad2Deg;
		return new Vector3 (0, 0, -angle); 
	}
	
	
	void pressKey(){
		/*空格键跳跃*/
		if (Input.GetKeyDown (KeyCode.Space)){
			if(Player.getInstance.getPlayerState()!=PlayerState.Jumping){ //一段跳 
				player_rigidboy.velocity=new Vector3(0,jump,0);
				player_ac.SetBool(Tags.animator.Jump,true);
				Player.getInstance.setPlayerState(PlayerState.Jumping);
			}
			else if(player_ac.GetBool (Tags.animator.Jump2)==false){//二段跳
				player_rigidboy.velocity=new Vector3(0,jump,0);	
				player_ac.SetBool(Tags.animator.Jump2,true);
				player_ac.SetBool(Tags.animator.Jump,false);

			} 
		}


		if (Input.GetMouseButtonUp (0)) {
			CreatChain();
		}
	}
	


}
