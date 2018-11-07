using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statusMenuController : MonoBehaviour {

    private Text lHp, lMp, eHp, eMp;

    void Start () {
        var ericeData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
        var layraData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;

        //HPとMP情報
        eHp = GameObject.Find("ericeFlame/hp").GetComponent<Text>();
        lHp = GameObject.Find("layraFlame/hp").GetComponent<Text>();
        eMp = GameObject.Find("ericeFlame/mp").GetComponent<Text>();
        lMp = GameObject.Find("layraFlame/mp").GetComponent<Text>();

        lHp.text = "HP " + layraData.Hp.ToString() + " / " + layraData.MaxHp.ToString();
        eHp.text = "HP " + ericeData.Hp.ToString() + " / " + ericeData.MaxHp.ToString();
        lMp.text = "TP " + layraData.Tp.ToString() + " / " + layraData.MaxTp.ToString();
        eMp.text = "TP " + ericeData.Tp.ToString() + " / " + ericeData.MaxTp.ToString();
    }
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("city1");
        }
    }
}
