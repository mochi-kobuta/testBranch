using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.IO;

public class PlayerObjectController : MonoBehaviour {

    public string objectName;
    private PlayerData pData;

	void Start () {
        pData = new PlayerData();

        string json = File.ReadAllText(string.Format("Assets\\Data\\Json\\InitializeData\\Player\\{0}.json", objectName));
        JsonUtility.FromJsonOverwrite(json, pData);
        DontDestroyOnLoad(this);
    }
	
}
