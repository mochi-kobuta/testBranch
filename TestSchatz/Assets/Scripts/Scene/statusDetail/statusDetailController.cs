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

public class statusDetailController : MonoBehaviour {

    
    public Image frameImage;
    public Text profileText;
    public Text hp;
    public Text tp;
    public Text level;
    public Text atk;
    public Text def;
    public Text mAtk;
    public Text mDef;
    public Text spd;
    public Text luck;
    public Text exp;

    private PlayerData pData;
    private TextAsset profData;

    private enum SpriteIndex
    {
        元絵 = 0,
        レイラ = 1,
        エリス = 2
    }

    void Start()
    {
        gameObject.GetComponent<PlayerObjectLoadController>().initLoad();

        var textName = "";
        if(CommonValue.charaType == (int)ConstantList.charactorType.エリス)
        {
            textName = "Data/Text/Profile/erice";
            frameImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_1");
            pData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
        }
        else if (CommonValue.charaType == (int)ConstantList.charactorType.レイラ) {
            textName = "Data/Text/Profile/layra";
            frameImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_0");
            pData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;
        }

        
        profData = Resources.Load<TextAsset>(textName);
        Debug.Log(profData);
        profileText.text = profData.text;


        //ステータスの情報を格納
        //装備中の武器があれば基本ステータスに追加
        int wAtk = pData.EquipWeapon.Atk;
        int wDef = pData.EquipWeapon.Def;
        int wMgAtk = pData.EquipWeapon.MgAtk;
        int wMgDef = pData.EquipWeapon.MgDef;
        int wSpd = pData.EquipWeapon.Spd;
        int wLuck = pData.EquipWeapon.Luck;

        hp.text = "HP " + pData.Hp.ToString() + " / " + pData.MaxHp.ToString();
        tp.text = "TP " + pData.Tp.ToString() + " / " + pData.MaxTp.ToString();
        level.text = "レベル " + pData.Level.ToString();
        atk.text = "攻撃力 " + (pData.Atk + wAtk).ToString();
        def.text = "防御力 " + (pData.Def + wDef).ToString();
        mAtk.text = "魔法攻撃力 " + (pData.MgAtk + wMgAtk).ToString();
        mDef.text = "魔法防御力 " + (pData.MgDef + wMgDef).ToString();
        spd.text = "早さ " + (pData.Spd + wSpd).ToString() ;
        luck.text = "運 " + (pData.Luck + wLuck).ToString();
        exp.text = "総獲得経験値 " + pData.Exp.ToString();

    }
    

    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("statusMenu");
        }
    }
}
