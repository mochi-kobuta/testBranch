using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class multipleSliceImageLoadController : MonoBehaviour {

    // 読み込み関数
    public Sprite ReadMutipleImageFile(string fileName, string spriteName)
    {
        // Resoucesから対象のテクスチャから生成したスプライト一覧を取得
        Debug.Log(fileName);
        Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);
        Debug.Log(sprites[0]);
        // 対象のスプライトを取得
        return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
        
    }
}
