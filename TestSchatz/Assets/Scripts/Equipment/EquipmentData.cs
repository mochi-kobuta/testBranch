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

        public int Endurance;     //耐久度
        public string Detail;      //詳細
        //public int Weight;       //重さ
    }
}
