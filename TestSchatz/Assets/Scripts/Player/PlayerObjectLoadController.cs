using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.IO;

public class PlayerObjectLoadController : MonoBehaviour {

    private GameObject ericeObject,layraObject;

    void Awake()
    {
        ericeObject = new GameObject();
        layraObject = new GameObject();

        layraObject.name = "layraData";
        string json = File.ReadAllText("Assets\\Data\\Json\\InitializeData\\Player\\layra.json");
        JsonUtility.FromJsonOverwrite(json, layraObject.AddComponent<PlayerBaseController>().pData);
        DontDestroyOnLoad(layraObject);

        ericeObject.name = "ericeData";
        json = File.ReadAllText("Assets\\Data\\Json\\InitializeData\\Player\\erice.json");
        JsonUtility.FromJsonOverwrite(json, ericeObject.AddComponent<PlayerBaseController>().pData);
        DontDestroyOnLoad(ericeObject);
    }

    void Start() {

    }
	
}
