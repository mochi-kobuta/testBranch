using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class city1Controller : MonoBehaviour {

	void Start () {
        gameObject.GetComponent<PlayerObjectLoadController>().initLoad();

        var ericeData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
        var layraData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;

        //Debug.Log(layraData.pData.Name);
    }
	
	void Update () {
		
	}
}
