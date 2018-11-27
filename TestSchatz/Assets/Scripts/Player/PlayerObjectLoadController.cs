using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.IO;
using UniLibs;
using Equipment;

public class PlayerObjectLoadController : MonoBehaviour
{

    private GameObject ericeObject, layraObject, possessionObject;
    private TextAsset profData;
    private PlayerBaseController baseCtr;
    State state;

    private enum State
    {
        キャラデータ準備 = 0,
        所持データ準備 = 1,
        終了  = 2
    }

    private const string AESKey = "HqmQHAXim7C7HqgI";
    private const string AESDefaultIV = "DGBTBWYPQO8czeHv";

    //AES暗号化インスタンス
    public const int AESBlockSize = 16;
    private AESCrypter m_AESCrypter = null;
    private AESCrypter aesCrypter
    {
        get
        {
            if (m_AESCrypter == null)
            {
                m_AESCrypter = new AESCrypter(AESKey, AESDefaultIV);
            }
            return m_AESCrypter;
        }
    }
    

    void Start()
    {
        state = 0;
    }

    public void initLoad()
    {
        ericeObject = GameObject.Find("ericeData");
        layraObject = GameObject.Find("layraData");
        if (ericeObject == null && layraObject == null)
        {
            ericeObject = new GameObject();
            layraObject = new GameObject();
            

            layraObject.name = "layraData";
            ericeObject.name = "ericeData";

            this.preparationCaractor();
        }
    }

    public void PossessionLoad()
    {
        if(possessionObject == null)
        {
            possessionObject = new GameObject();
            possessionObject.name = "possessionData";
            this.preparationPossession();
        }
    }


    void preparationCaractor()
    {
        string basePath = Application.persistentDataPath + "/" + "SaveData/Player";
        if (Directory.Exists(basePath))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/" + "SaveData/Player/layra.json");
            json = aesCrypter.Decode(json);
            JsonUtility.FromJsonOverwrite(json, layraObject.AddComponent<PlayerBaseController>().pData);

            json = File.ReadAllText(Application.persistentDataPath + "/" + "SaveData/Player/erice.json");
            json = aesCrypter.Decode(json);
            JsonUtility.FromJsonOverwrite(json, ericeObject.AddComponent<PlayerBaseController>().pData);

        }
        else
        {
            //======レイラ======
            //初期データ
            layraObject.AddComponent<PlayerBaseController>();
            layraObject.GetComponent<PlayerBaseController>().pData = new PlayerData();
            layraObject.GetComponent<PlayerBaseController>().pData.EquipWeapon = new EquipmentData();
            layraObject.GetComponent<PlayerBaseController>().pData.EquipArmor = new EquipmentData();
            profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/layra");
            JsonUtility.FromJsonOverwrite(profData.text, layraObject.GetComponent<PlayerBaseController>().pData);
            profData = Resources.Load<TextAsset>("Data/Json/Equipment/layra/0");
            JsonUtility.FromJsonOverwrite(profData.text, layraObject.GetComponent<PlayerBaseController>().pData.EquipWeapon);


            //======エリス======
            //初期装備データ
            ericeObject.AddComponent<PlayerBaseController>();
            ericeObject.GetComponent<PlayerBaseController>().pData = new PlayerData();
            ericeObject.GetComponent<PlayerBaseController>().pData.EquipWeapon = new EquipmentData();
            ericeObject.GetComponent<PlayerBaseController>().pData.EquipArmor = new EquipmentData();
            profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/erice");
            JsonUtility.FromJsonOverwrite(profData.text, ericeObject.GetComponent<PlayerBaseController>().pData);
            profData = Resources.Load<TextAsset>("Data/Json/Equipment/erice/0");
            JsonUtility.FromJsonOverwrite(profData.text, ericeObject.GetComponent<PlayerBaseController>().pData.EquipWeapon);

        }

        DontDestroyOnLoad(layraObject);
        DontDestroyOnLoad(ericeObject);
    }


    void preparationPossession()
    {
        string basePath = Application.persistentDataPath + "/" + "SaveData/Possession";
        string json;
        if (Directory.Exists(basePath))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/" + "SaveData/Possession/possession.json");
            //json = aesCrypter.Decode(json);
            JsonUtility.FromJsonOverwrite(json, possessionObject.AddComponent<PossessionBaseController>().possessionData);
        }
        else
        {
            profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Possession/possession");
            JsonUtility.FromJsonOverwrite(profData.text, possessionObject.AddComponent<PossessionBaseController>().possessionData);
        }
        Debug.Log(possessionObject);
        DontDestroyOnLoad(possessionObject);
    }
}

