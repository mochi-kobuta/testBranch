using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.IO;
using UniLibs;

public class city1Controller : MonoBehaviour {

    private PlayerData ericeData, layraData;

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
            json = aesCrypter.Encode(json);
            string path = Application.persistentDataPath + "/" + "SaveData/Player";
            DirectoryUtils.SafeCreateDirectory(path);
            File.WriteAllText(path + "/" + ericeData.Name + ".json", json);

            //レイラのデータ保存
            json = JsonUtility.ToJson(layraData);
            json = aesCrypter.Encode(json);
            path = Application.persistentDataPath + "/" + "SaveData/Player";
            DirectoryUtils.SafeCreateDirectory(path);

            File.WriteAllText(path + "/" + layraData.Name + ".json", json);

            Debug.Log("SAVE_END");
        }
    }


    /// <summary>
    /// AES暗号の復号化
    /// </summary>
    public string AESDecode(string enctext)
    {
        return aesCrypter.Decode(enctext);

    }

    /*
     string json = null;
      if (!string.IsNullOrEmpty(webRequest.downloadHandler.text)) {
        try {
          json = webRequest.downloadHandler.text;
          if (IsEncrypt) {
            json = APIManager.AESDecode(json);
          }
        } catch {
          status = APIStatus.DecodeError;
          var error = new APIError((int)webRequest.responseCode, "Decode Failure");
          m_StatusCode = status;
          m_LastError = error;
          return;
        }
      }
     */
}
