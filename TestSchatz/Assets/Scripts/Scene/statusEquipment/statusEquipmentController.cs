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
using Equipment;
using GameConstant;

public class statusEquipmentController : MonoBehaviour {

    public RectTransform prefab;
    public RectTransform content;

    public Text charaName;
    public Text weaponName;
    public Text armorName;

    public Text atk;
    public Text def;
    public Text mAtk;
    public Text mDef;
    public Text luck;
    public Text speed;
    public Image equipImage;
    public Text detail;

    private PlayerData pData;
    private PossessionData possessionData;
    private TextAsset profData;
    private STATE state;

    private enum STATE
    {
        なし = 0,
        初期読み込み_設定 = 1,
        決定待ち = 2,
        更新 = 3,

    }

    void Start () {
        var gOb = gameObject.GetComponent<PlayerObjectLoadController>();
        gOb.initLoad();
        //gOb.PossessionLoad();

        //所持データ
        possessionData = GameObject.Find("possessionData").GetComponent<PossessionBaseController>().possessionData;


        state = STATE.なし;

        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("statusMenu");
        }

        switch (state)
        {
            
            case STATE.初期読み込み_設定:
                DataLoad();
                break;

            case STATE.決定待ち:

                break;

            case STATE.更新:

                break;
        }
    }


    void DataLoad()
    {
        if (CommonValue.charaType == (int)ConstantList.charactorType.エリス)
        {
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_1");
            pData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
            paramSet(pData.EquipWeapon);
            this.posseionEquipSet(possessionData.ericeEquipList);
        }
        else if (CommonValue.charaType == (int)ConstantList.charactorType.レイラ)
        {
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_0");
            pData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;
            paramSet(pData.EquipWeapon);
            this.posseionEquipSet(possessionData.layraEquipList);
        }
    }



    void paramSet(EquipmentData eData, bool change = false)
    {
        if(!change)
        {
            charaName.text = pData.Name;
            weaponName.text = pData.EquipWeapon.Name;
            armorName.text = pData.EquipArmor.Name;
            atk.text = "攻:" + (pData.EquipWeapon.Atk + pData.Atk).ToString();
            def.text = "防:" + (pData.EquipWeapon.Def + pData.Def).ToString();
            mAtk.text = "魔攻:" + (pData.EquipWeapon.MgAtk + pData.MgAtk).ToString();
            mDef.text = "魔防:" + (pData.EquipWeapon.MgDef + pData.MgDef).ToString();
            luck.text = "運:" + (pData.EquipWeapon.Luck + pData.Luck).ToString();
            speed.text = "早:" + (pData.EquipWeapon.Spd + pData.Spd).ToString();
            detail.text = pData.EquipWeapon.Detail;
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile(pData.EquipWeapon.fileName, pData.EquipWeapon.spriteName);

        } else {
            charaName.text = pData.Name;
            weaponName.text = pData.EquipWeapon.Name + "\r\n" + "↓" + "\r\n" + eData.Name;
            armorName.text = pData.EquipArmor.Name;
            atk.text = "攻:" + (pData.EquipWeapon.Atk + pData.Atk).ToString() + "→" + (pData.EquipWeapon.Atk + eData.Atk).ToString();
            def.text = "防:" + (pData.EquipWeapon.Def + pData.Def).ToString() + "→" + (pData.EquipWeapon.Def + eData.Def).ToString(); ;
            mAtk.text = "魔攻:" + (pData.EquipWeapon.MgAtk + pData.MgAtk).ToString() + "→" + (pData.EquipWeapon.MgAtk + eData.MgAtk).ToString();
            mDef.text = "魔防:" + (pData.EquipWeapon.MgDef + pData.MgDef).ToString() + "→" + (pData.EquipWeapon.MgDef + eData.MgDef).ToString();
            luck.text = "運:" + (pData.EquipWeapon.Luck + pData.Luck).ToString() + "→" + (pData.EquipWeapon.Luck + eData.Luck).ToString();
            speed.text = "早:" + (pData.EquipWeapon.Spd + pData.Spd).ToString() + "→" + (pData.EquipWeapon.Spd + eData.Spd).ToString();
            detail.text = eData.Detail;
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile(eData.fileName, eData.spriteName);
        }
    }

    void posseionEquipSet(EquipmentData[] elements)
    {
        // Itemを生成
        foreach(var elm in elements) {
            //装備中の武器は飛ばす
            if(elm.setOn)
            {
                continue;
            }

            var equipFrame = GameObject.Instantiate(prefab) as RectTransform;
            // Contentの子として登録  
            equipFrame.SetParent(content, false);
            
            var equipDetail = equipFrame.FindChild("equipDetail");
            Debug.Log(equipDetail);

            var equipName = equipDetail.FindChild("equip");
            var detail = equipDetail.FindChild("deteil");
            var changeButton = equipFrame.FindChild("Button");
            
            //武器名と詳細、ボタン処理追加
            equipName.GetComponent<Text>().text = elm.Name;

            detail.GetComponent<Text>().text = "種別:" + (ConstantList.weaponCategory)elm.Category;

            //他武器の詳細表示
            equipDetail.GetComponent<Button>().onClick.AddListener(() => { paramSet(elm, true); });

            //他武器に変更
            changeButton.GetComponent<Button>().onClick.AddListener(() => { changeEquipSet(elm); });

            //STATEの健康
            state = STATE.決定待ち;
        }
    }

    void changeEquipSet(EquipmentData eData)
    {
        //武器変更
        pData.EquipWeapon = eData;
        
        if (CommonValue.charaType == (int)ConstantList.charactorType.エリス)
        {
            foreach (var equip in possessionData.ericeEquipList)
            {
                //所持リストの装備のON/OFF切り替え
                if(equip.Number == eData.Number)
                {
                    equip.setOn = true;
                } else {
                    equip.setOn = false;
                }
            }
        }
        else if (CommonValue.charaType == (int)ConstantList.charactorType.レイラ)
        {
            foreach (var equip in possessionData.layraEquipList)
            {
                //所持リストの装備のON/OFF切り替え
                if (equip.Number == eData.Number)
                {
                    equip.setOn = true;
                }
                else
                {
                    equip.setOn = false;
                }
            }
        }    
    }


    //更新用
    void UpdateEquipDataList()
    {

    }
}
