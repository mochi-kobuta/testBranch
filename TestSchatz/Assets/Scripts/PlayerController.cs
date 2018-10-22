using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstant;

public class PlayerController : MonoBehaviour {
    private Animator AniCtrl;

	void Start () {

        this.AniCtrl = gameObject.GetComponent<Animator>();
    }
	
	void Update () {
        //方向キー移動とアニメーション開始
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -ConstantList.PLAYER_MOVE_SPEED, 0);
            this.AniCtrl.SetBool("DownWalk",true);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, ConstantList.PLAYER_MOVE_SPEED, 0);
            this.AniCtrl.SetBool("UpWalk", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-ConstantList.PLAYER_MOVE_SPEED, 0, 0);
            this.AniCtrl.SetBool("LeftWalk", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(ConstantList.PLAYER_MOVE_SPEED, 0, 0);
            this.AniCtrl.SetBool("RightWalk", true);
        }

        
        //方向キーアニメーションSTOP
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.AniCtrl.SetBool("DownWalk", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.AniCtrl.SetBool("LeftWalk", false);
            this.AniCtrl.SetBool("LeftIdol", true);
        }
            
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.AniCtrl.SetBool("UpWalk", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.AniCtrl.SetBool("RightWalk", false);
        }
   
        
    }


}
