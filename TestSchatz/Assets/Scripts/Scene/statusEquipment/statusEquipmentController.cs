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
        
        //所持データ
        possessionData = GameObject.Find("possessionData").GetComponent<PossessionBaseController>().possessionData;

        //STATEの初期化
        state = STATE.初期読み込み_設定;
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
                //処理は特にしない
                break;

            case STATE.更新:
                DataLoad(true);
                break;
        }
    }

    //読み込み処理
    void DataLoad(bool set = false)
    {
        if (CommonValue.charaType == (int)ConstantList.charactorType.エリス)
        {
            if(pData == null)
                pData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;

            paramSet(pData.EquipWeapon);
            this.posseionEquipSet(possessionData.ericeEquipList, set);
        }
        else if (CommonValue.charaType == (int)ConstantList.charactorType.レイラ)
        {
            if (pData == null)
                pData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;

            paramSet(pData.EquipWeapon);
            this.posseionEquipSet(possessionData.layraEquipList, set);
        }
    }


    //表示装備パラメータ設定
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
            atk.text = "攻:" + (pData.EquipWeapon.Atk + pData.Atk).ToString() + "→" + (pData.Atk + eData.Atk).ToString();
            def.text = "防:" + (pData.EquipWeapon.Def + pData.Def).ToString() + "→" + (pData.Def + eData.Def).ToString(); ;
            mAtk.text = "魔攻:" + (pData.EquipWeapon.MgAtk + pData.MgAtk).ToString() + "→" + (pData.MgAtk + eData.MgAtk).ToString();
            mDef.text = "魔防:" + (pData.EquipWeapon.MgDef + pData.MgDef).ToString() + "→" + (pData.MgDef + eData.MgDef).ToString();
            luck.text = "運:" + (pData.EquipWeapon.Luck + pData.Luck).ToString() + "→" + (pData.Luck + eData.Luck).ToString();
            speed.text = "早:" + (pData.EquipWeapon.Spd + pData.Spd).ToString() + "→" + (pData.Spd + eData.Spd).ToString();
            detail.text = eData.Detail;
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile(eData.fileName, eData.spriteName);
        }
    }

    //所持装備の表示設定
    void posseionEquipSet(EquipmentData[] elements, bool change = false)
    {
        //変更後の装備の番号格納用
        int indexNumber = 0;

        foreach(var elm in elements) {
            
            if (!change)
            {
                var equipFrame = GameObject.Instantiate(prefab) as RectTransform;
                // Contentの子として登録
                equipFrame.name = elm.Number.ToString();
                equipFrame.SetParent(content, false);

                var equipDetail = equipFrame.FindChild("equipDetail");

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

                //装備中の武器は非活性
                if (elm.setOn)
                    equipFrame.gameObject.SetActive(false);
            } else {
                //変更後の装備の番号格納
                if (elm.setOn)
                    indexNumber = elm.Number;
            }
            
            //STATEの健康
            state = STATE.決定待ち;
        }

        if(change) {
            RectTransform[] putFrame;
            putFrame = new RectTransform[ConstantList.WEAPON_TOTAL_NUM];
            for (int i = 0; i < putFrame.Length; i++)
            {
                putFrame[i] = GameObject.Find(string.Format("Viewport/Content/{0}", i)).GetComponent<RectTransform>();

                if (putFrame[i].gameObject.name != indexNumber.ToString())
                {              
                    putFrame[i].gameObject.SetActive(true);
                } else {
                    Debug.Log("ddddd");
                    putFrame[i].gameObject.SetActive(false);
                }             
            }
        }
    }

    //装備変更処理
    void changeEquipSet(EquipmentData eData)
    {
        pData.EquipWeapon = eData;
        
        if (CommonValue.charaType == (int)ConstantList.charactorType.エリス)
        {
            foreach (var equip in possessionData.ericeEquipList)
            {
                //所持リストの装備のON/OFF切り替え
                if(equip.Number == eData.Number)
                {
                    //Debug.Log(equip.Number);
                    equip.setOn = true;
                } else {
                    //Debug.Log(equip.Number);
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

        //STATEの健康
        state = STATE.更新;
    }
}
