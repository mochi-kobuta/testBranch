using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Equipment;
using System.IO;
using System;
using GameConstant;
using System.Security.Cryptography;

public class isonDataMaker : MonoBehaviour {

    public Button EquipmenDatatMakeButton;
    EquipmentData equipmentData;

    void Start () {
        EquipmenDatatMakeButton.onClick.AddListener(EquipmenDatatMake);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipmenDatatMake()
    {
        equipmentData = new EquipmentData();

        var Number = GameObject.Find("EquipMentData/makeParam/Number");
        Debug.Log(Number.GetComponent<Text>().text);
        var Name = GameObject.Find("EquipMentData/makeParam/Name");
        var Type = GameObject.Find("EquipMentData/makeParam/Type");
        var Atk = GameObject.Find("EquipMentData/makeParam/Atk");
        var MgDef = GameObject.Find("EquipMentData/makeParam/MgDef");
        var MgAtk = GameObject.Find("EquipMentData/makeParam/MgAtk");
        var Def = GameObject.Find("EquipMentData/makeParam/Def");
        var Luck = GameObject.Find("EquipMentData/makeParam/Luck");
        var Spd = GameObject.Find("EquipMentData/makeParam/Spd");
        var Detail = GameObject.Find("EquipMentData/makeParam/Detail");
        var Endurance = GameObject.Find("EquipMentData/makeParam/Endurance");

        equipmentData.Number = Convert.ToInt32(Number.GetComponent<Text>().text);
        equipmentData.Name = Name.GetComponent<Text>().text;
        equipmentData.Type = Convert.ToInt32(Type.GetComponent<Text>().text);
        equipmentData.Atk = Convert.ToInt32(Atk.GetComponent<Text>().text);
        equipmentData.Def = Convert.ToInt32(Def.GetComponent<Text>().text);
        equipmentData.MgAtk = Convert.ToInt32(MgAtk.GetComponent<Text>().text);
        equipmentData.MgDef = Convert.ToInt32(MgDef.GetComponent<Text>().text);
        equipmentData.Luck = Convert.ToInt32(Luck.GetComponent<Text>().text);
        equipmentData.Endurance = Convert.ToInt32(Endurance.GetComponent<Text>().text);
        equipmentData.Spd = Convert.ToInt32(Spd.GetComponent<Text>().text);
        equipmentData.Detail = Detail.GetComponent<Text>().text;

        AesManaged aes = new AesManaged();
        string json = JsonUtility.ToJson(equipmentData);
        if(equipmentData.Type == (int)ConstantList.charactorType.エリス)
            File.WriteAllText("Assets\\Resources\\Data\\Json\\Equipment\\erice\\" + equipmentData.Number + ".json", json);
        else if (equipmentData.Type == (int)ConstantList.charactorType.レイラ)
            File.WriteAllText("Assets\\Resources\\Data\\Json\\Equipment\\layra\\" + equipmentData.Number + ".json", json);
    }
}
