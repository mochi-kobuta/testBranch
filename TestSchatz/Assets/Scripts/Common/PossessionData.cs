using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player {

    [Serializable]
    public class PossessionData {
        public int[] WeaList;        //所持武器リスト
        public int[] ArmorList;      //所持防具リスト
        public int Maney;            //所持金
    }
}
