using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameConstant;
using Player;
using UnityEditor;
using System.IO;
using System.Text;
using Common;

public class statusEquipmentController : MonoBehaviour {

    
    public Text name;
    public Text atk;
    public Text def;
    public Text mAtk;
    public Text mDef;
    public Image equipImage;

    //外部変更用変数
    public static int charaType;

    private PlayerData pData;
    private TextAsset profData;

    void Start () {
        gameObject.GetComponent<PlayerObjectLoadController>().initLoad();

        var textName = "";
        if (charaType == (int)ConstantList.charactorType.エリス)
        {
            textName = "Data/Text/Profile/erice";
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_1");
            pData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
        }
        else if (charaType == (int)ConstantList.charactorType.レイラ)
        {
            textName = "Data/Text/Profile/layra";
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_0");
            pData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
