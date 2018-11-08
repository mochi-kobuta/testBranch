using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleController : MonoBehaviour {


	void Start () {
        gameObject.GetComponent<PlayerObjectLoadController>().initLoad();
    }
	
	void Update () {
      if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
      {
          SceneManager.LoadScene("city1");
      }
		
	}
}
