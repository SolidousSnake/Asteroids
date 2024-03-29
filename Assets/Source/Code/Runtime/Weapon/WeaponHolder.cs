﻿using Source.Code.Runtime.Core.Interfaces;
using TNRD;
using UnityEngine;

namespace Source.Code.Runtime.Weapon
{
    public sealed class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private SerializableInterface<IShipWeapon> _primaryWeapon;
        [SerializeField] private SerializableInterface<IShipWeapon> _secondaryWeapon;

        public void UsePrimaryWeapon()
        {
            _primaryWeapon.Value.Use().Forget();
        }

        public void UseSecondaryWeapon()
        {
            _secondaryWeapon.Value.Use().Forget();
        }
    }
}