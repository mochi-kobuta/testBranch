using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleController : MonoBehaviour {


	void Start () {
		
	}
	
	void Update () {
      if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
      {
          SceneManager.LoadScene("city1");
      }
		
	}
}
