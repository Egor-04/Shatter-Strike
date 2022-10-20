using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WeaponType { Rifle, Pistol, Grenade }
public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private float _mouseScrollValue;
    [SerializeField] private WeaponItem[] _weaponsBar;
    private KeyCode[] _inputs = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    [SerializeField] private int _j = 0;

    [System.Serializable]
    public class WeaponItem
    {
        public DropedWeapon DropedWeapon;
        public Weapon HandWeapon;
        public int CurrentType = 0;
        public bool CanChangeOther = false;
        public bool HasItem = false;
        public bool CanDrop;
    }

    private void Update()
    {
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        for (int i = 0; i < _inputs.Length; i++)
        {
            if (Input.GetKeyDown(_inputs[i]))
            {
                DeactivateAll();

                if (_weaponsBar[_j].CanChangeOther)
                {
                    if (_weaponsBar[_j].CurrentType == i)
                    {
                        int sameTypeCount = 0;
                        sameTypeCount++;

                        _weaponsBar[_j].HandWeapon.gameObject.SetActive(true);

                        if (_j < sameTypeCount)
                        {
                            _j++;
                        }
                        else if (_j >= sameTypeCount)
                        {
                            _j = 0;
                        }
                    }
                }
            }
        }
    }

    private void DeactivateAll()
    {
        for (int i = 0; i < _weaponsBar.Length; i++)
        {
            for (int j = 0; j < _weaponsBar.Length; j++)
            {
                _weaponsBar[j].HandWeapon.gameObject.SetActive(false);
            }
        }
    }
}
