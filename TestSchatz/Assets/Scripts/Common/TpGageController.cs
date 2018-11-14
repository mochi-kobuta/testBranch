using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TpGageController : MonoBehaviour {

    Slider gage;
    void Start()
    {
        // スライダーを取得する
        gage = GameObject.Find("gage").GetComponent<Slider>();
    }

    float _hp = 0;
    void Update()
    {
        // HP上昇
        _hp += 0.01f;
        if (_hp > 1)
        {
            // 最大を超えたら0に戻す
            _hp = 0;
        }

        // HPゲージに値を設定
        gage.value = _hp;
    }
}
