using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Item
{
    //アイテムデータ
    [Serializable]
    public class ItemData
    {

        public int Number;         //アイテム番号
        public string Name;        //アイテム名
        public int EffectType;     //効果タイプ
        public int Value1;         //効果値1
        public int Value2;         //効果値2
        public int Value3;         //効果値3
        public int Count;          //個数

        public string Detail;      //詳細
        public string FileName;    //スプライトの元ファイル
        public string SpriteName;  //スプライトから取り出す画像の要素名

    }
}
