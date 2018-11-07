﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameConstant;
using Player;
using UnityEditor;

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
    
    //外部変更用変数
    public static int charaType;

    private PlayerData pData;

    private enum SpriteIndex
    {
        元絵 = 0,
        レイラ = 1,
        エリス = 2
    }

    void Start()
    {
        Object[] uiSprites = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Assets/Texture/Parts/charactorProfile.png");


        var textName = "";
        if(charaType == (int)ConstantList.charactorType.エリス)
        {
            textName = "erice.txt";
            frameImage.sprite = (Sprite)uiSprites[(int)SpriteIndex.エリス];
            pData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;

        }
        else if (charaType == (int)ConstantList.charactorType.レイラ) {
            textName = "layra.txt";
            frameImage.sprite = (Sprite)uiSprites[(int)SpriteIndex.レイラ]; ;
            pData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;
        }

        var textOp = gameObject.GetComponent<textLoadController>();
        profileText.text = textOp.ReadFile("Data/Text/Profile/" + textName);


        //ステータスの情報を格納
        hp.text = "HP " + pData.Hp.ToString() + " / " + pData.MaxHp.ToString();
        tp.text = "TP " + pData.Tp.ToString() + " / " + pData.MaxTp.ToString();
        level.text = "レベル " + pData.Level.ToString();
        atk.text = "攻撃力 " + pData.Atk.ToString();
        def.text = "防御力 " + pData.Def.ToString();
        mAtk.text = "魔法攻撃力 " + pData.MgAtk.ToString();
        mDef.text = "魔法防御力 " + pData.MgDef.ToString();
        spd.text = "早さ " + pData.Spd.ToString() ;
        luck.text = "運 " + pData.Luck.ToString();
        exp.text = "総獲得経験値 " + pData.Exp.ToString();

    }
    

    void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("statusMenu");
        }
    }
}