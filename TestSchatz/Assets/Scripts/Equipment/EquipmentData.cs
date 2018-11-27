using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Equipment
{
    //武器/防具のデータ
    [Serializable]
    public class EquipmentData
    {
        public int Number;         //装備番号
        public string Name;        //装備名
        public int Type;           //キャラタイプ（誰が装備できるか）
        public int Atk;            //攻撃力
        public int Def;            //防御力
        public int MgAtk;          //魔法攻撃力
        public int MgDef;          //魔法防御力
        public int Spd;            //早さ
        public int Luck;           //運

        public int Category;     //武器カテゴリ
        public string Detail;      //詳細
        public bool setOn;         //装備しているかどうか
        public string fileName;    //スプライトの元ファイル
        public string spriteName;  //スプライトから取り出す画像の要素名
    }
}
