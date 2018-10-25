using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameConstant;

public class CameraController : MonoBehaviour {

  public GameObject followTargetObject;

  //入り口の位置情報
  public GameObject startPoint = null;

  //出口の位置情報
  public GameObject endPoint = null;

  void Start () {

    
	}
	
	void Update () {

    //入り口と出口の情報があった場合カメラの追随制限をかける
    if(endPoint != null && endPoint != null)
    { 
      var sPos = followTargetObject.transform.position.x - startPoint.transform.position.x;
      var ePos = endPoint.transform.position.x - followTargetObject.transform.position.x;
      if (sPos <= ConstantList.MAIN_CAMERA_WIDTH_SIZE)
      {
        gameObject.transform.position = new Vector3(startPoint.transform.position.x + ConstantList.MAIN_CAMERA_WIDTH_SIZE, followTargetObject.transform.position.y + 1.5f, -10);
      } else if (ePos <= 4) {
        gameObject.transform.position = new Vector3(endPoint.transform.position.x - ConstantList.MAIN_CAMERA_WIDTH_SIZE, followTargetObject.transform.position.y + 1.5f, -10);
      } else {
        gameObject.transform.position = new Vector3(followTargetObject.transform.position.x, followTargetObject.transform.position.y + 1.5f, -10);
      }
    } else {
      gameObject.transform.position = new Vector3(followTargetObject.transform.position.x, followTargetObject.transform.position.y + 1.5f, -10);
    }




  }
}
