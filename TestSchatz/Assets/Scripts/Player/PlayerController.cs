using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstant;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject changeObj;

    private Animator AniCtrl;
    private int animetionStatus;

    private enum animetionDirection
    {
        DownWalk = 1,
        UpWalk = 2,
        LeftWalk = 3,
        RightWalk = 4,
        DownIdol = 5,
        UpIdol = 6,
        LeftIdol = 7,
        RightIdol = 8
    }

    void Start()
    {

        this.AniCtrl = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        //方向キー移動とアニメーション開始

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -ConstantList.PLAYER_MOVE_SPEED, 0);
            this.AniCtrl.SetBool("DownWalk", true);
            this.allIdolClear();
            animetionStatus = (int)animetionDirection.DownWalk;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, ConstantList.PLAYER_MOVE_SPEED, 0);
            this.AniCtrl.SetBool("UpWalk", true);
            this.allIdolClear();
            animetionStatus = (int)animetionDirection.UpWalk;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-ConstantList.PLAYER_MOVE_SPEED, 0, 0);
            this.AniCtrl.SetBool("LeftWalk", true);
            this.allIdolClear();
            animetionStatus = (int)animetionDirection.LeftWalk;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(ConstantList.PLAYER_MOVE_SPEED, 0, 0);
            this.AniCtrl.SetBool("RightWalk", true);
            this.allIdolClear();
            animetionStatus = (int)animetionDirection.RightWalk;
        }


        //方向キーアニメーションSTOP
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.AniCtrl.SetBool("DownWalk", false);
            this.AniCtrl.SetBool("DownIdol", true);
            animetionStatus = (int)animetionDirection.DownIdol;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.AniCtrl.SetBool("LeftWalk", false);
            this.AniCtrl.SetBool("LeftIdol", true);
            animetionStatus = (int)animetionDirection.LeftIdol;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.AniCtrl.SetBool("UpWalk", false);
            this.AniCtrl.SetBool("UpIdol", true);
            animetionStatus = (int)animetionDirection.UpIdol;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.AniCtrl.SetBool("RightWalk", false);
            this.AniCtrl.SetBool("RightIdol", true);
            animetionStatus = (int)animetionDirection.RightIdol;
        }

        //ステータス画面へ
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("statusMenu");
        }

        

        //プレイヤー切り替え
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            gameObject.SetActive(false);

            changeObj.SetActive(true);
            changeObj.transform.position 
                = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z);

            var cAnim = changeObj.GetComponent<Animator>();
            string status = checkAnimeStatus();
            cAnim.SetBool(status, true);
        }

    }

    void allIdolClear()
    {
        this.AniCtrl.SetBool("DownIdol", false);
        this.AniCtrl.SetBool("UpIdol", false);
        this.AniCtrl.SetBool("LeftIdol", false);
        this.AniCtrl.SetBool("RightIdol", false);
    }

    string checkAnimeStatus ()
    {
        string status;
        if(animetionStatus == (int)animetionDirection.DownWalk)
        {
            status = "DownWalk";
        }
        else if (animetionStatus == (int)animetionDirection.LeftWalk)
        {
            status = "LeftWalk";
        }
        else if (animetionStatus == (int)animetionDirection.RightWalk)
        {
            status = "RightWalk";
        }
        else if (animetionStatus == (int)animetionDirection.UpWalk)
        {
            status = "UpWalk";
        }
        else if (animetionStatus == (int)animetionDirection.DownIdol)
        {
            status = "DownIdol";
        }
        else if (animetionStatus == (int)animetionDirection.LeftIdol)
        {
            status = "LeftIdol";
        }
        else if (animetionStatus == (int)animetionDirection.RightIdol)
        {
            status = "RightIdol";
        }
        else if (animetionStatus == (int)animetionDirection.UpIdol)
        {
            status = "UpIdol";
        }
        else
        {
            status = "DownIdol";
        }

        return status;
    }

    
}
