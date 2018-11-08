using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.IO;

public class PlayerObjectLoadController : MonoBehaviour {

    private GameObject ericeObject,layraObject;
    private TextAsset profData;
    private PlayerBaseController baseCtr;
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
    void Start() {

    }

    public void initLoad() {
        ericeObject = new GameObject();
        layraObject = new GameObject();

        layraObject.name = "layraData";
        //string json = File.ReadAllText(Application.dataPath + "/Resources//Data/Json/InitializeData/Player/layra.json");
        profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/layra");
        JsonUtility.FromJsonOverwrite(profData.text, layraObject.AddComponent<PlayerBaseController>().pData);
        DontDestroyOnLoad(layraObject);

        ericeObject.name = "ericeData";
        //json = File.ReadAllText(Application.dataPath + "/Resources/Data/Json/InitializeData/Player/erice.json");
        profData = Resources.Load<TextAsset>("Data/Json/InitializeData/Player/erice");
        JsonUtility.FromJsonOverwrite(profData.text, ericeObject.AddComponent<PlayerBaseController>().pData);
        DontDestroyOnLoad(ericeObject);
    }

	
}
