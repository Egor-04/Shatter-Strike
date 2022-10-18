using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private WeaponItem[] _weaponsBar;

    public class WeaponItem
    {
        public DropedWeapon DropedWeapon;
        public Weapon HandWeapon;
        public bool HasItem = false;
        public bool CanDrop;
    }

}
