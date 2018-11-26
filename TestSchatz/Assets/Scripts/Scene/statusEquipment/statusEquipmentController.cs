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

    void Start () {
        var gOb = gameObject.GetComponent<PlayerObjectLoadController>();
        gOb.initLoad();
        gOb.PossessionLoad();

        //所持データ
        var possessionData = GameObject.Find("possessionData").GetComponent<PossessionBaseController>().possessionData;

        if (CommonValue.charaType == (int)ConstantList.charactorType.エリス)
        {
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_1");
            pData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
            paramSet(ConstantList.charactorType.エリス, pData);
        }
        else if (CommonValue.charaType == (int)ConstantList.charactorType.レイラ)
        {
            equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Parts/charactorProfile", "charactorProfile_0");
            pData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;
            paramSet(ConstantList.charactorType.レイラ, pData);
        }

    }
	
	void Update () {
		
	}


    void paramSet(ConstantList.charactorType type, PlayerData pData)
    {
        charaName.text = pData.Name;
        weaponName.text = "武:" + pData.EquipWeapon.Name;
        armorName.text = "防:" + pData.EquipArmor.Name;
        atk.text = "攻撃力:" + (pData.EquipWeapon.Atk + pData.Atk).ToString();
        def.text = "防御力:" + (pData.EquipWeapon.Def + pData.Def).ToString();
        mAtk.text = "魔法攻撃力:" + (pData.EquipWeapon.MgAtk + pData.MgAtk).ToString();
        mDef.text = "魔法防御力:" + (pData.EquipWeapon.MgDef + pData.MgDef).ToString();
        luck.text = "運:" + (pData.EquipWeapon.Luck + pData.Luck).ToString();
        speed.text = "早さ:" + (pData.EquipWeapon.Spd + pData.Spd).ToString();
        detail.text = pData.EquipWeapon.Detail;

        if(type == ConstantList.charactorType.レイラ)
        {
            //初期装備違う画像なのでめんどくさいけど分岐処理
            if(pData.EquipWeapon.Number == ConstantList.BEGNING_WEAPON_LAYLA)
            {
                equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Weapon/bigining_weapon", "bigining_weapon_layra");
            }
        } else if(type == ConstantList.charactorType.エリス) {
            //初期装備違う画像なのでめんどくさいけど分岐処理
            if (pData.EquipWeapon.Number == ConstantList.BEGNING_WEAPON_ERICE)
            {
                equipImage.sprite = gameObject.GetComponent<multipleSliceImageLoadController>().ReadMutipleImageFile("Texture/Weapon/bigining_weapon", "bigining_weapon_erice");
            }
        }
    }
}
