using System.Collections.Generic;
using UnityEngine;
using System;
using DitzelGames.FastIK;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private float _mouseScrollValue;
    [SerializeField] private FastIKFabric _leftHand, _rightHand;
    [SerializeField] private WeaponItem[] _weaponsBar;
    private KeyCode[] _inputs = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    [SerializeField] private int _j = 0;

    [System.Serializable]
    public class WeaponItem
    {
        public DropedWeapon DropedWeapon;
        public Weapon HandWeapon;
        public Transform LeftHandTargetIK, RightHandTargetIK;
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
                for (int j = 0; j < _weaponsBar.Length; j++)
                {
                    if (_weaponsBar[j].CanChangeOther)
                    {
                        if (_weaponsBar[j].CurrentType == (i+1))
                        {
                            DeactivateAll();
                            int sameTypeCount = 0;
                            sameTypeCount++;

                            _weaponsBar[_j].HandWeapon.gameObject.SetActive(true);
                            _leftHand.Target = _weaponsBar[_j].LeftHandTargetIK;
                            _rightHand.Target = _weaponsBar[_j].RightHandTargetIK;

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
                    else
                    {
                        DeactivateAll();
                        if ((i + 1) == _weaponsBar[j].CurrentType)
                        {
                            _weaponsBar[j].HandWeapon.gameObject.SetActive(true);
                            _leftHand.Target = _weaponsBar[j].LeftHandTargetIK;
                            _rightHand.Target = _weaponsBar[j].RightHandTargetIK;
                            return;
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

    private int FindNumbers(string text)
    {
        int index = 0;

        for (int i = 0; i < text.Length; i++)
        {
            index = Convert.ToInt32(text[i]);
        }

        return index;
    }
}
