using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Equipment;
using Item;

namespace Player {

    [Serializable]
    public class PossessionData {
        public EquipmentData[] layraEquipList;        //所持武器/防具リスト
        public EquipmentData[] ericeEquipList;        //所持武器/防具リスト
        public ItemData[] ItemList;                   //所持アイテム
        public int Maney;                             //所持金
    }
}