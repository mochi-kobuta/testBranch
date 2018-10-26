using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameConstant { 
    public class ConstantList : MonoBehaviour {

        public const float PLAYER_MOVE_SPEED = 0.025f;

        //カメラオブジェクトのSizeによって値調整
        public const float INIT_CAMERA_POSITION_Z = -10.0f;

        //カメラオブジェクトのSizeによって値調整
        public const float MAIN_CAMERA_WIDTH_SIZE = 4.8f;
        public const float MAIN_CAMERA_HEIGHT_SIZE = 3.0f;

        //city1でのy方向のプレイヤー位置初期値
        public const float CITY1_PLAYER_INIT_POSITION_Y = 1.5f;
  }
}
