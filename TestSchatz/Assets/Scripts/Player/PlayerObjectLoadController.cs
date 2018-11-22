using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.IO;
using UniLibs;

public class PlayerObjectLoadController : MonoBehaviour
{

    private GameObject ericeObject, layraObject;
    private TextAsset profData;
    private PlayerBaseController baseCtr;


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
    /*
    void Awake()
    {
        
        ericeObject = new GameObject();
        layraObject = new GameObject();
        profData = new TextAsset();

        layraObject.name = "layraData";
        //string json = File.ReadAllText(Application.dataPath + "/Resources//Data/Json/InitializeData/Player/layra.json");
        //string json;
        profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/layraJson");
        JsonUtility.FromJsonOverwrite(profData.text, layraObject.AddComponent<PlayerBaseController>().pData);
        DontDestroyOnLoad(layraObject);

        ericeObject.name = "ericeData";
        //json = File.ReadAllText(Application.dataPath + "/Resources/Data/Json/InitializeData/Player/erice.json");
        profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/ericeJson");
        JsonUtility.FromJsonOverwrite(profData.text, ericeObject.AddComponent<PlayerBaseController>().pData);
        DontDestroyOnLoad(ericeObject);
        
    }
    */
    void Start()
    {

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

            string basePath = Application.persistentDataPath + "/" + "SaveData/Player";
            if(Directory.Exists(basePath))
            {
                profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/layra");
                JsonUtility.FromJsonOverwrite(profData.text, layraObject.AddComponent<PlayerBaseController>().pData);

                profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/erice");
                JsonUtility.FromJsonOverwrite(profData.text, ericeObject.AddComponent<PlayerBaseController>().pData);
            } else {
                string json = File.ReadAllText(Application.persistentDataPath + "/" + "SaveData/Player/layra.json");
                json = aesCrypter.Decode(json);
                JsonUtility.FromJsonOverwrite(json, layraObject.AddComponent<PlayerBaseController>().pData);

                json = File.ReadAllText(Application.persistentDataPath + "/" + "SaveData/Player/erice.json");
                json = aesCrypter.Decode(json);
                JsonUtility.FromJsonOverwrite(json, ericeObject.AddComponent<PlayerBaseController>().pData);
            }
            
            DontDestroyOnLoad(layraObject);
            DontDestroyOnLoad(ericeObject);            
        }
    }


}

