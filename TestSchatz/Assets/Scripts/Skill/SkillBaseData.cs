using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Skill
{
    //スキル/リミット技の共通データ
    [Serializable]
    public class SkillBaseData
    {
        public int Number;         //番号
        public string Name;        //名称
        public int Type;           //キャラタイプ
        public int Value;          //効果値
        /*
        public int Atk;            //攻撃力
        public int Def;            //防御力
        public int MgAtk;          //魔法攻撃力
        public int MgDef;          //魔法防御力
        public int Spd;            //早さ
        public int Luck;           //運
        */
        public string Detail;      //詳細
    }
}
