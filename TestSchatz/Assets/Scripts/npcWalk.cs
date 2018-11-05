using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstant;

[RequireComponent(typeof(Animator))]
public class npcWalk : MonoBehaviour {

    private int idX = Animator.StringToHash("x"), 
        idY = Animator.StringToHash("y");
    private Animator animator = null;
    private float x, y;

    private int frameCount = 0;
    private int AnimframeCount = 0;
    private bool AnimeFlag = false;
    private int direction = 0;

    private bool talkFlag = false;

    private enum animetionDirection
    {
        DownWalk = 1,
        UpWalk = 2,
        LeftWalk = 3,
        RightWalk = 4,
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!AnimeFlag)
        {
            frameCount++;
        }
        
        if(frameCount >= 120) {
            AnimeFlag = true;
            frameCount = 0;
            direction = Random.Range(0, (int)animetionDirection.RightWalk);
        }

        if(AnimframeCount >= 30)
        {
            if(!talkFlag)
            {
                AnimeFlag = false;
                AnimframeCount = 0;
            }
        }

        if(AnimeFlag) {

            AnimframeCount++;

            if (direction == (int)animetionDirection.UpWalk)
            {
                x = 0.0f;
                y = 1.0f;
            }
            else if (direction == (int)animetionDirection.DownWalk) {
                x = 0.0f;
                y = -1.0f;
            }
            else if (direction == (int)animetionDirection.LeftWalk) {
                x = -1.0f;
                y = 0.0f;
            }
            else if (direction == (int)animetionDirection.RightWalk) {
                x = 1.0f;
                y = 0.0f;
            }

            if ((Mathf.FloorToInt(x) != 0 || Mathf.FloorToInt(y) != 0) && !talkFlag)
            {
                animator.SetFloat(idX, x);
                animator.SetFloat(idY, y);

                transform.localPosition += new Vector3(x, y) * ConstantList.NPC_MOVE_SPEED;
            }
        }

        if(talkFlag && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("OK");
            //NPCの向きをプレイヤーの方に向ける？
            //話中の吹き出し表示する
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        talkFlag = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        talkFlag = false;
    }
}
