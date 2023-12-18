using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public List<WeaponControler> startingWeapons = new List<WeaponControler>();

    public Transform WeaponParentSocket;
    public Transform defaultWeaponPosition;
    public Transform AimingPosition;

    public int activeWeaponIndex { get; private set; }  
    private WeaponControler[] weaponSlots = new WeaponControler[5];
    void Start()
    {
        activeWeaponIndex = -1;
        foreach (WeaponControler startingWeapon in startingWeapons)
        {
            AddWeapon(startingWeapon);
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
    }
    private void SwitchWeapon(int p_weaponIndex)
    {
        if(p_weaponIndex != activeWeaponIndex && p_weaponIndex >= 0)
        {
            weaponSlots[p_weaponIndex].gameObject.SetActive(true);
            activeWeaponIndex = p_weaponIndex;
        }
    }

    private void AddWeapon(WeaponControler p_weaponPrefab)
    {
        WeaponParentSocket.position = defaultWeaponPosition.position;
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] == null)
            {
                WeaponControler weaponClone = Instantiate(p_weaponPrefab, WeaponParentSocket);
                weaponClone.gameObject.SetActive(false);
                weaponSlots[i] = weaponClone;
                return;
            }
        }
    }
}
