using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class statusDetailController : MonoBehaviour {

    public Text changeTargetText;

    /*
    public class Parameter
    {
        public int IntParam;
    }
    public Parameter Param;
    */
    void Start()
    {
        var textOp = gameObject.GetComponent<textOpen>();
        changeTargetText.text = textOp.ReadFile();
        Debug.Log(changeTargetText.text);
    }
    

    void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("statusMenu");
        }
    }
}
