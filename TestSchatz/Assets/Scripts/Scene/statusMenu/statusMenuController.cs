using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statusMenuController : MonoBehaviour {

    public Text lHp;
    public Text lTp;
    public Text eHp;
    public Text eTp;

    public Text maney, place;

    void Start () {
        var gOb = gameObject.GetComponent<PlayerObjectLoadController>();
        gOb.initLoad();
        gOb.PossessionLoad();

        var ericeData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
        var layraData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;
        var possessionData = GameObject.Find("possessionData").GetComponent<PossessionBaseController>().possessionData;

        //HPとMP情報
        /*
        eHp = GameObject.Find("ericeFrame/hp").GetComponent<Text>();
        lHp = GameObject.Find("layraFrame/hp").GetComponent<Text>();
        eTp = GameObject.Find("ericeFrame/tp").GetComponent<Text>();
        lTp = GameObject.Find("layraFrame/tp").GetComponent<Text>();
        */

        lHp.text = "HP " + layraData.Hp.ToString() + " / " + layraData.MaxHp.ToString();
        eHp.text = "HP " + ericeData.Hp.ToString() + " / " + ericeData.MaxHp.ToString();
        lTp.text = "TP " + layraData.Tp.ToString() + " / " + layraData.MaxTp.ToString();
        eTp.text = "TP " + ericeData.Tp.ToString() + " / " + ericeData.MaxTp.ToString();

        maney.text = "所持金 " + possessionData.Maney.ToString();
        place.text = "はじまりの森";
    }
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("city1");
        }
    }
}
