using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameConstant;

public class CameraController : MonoBehaviour {

  //視点を追うオブジェクト
  private GameObject followTargetObject;

  //視点オブジェクトの初期位置調整関数
  public float followTargetObjectPositionX;
  public float followTargetObjectPositionY;

  //入り口と出口の情報（X軸方向）
  public GameObject startPointX = null;
  public GameObject endPointX = null;

  //入り口と出口の情報（Y軸方向）
  public GameObject startPointY = null;
  public GameObject endPointY = null;

  //メンバ変数
  private bool pointCheckFlag = false;
  private Vector3 commitCameraPosition = new Vector3();
  private float INIT_VALUE_SIGN_X = 1.0f;
  private float INIT_VALUE_SIGN_Y = -1.0f;

  void Start () {
      pointCheckFlag = pointCheck();
  }

    void Update()
    {
        var layra = GameObject.Find("layra");
        var erice = GameObject.Find("erice");
        if (layra != null)
        {
            followTargetObject = layra;
        }
        else if(erice != null) {
            followTargetObject = erice;
        }
        
        //Debug.Log(followTargetObject);

        //X方向と方向の入り口と出口の情報があった場合カメラの追随制限をかける
        if (pointCheckFlag)
        {
            var sPosX = followTargetObject.transform.position.x - startPointX.transform.position.x;
            var ePosX = endPointX.transform.position.x - followTargetObject.transform.position.x;
            var sPosY = followTargetObject.transform.position.y - startPointY.transform.position.y;
            var ePosY = endPointY.transform.position.y - followTargetObject.transform.position.y;

            //カメラ追随位置初期化
            if (followTargetObjectPositionX > 0)
            {
                commitCameraPosition.x = followTargetObject.transform.position.x;
            }
            else
            {
                commitCameraPosition.x = followTargetObject.transform.position.x;
            }

            if (followTargetObjectPositionY > 0)
            {
                commitCameraPosition.y = followTargetObject.transform.position.y;
            }
            else
            {
                commitCameraPosition.y = followTargetObject.transform.position.y;
            }


            if (Input.GetKey(KeyCode.Space))
            {

            }


            if (sPosX <= ConstantList.MAIN_CAMERA_WIDTH_SIZE)
            {
                commitCameraPosition.x = startPointX.transform.position.x + ConstantList.MAIN_CAMERA_WIDTH_SIZE;
            }

            if (ePosX <= ConstantList.MAIN_CAMERA_WIDTH_SIZE)
            {
                commitCameraPosition.x = endPointX.transform.position.x - ConstantList.MAIN_CAMERA_WIDTH_SIZE;
            }

            if (sPosY <= ConstantList.MAIN_CAMERA_HEIGHT_SIZE)
            {
                commitCameraPosition.y = startPointY.transform.position.y + ConstantList.MAIN_CAMERA_HEIGHT_SIZE;
                INIT_VALUE_SIGN_Y = 1.0f;
            }

            if (ePosY <= ConstantList.MAIN_CAMERA_HEIGHT_SIZE)
            {
                commitCameraPosition.y = endPointY.transform.position.y - ConstantList.MAIN_CAMERA_HEIGHT_SIZE;
                INIT_VALUE_SIGN_Y = -1.0f;
            }

            gameObject.transform.position = new Vector3(commitCameraPosition.x, commitCameraPosition.y, ConstantList.INIT_CAMERA_POSITION_Z);

        }
        else
        {
            gameObject.transform.position = new Vector3(followTargetObject.transform.position.x, followTargetObject.transform.position.y + ConstantList.CITY1_PLAYER_INIT_POSITION_Y, ConstantList.INIT_CAMERA_POSITION_Z);
        }

    }

    //エントリーポイントとアウトポイントがセットされているか
    bool pointCheck()
    {
        if (startPointX == null)
            return false;

        if (endPointX == null)
            return false;

        if (startPointY == null)
            return false;

        if (endPointY == null)
            return false;

        return true;
    }
}
