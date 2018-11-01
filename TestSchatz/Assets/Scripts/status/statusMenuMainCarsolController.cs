using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstant;

public class statusMenuMainCarsolController : MonoBehaviour {

    public bool mainCarsolControlleFlag;
    public int currentStatusContent;

    //statusMenuでのメインカーソルの移動速度
    public const float STATUS_MENU_MAIN_CARSOL_MOVE_POS_X = 200.0f;

    public GameObject selectCarsolObj;

    private enum carsolContentsPositionX
    {
        ITEM = -230,//左限界点
        EQUIPMENT = -30,
        STATUS = 170,
        SPECIAL = 370,//右限界点
    }

    void Start () {
        mainCarsolControlleFlag = true;
        currentStatusContent = 0;
    }
	
	void Update () {

        //メインカーソル操作可能
        if(mainCarsolControlleFlag) { 

		    if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                //localPositionで親オブジェクトを起点とする
                transform.localPosition
                    = new Vector3(
                        transform.localPosition.x + STATUS_MENU_MAIN_CARSOL_MOVE_POS_X, 
                        transform.localPosition.y, 
                        transform.localPosition.z);

                //限界地超えていたら
                if(transform.localPosition.x > (float)carsolContentsPositionX.SPECIAL)
                {
                    transform.localPosition
                    = new Vector3(
                        (float)carsolContentsPositionX.ITEM,
                        transform.localPosition.y,
                        transform.localPosition.z);

                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //localPositionで親オブジェクトを起点とする
                transform.localPosition
                    = new Vector3(
                        transform.localPosition.x - STATUS_MENU_MAIN_CARSOL_MOVE_POS_X,
                        transform.localPosition.y,
                        transform.localPosition.z);

                //限界地超えていたら
                if (transform.localPosition.x < (float)carsolContentsPositionX.ITEM)
                {
                    transform.localPosition
                    = new Vector3(
                        (float)carsolContentsPositionX.SPECIAL,
                        transform.localPosition.y,
                        transform.localPosition.z);

                }
            }

            //項目を決定
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //メインカーソルの操作停止
                mainCarsolControlleFlag = false;
                selectCarsolObj.GetComponent<statusMenuSelectCarsolController>().selectCarsolControlleFlag = true;
                selectCarsolObj.SetActive(true);

                //コンテンツの決定
                if (transform.localPosition.x == (float)carsolContentsPositionX.ITEM)
                {
                    currentStatusContent = (int)ConstantList.statusMainContents.アイテム;
                }
                else if (transform.localPosition.x == (float)carsolContentsPositionX.EQUIPMENT)
                {
                    currentStatusContent = (int)ConstantList.statusMainContents.装備;
                }
                else if (transform.localPosition.x == (float)carsolContentsPositionX.STATUS)
                {
                    currentStatusContent = (int)ConstantList.statusMainContents.ステータス;
                }
                else if (transform.localPosition.x == (float)carsolContentsPositionX.SPECIAL)
                {
                    currentStatusContent = (int)ConstantList.statusMainContents.特殊;
                }
            }
        }


    }
}
