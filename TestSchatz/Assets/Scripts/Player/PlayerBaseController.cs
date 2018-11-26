using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Equipment;

public class PlayerBaseController : MonoBehaviour {

    public PlayerData pData = new PlayerData();

    void Awake () {
        pData.EquipWeapon = new EquipmentData();
        pData.EquipArmor = new EquipmentData();
    }

    void Start () {
        



    }

    void Update () {
		
	}
}
