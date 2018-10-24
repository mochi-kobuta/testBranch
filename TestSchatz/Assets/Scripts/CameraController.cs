using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public GameObject followTargetObject;
	
  void Start () {
		
	}
	
	void Update () {
    gameObject.transform.position = new Vector3(followTargetObject.transform.position.x, 0, -10);
	}
}
