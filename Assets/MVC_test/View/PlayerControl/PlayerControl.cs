using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerControl : MonoBehaviour {

	  float run_speed;
	 float jump;
	 Vector3 pressDown;

	//private
	Animator player_ac;
	Rigidbody player_rigidboy;

	GameObject curMonster;
	int isTriggerTimes = 0;

  

	void Start ()
	{
	  
		run_speed = Player.getInstance.getRunSpeed();
		jump = Player.getInstance.getJump ();
		player_ac=this.GetComponent<Animator>();//获取动画控制器
		player_rigidboy=this.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update  () {
      
		pressKey ();//按键相关

		JugeMonster ();


		switch(Player.getInstance.getPlayerState()){
		case PlayerState.Running:{
			PlayerMove();
		}break;
		case PlayerState.OnChain:{

		}break;
		case PlayerState.Jumping:{
									PlayerMove();
									PlayerJump();
		}break;
		case PlayerState.Atking:{
	
		}break;

		}

	}

	void pressKey(){

		if (Input.GetKeyDown (KeyCode.Space)){/*空格键跳跃*/
			if(Player.getInstance.getPlayerState()!=PlayerState.Jumping){ //一段跳 
				Player.getInstance.setPlayerState(PlayerState.Jumping);
				player_rigidboy.velocity=new Vector3(0,jump,0);
				player_ac.SetBool(Tags.animator_player.Jump,true);
				player_ac.SetBool (Tags.animator_player.Jump2,false);
			}
			else if(player_ac.GetBool (Tags.animator_player.Jump2)==false){//二段跳
				player_rigidboy.velocity=new Vector3(0,jump,0);	
				player_ac.SetBool(Tags.animator_player.Jump2,true);
				player_ac.SetBool(Tags.animator_player.Jump,false);
				
			} 
		}

		//鼠标获取锁链角度
		if (Input.GetMouseButtonDown (0)) {
			pressDown=RayPoint(Tags.tag.Bg);
		}
		
		if (Input.GetMouseButtonUp (0)) {
			Vector3 hit=RayPoint(Tags.tag.Bg);
			if(!pressDown.Equals(Vector3.zero) && !hit.Equals(Vector3.zero) && (hit-pressDown).magnitude>1f){
				CreatChain(hit);
			} 
			pressDown=Vector3.zero;
		}
	}
    private float timer = 0;

    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag.Equals(Tags.tag.zhangaiwu))
        {
           
            timer += Time.deltaTime;
            if (timer > 1)
            {
            
                UI.getInstance.setInstanceNull();
                Player.getInstance.setInstanceNull();
                timer = 0;
                Application.LoadLevel(Application.loadedLevel);

            }

        }
    }

    void OnCollisionEnter(Collision other) {//任务碰撞检测
		if (other.collider.tag.Equals (Tags.tag.Base)) {//碰到地面
			player_ac.SetBool (Tags.animator_player.Jump2, false);
			player_ac.SetBool (Tags.animator_player.Jump, false);
			Player.getInstance.setPlayerState(PlayerState.Running);
		}
        
        if (other.collider.tag.Equals (Tags.tag.Chain)) {//碰到锁链
			if(!this.GetComponent<CharacterJoint>()){//添加链接关节
				CharacterJoint c_joint=this.gameObject.AddComponent<CharacterJoint>();
				c_joint.connectedBody=other.collider.GetComponent<Rigidbody>();
				player_rigidboy.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezePositionZ;
				player_rigidboy.AddForce(Vector3.right*50f);
			}
		}
		if(other.collider.tag.Equals(Tags.tag.surfice)){//碰到底部
			UI.getInstance.setInstanceNull();
			Player.getInstance.setInstanceNull();
			Application.LoadLevel(Application.loadedLevel);

		}

	}


	/*移动*/

	void PlayerMove(){
		JugeComponent();
		this.transform.Translate (Vector3.right*run_speed* Time.deltaTime,Space.World);
	}

	/*攻击*/

	public void AtkButtonDown(){
		if (curMonster != null) {
			if(curMonster.tag.Equals(Tags.tag.smallBoss)){
				curMonster.GetComponent<SmallBoss>().Rebound();
			}
			if(curMonster.tag.Equals(Tags.tag.Monster)){
				Destroy(curMonster);
			}
			Player.getInstance.Monster=Player.getInstance.Monster+1;
			UI.getInstance.ChangeMonsterCount(Player.getInstance.Monster);
			curMonster=null;
			UI.getInstance.changeAtkBtnColor(Color.white);
		}
	}

	void JugeMonster(){
		if (curMonster!=null && curMonster.transform.position.x < this.transform.position.x) {
			curMonster=null;
			UI.getInstance.changeAtkBtnColor(Color.white);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if ((other.tag.Equals (Tags.tag.Monster) ||other.tag.Equals (Tags.tag.smallBoss))
		    && other.transform.position.x>this.transform.position.x) {
			curMonster=other.gameObject;
			isTriggerTimes++;
			if(isTriggerTimes==1)  UI.getInstance.changeAtkBtnColor(Color.red);
			if(isTriggerTimes==2) {
				UI.getInstance.changeAtkBtnColor(Color.yellow);
				isTriggerTimes=0;
			} 	
		}
	}



	/*跳跃*/


	void JugeComponent(){
		if (this.GetComponent<CharacterJoint> ()) {
			this.transform.eulerAngles=Vector3.zero;

			Destroy(this.GetComponent<CharacterJoint> ());
			this.transform.rotation=Quaternion.Euler(Vector3.zero);
			player_rigidboy.constraints = RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.FreezePositionZ;
		}
	}

	void PlayerJump(){
		if (player_ac.GetBool (Tags.animator_player.Jump))
			player_ac.SetFloat (Tags.animator_player.Velocity, player_rigidboy.velocity.y);
		if (player_ac.GetBool (Tags.animator_player.Jump2))
			player_ac.SetFloat (Tags.animator_player.Velocity2, player_rigidboy.velocity.y);	

	}


	/*锁链*/
	void CreatChain(Vector3 point){
		Vector3 direction=(point-pressDown).normalized;//松开处与人物的角度方向
			float angle=getAngle(direction);//角度
		    float chain_angle=angle-90; //锁链摇摆的初始角度

		   // Vector3 connect_point=this.transform.GetChild(1).position;//获取人物身上的连接点
		    if (direction.x >= 0 && direction.y >= 0 && direction.z >= 0) {

				Vector3 c=(this.transform.GetChild(0).GetChild(3).position-this.transform.position);//计算倾斜角度，算人物身上点相关的距离
				Vector3 b=Quaternion.AngleAxis(chain_angle, Vector3.forward)*c;
				Vector3 connect_point=b+this.transform.position;//获取人物身上的连接点


				float y = Tags.chain.chain_position_y - connect_point.y;
				float distance = y / Mathf.Sin ((Mathf.PI / 180) * angle);
				//float chain_angle = 90 - angle; //锁链摇摆的初始角度
		
	 
				if (Player.getInstance.getChainMinLong () <= distance && distance <= Player.getInstance.getChainMaxLong ()) { 
					Player.getInstance.setPlayerState (PlayerState.OnChain);//成功创建时进入锁链状态
					
					Vector3 temp=this.transform.eulerAngles;//使人物按锁链角度倾斜
					temp.z=chain_angle;
					this.transform.eulerAngles=temp;

					GameObject obj = Resources.Load<GameObject> (Tags.prb_path.Chain);//取预制体
					Chain chain = obj.GetComponent<Chain> ();
					chain.setLong(distance);
					Instantiate (obj, connect_point, Quaternion.Euler (new Vector3 (0, 0, chain_angle)));//创建锁链Quaternion.identity
				
				}else {
					//获取线的尾端
					Vector3 a = new Vector3 (0, Player.getInstance.getChainMaxLong (), 0);
					Vector3 d = Quaternion.AngleAxis (chain_angle, Vector3.forward) * a;
					Vector3 end = d + connect_point;
					
					//画线
					GameObject line = Resources.Load<GameObject> (Tags.prb_path.line);//取预制体
					line.GetComponent<Line> ().setPosition (connect_point, end);
					Instantiate (line);

				}
		} 
	}





	//获取鼠标点击和抬起与人物水平移动方向的角度
	float getAngle(Vector3 direction){
		//点积的返回值
		float c = Vector3.Dot (direction, Vector3.right);
		//向量a,b的夹角,得到的值为弧度，我们将其转换为角度，便于查看！
		float angle = Mathf.Acos (Vector3.Dot (direction.normalized, Vector3.right)) * Mathf.Rad2Deg;
		return angle;
	}

	//射线检测
	Vector3 RayPoint(string tag){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit(); 

		//获取bg层级，避免与其他层的碰撞器产生冲突
		//层级在Inspector的Layer中设定
		//1<<10 打开第10层
		Physics.Raycast (ray, out hit, 100, (1 << LayerMask.NameToLayer(Tags.layer.bg)));
		if (null != hit.transform && hit.transform.tag.Equals (tag)) 
			return hit.point;
		else
			return Vector3.zero;
	}



}
