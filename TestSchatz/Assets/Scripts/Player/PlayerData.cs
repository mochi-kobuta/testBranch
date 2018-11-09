using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player {

    [Serializable]
    public class PlayerData {
        public string Name;        //キャラ名
        public int CharactorType;  //キャラタイプ
        public int Level;          //レベル
        public int Hp;             //HP
        public int MaxHp;          //MAXHP
        public int Tp;             //特技発動ポイント
        public int MaxTp;          //最大特技発動ポイント
        public int Sg;             //必殺技発動ゲージ

        public int Atk;            //攻撃力
        public int Def;            //防御力
        public int MgAtk;          //魔法攻撃力
        public int MgDef;          //魔法防御力
        public int Spd;            //早さ
        public int Exp;            //総獲得経験値
        public int Luck;            //運

        public int EquipWeapon;    //装備中武器
        public int EquipArmor;     //装備中防具

        public int[] SkillList;    //特技/魔法のリスト
        public int[] LimitSkill;     //必殺技

    }
}
