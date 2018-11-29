using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameConstant { 
    public class ConstantList {

        public const float PLAYER_MOVE_SPEED = 0.025f;
        public const float NPC_MOVE_SPEED = 0.025f;

        //カメラオブジェクトのSizeによって値調整
        public const float INIT_CAMERA_POSITION_Z = -10.0f;

        //カメラオブジェクトのSizeによって値調整
        public const float MAIN_CAMERA_WIDTH_SIZE = 4.8f;
        public const float MAIN_CAMERA_HEIGHT_SIZE = 3.0f;

        //city1でのy方向のプレイヤー位置初期値
        public const float CITY1_PLAYER_INIT_POSITION_Y = 1.5f;

        public enum statusMainContents
        {
            アイテム = 1,
            装備 = 2,
            ステータス = 3,
            特殊 = 4,
        }

        public enum charactorType
        {
            エリス = 1,
            レイラ = 2,
        }

        public enum weaponCategory
        {
            なし = 0,
            棒 = 1,
            剣 = 2,
            刀 = 3,
            古代剣 = 4,

            器具 = 5,
            つえ = 6,
            ロッド = 7,
            古代具 = 8
        }

        public enum itemEffectType
        {
            HP回復系 = 0,
            TP回復系 = 1,
            気絶回復 = 2
        }

        public const int WEAPON_TOTAL_NUM = 4;
        public const int ITEM_TOTAL_NUM = 6;

    }
}
