using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System; // UnityJsonを使う場合に必要
using System.IO; // ファイル書き込みに必要

public class city1Controller : MonoBehaviour {

    private PlayerData ericeData, layraData;
    

    void Start () {
        gameObject.GetComponent<PlayerObjectLoadController>().initLoad();

        ericeData = GameObject.Find("ericeData").GetComponent<PlayerBaseController>().pData;
        layraData = GameObject.Find("layraData").GetComponent<PlayerBaseController>().pData;

        //Debug.Log(layraData.pData.Name);
    }
	
	void Update () {
        //セーブ
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("SAVE");
            Debug.Log(Application.persistentDataPath);
            ericeData.Atk = 999;
            layraData.Atk = 900;

            // JSONにシリアライズ
            var json = JsonUtility.ToJson(ericeData);
            // Assetsフォルダに保存する
            /*
            var path = Application.dataPath + "/" + "Resources/Data/Json/InitializeData/Player/layra.json";
            var writer = new StreamWriter(path, false); // 上書き
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
            */
            string path = Application.persistentDataPath + "/" + "SaveData/Player";
            DirectoryUtils.SafeCreateDirectory(path);

            File.WriteAllText(path + "/Test2.json", json);
            
        }
    }
}
