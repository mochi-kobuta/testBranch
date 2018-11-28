using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Equipment;
using System.IO;
using System;
using GameConstant;
using System.Security.Cryptography;
using Player;
using Item;

public class isonDataMaker : MonoBehaviour
{

    public Button EquipmenDatatMakeButton, PossesionDataMakeButton, ItemDataMakeButton;
    private EquipmentData equipmentData;
    private ItemData ItemData;

    private TextAsset textAsset;
    private PossessionData possessionData;

    void Start()
    {
        EquipmenDatatMakeButton.onClick.AddListener(EquipmenDataMake);
        PossesionDataMakeButton.onClick.AddListener(PossesionDataMake);
        ItemDataMakeButton.onClick.AddListener(ItemDataMake);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EquipmenDataMake()
    {
        equipmentData = new EquipmentData();

        var Number = GameObject.Find("EquipMentData/makeParam/Number");
        var Name = GameObject.Find("EquipMentData/makeParam/Name");
        var Type = GameObject.Find("EquipMentData/makeParam/Type");
        var Atk = GameObject.Find("EquipMentData/makeParam/Atk");
        var MgDef = GameObject.Find("EquipMentData/makeParam/MgDef");
        var MgAtk = GameObject.Find("EquipMentData/makeParam/MgAtk");
        var Def = GameObject.Find("EquipMentData/makeParam/Def");
        var Luck = GameObject.Find("EquipMentData/makeParam/Luck");
        var Spd = GameObject.Find("EquipMentData/makeParam/Spd");
        var Detail = GameObject.Find("EquipMentData/makeParam/Detail");
        var Category = GameObject.Find("EquipMentData/makeParam/Category");

        equipmentData.Number = Convert.ToInt32(Number.GetComponent<Text>().text);
        equipmentData.Name = Name.GetComponent<Text>().text;
        equipmentData.Type = Convert.ToInt32(Type.GetComponent<Text>().text);
        equipmentData.Atk = Convert.ToInt32(Atk.GetComponent<Text>().text);
        equipmentData.Def = Convert.ToInt32(Def.GetComponent<Text>().text);
        equipmentData.MgAtk = Convert.ToInt32(MgAtk.GetComponent<Text>().text);
        equipmentData.MgDef = Convert.ToInt32(MgDef.GetComponent<Text>().text);
        equipmentData.Luck = Convert.ToInt32(Luck.GetComponent<Text>().text);
        equipmentData.Category = Convert.ToInt32(Category.GetComponent<Text>().text);
        equipmentData.Spd = Convert.ToInt32(Spd.GetComponent<Text>().text);
        equipmentData.Detail = Detail.GetComponent<Text>().text;

        AesManaged aes = new AesManaged();
        string json = JsonUtility.ToJson(equipmentData);
        if (equipmentData.Type == (int)ConstantList.charactorType.エリス)
            File.WriteAllText("Assets\\Resources\\Data\\Json\\Equipment\\erice\\" + equipmentData.Number + ".json", json);
        else if (equipmentData.Type == (int)ConstantList.charactorType.レイラ)
            File.WriteAllText("Assets\\Resources\\Data\\Json\\Equipment\\layra\\" + equipmentData.Number + ".json", json);
    }

    public void ItemDataMake()
    {
        ItemData = new ItemData();

        var Number = GameObject.Find("ItemData/makeParam/Number");
        var Name = GameObject.Find("ItemData/makeParam/Name");
        var EffectType = GameObject.Find("ItemData/makeParam/EffectType");
        var Value1 = GameObject.Find("ItemData/makeParam/Value1");
        var Value2 = GameObject.Find("ItemData/makeParam/Value2");
        var Value3 = GameObject.Find("ItemData/makeParam/Value3");
        var Count = GameObject.Find("ItemData/makeParam/Count");
        var FileName = GameObject.Find("ItemData/makeParam/FileName");
        var SpriteName = GameObject.Find("ItemData/makeParam/SpriteName");
        var Detail = GameObject.Find("ItemData/makeParam/Detail");

        ItemData.Number = Convert.ToInt32(Number.GetComponent<Text>().text);
        ItemData.Name = Name.GetComponent<Text>().text;
        ItemData.EffectType = Convert.ToInt32(EffectType.GetComponent<Text>().text);
        ItemData.Value1 = Convert.ToInt32(Value1.GetComponent<Text>().text);
        ItemData.Value2 = Convert.ToInt32(Value2.GetComponent<Text>().text);
        ItemData.Value3 = Convert.ToInt32(Value3.GetComponent<Text>().text);
        ItemData.Count = Convert.ToInt32(Count.GetComponent<Text>().text);
        ItemData.FileName = FileName.GetComponent<Text>().text;
        ItemData.SpriteName = SpriteName.GetComponent<Text>().text;
        ItemData.Detail = Detail.GetComponent<Text>().text;

        AesManaged aes = new AesManaged();
        string json = JsonUtility.ToJson(ItemData);
        File.WriteAllText("Assets\\Resources\\Data\\Json\\Item\\" + ItemData.Number + ".json", json);
    }

    public void PossesionDataMake()
    {
        
        possessionData = new PossessionData();
        possessionData.layraEquipList = new EquipmentData[ConstantList.WEAPON_TOTAL_NUM];
        possessionData.ericeEquipList = new EquipmentData[ConstantList.WEAPON_TOTAL_NUM];
        possessionData.ItemList = new ItemData[ConstantList.ITEM_TOTAL_NUM];

        var maney = GameObject.Find("PossesionData/maney");
        possessionData.Maney = Convert.ToInt32(maney.GetComponent<Text>().text);

        for(int i = 0; i < ConstantList.WEAPON_TOTAL_NUM; i++)
        {
            equipmentData = new EquipmentData();
            //jsonファイルからデシリアイズして各EquipmentDataのデータを登録するためにまたjsonに戻す
            textAsset = Resources.Load<TextAsset>("Data/Json/Equipment/layra/" + i);
            JsonUtility.FromJsonOverwrite(textAsset.text, equipmentData);
            possessionData.layraEquipList[i] = equipmentData;
        }

        for (int i = 0; i < ConstantList.WEAPON_TOTAL_NUM; i++)
        {
            equipmentData = new EquipmentData();
            //jsonファイルからデシリアイズして各EquipmentDataのデータを登録するためにまたjsonに戻す
            textAsset = Resources.Load<TextAsset>("Data/Json/Equipment/erice/" + i);
            JsonUtility.FromJsonOverwrite(textAsset.text, equipmentData);
            possessionData.ericeEquipList[i] = equipmentData;
        }

        for (int i = 0; i < ConstantList.ITEM_TOTAL_NUM; i++)
        {
            ItemData = new ItemData();
            //jsonファイルからデシリアイズして各EquipmentDataのデータを登録するためにまたjsonに戻す
            textAsset = Resources.Load<TextAsset>("Data/Json/Item/" + i);
            JsonUtility.FromJsonOverwrite(textAsset.text, ItemData);
            possessionData.ItemList[i] = ItemData;
        }

        string json = JsonUtility.ToJson(possessionData);
        File.WriteAllText("Assets\\Resources\\Data\\Json\\InitializeData\\Possession\\possession.json", json);


    }
}
