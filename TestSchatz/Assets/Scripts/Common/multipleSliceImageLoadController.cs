using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class multipleSliceImageLoadController : MonoBehaviour {

    // 読み込み関数
    public Object[] ReadMutipleImageFile(string imageName)
    {

        return AssetDatabase.LoadAllAssetsAtPath(imageName);
    }
}
