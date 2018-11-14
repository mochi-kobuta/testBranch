using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.IO;

public class city1Controller : MonoBehaviour {

    private PlayerData ericeData, layraData;
    

    void Start () {
        gameObject.GetComponent<PlayerObjectLoadController>().initLoad();

        ericeData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
        layraData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;
    }
	
	void Update () {
        //セーブ
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            Debug.Log("SAVE");
            

            // JSONにシリアライズ
            //エリスのデータ保存
            var json = JsonUtility.ToJson(ericeData);
            string path = Application.persistentDataPath + "/" + "SaveData/Player";
            DirectoryUtils.SafeCreateDirectory(path);
            File.WriteAllText(path + "/" + ericeData.Name + ".json", json);

            //レイラのデータ保存
            json = JsonUtility.ToJson(layraData);
            path = Application.persistentDataPath + "/" + "SaveData/Player";
            DirectoryUtils.SafeCreateDirectory(path);

            File.WriteAllText(path + "/" + layraData.Name + ".json", json);

            Debug.Log("SAVE_END");
        }
    }
}
