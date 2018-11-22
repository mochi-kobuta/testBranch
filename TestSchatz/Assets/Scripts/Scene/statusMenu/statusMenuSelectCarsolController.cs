using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameConstant;
using Common;

public class statusMenuSelectCarsolController : MonoBehaviour {

    public bool selectCarsolControlleFlag;
    public int selectedContent = 0;

    //statusMenuでの選択カーソルの移動速度
    public const float STATUS_MENU_SELECT_CARSOL_MOVE_POS_X = 650.0f;

    public GameObject selectCarsolObj;

    private enum carsolCharactorPositionX
    {
        ERICE = -275,//左限界点
        LAYRA = 375,//右限界点L
    }

    void Start () {
        //(int)ConstantList.charactorType.エリス;

    }
	
	void Update () {
        //選択カーソル操作可能
        if (selectCarsolControlleFlag)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //localPositionで親オブジェクトを起点とする
                transform.localPosition
                    = new Vector3(
                        transform.localPosition.x + STATUS_MENU_SELECT_CARSOL_MOVE_POS_X,
                        transform.localPosition.y,
                        transform.localPosition.z);

                //限界地超えていたら
                if (transform.localPosition.x > (float)carsolCharactorPositionX.LAYRA)
                {
                    transform.localPosition
                    = new Vector3(
                        (float)carsolCharactorPositionX.ERICE,
                        transform.localPosition.y,
                        transform.localPosition.z);

                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //localPositionで親オブジェクトを起点とする
                transform.localPosition
                    = new Vector3(
                        transform.localPosition.x - STATUS_MENU_SELECT_CARSOL_MOVE_POS_X,
                        transform.localPosition.y,
                        transform.localPosition.z);

                //限界地超えていたら
                if (transform.localPosition.x < (float)(float)carsolCharactorPositionX.ERICE)
                {
                    transform.localPosition
                    = new Vector3(
                        (float)(float)carsolCharactorPositionX.LAYRA,
                        transform.localPosition.y,
                        transform.localPosition.z);

                }
            }

            //項目を決定
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //メインカーソルの操作停止
                selectCarsolControlleFlag = false;

                //どのキャラのデータを渡すのか
                if (transform.localPosition.x == (float)carsolCharactorPositionX.ERICE)
                {
                    CommonValue.charaType = (int)ConstantList.charactorType.エリス;
                }
                else if (transform.localPosition.x == (float)carsolCharactorPositionX.LAYRA)
                {
                    CommonValue.charaType = (int)ConstantList.charactorType.レイラ;
                }

                //コンテンツの決定
                if (selectedContent == (int)ConstantList.statusMainContents.アイテム)
                {
                    SceneManager.LoadScene("statusItem");
                }
                else if (selectedContent == (int)ConstantList.statusMainContents.ステータス)
                {
                    SceneManager.LoadScene("statusDetail");
                }
                else if (selectedContent == (int)ConstantList.statusMainContents.装備)
                {
                    SceneManager.LoadScene("statusEquipment");
                }
                else if (selectedContent == (int)ConstantList.statusMainContents.特殊)
                {
                    SceneManager.LoadScene("statusSkill");
                }
            }
        }
    }
}
