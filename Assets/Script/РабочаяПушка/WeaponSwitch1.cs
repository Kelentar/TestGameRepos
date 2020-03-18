using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch1 : MonoBehaviour
{
    public int weaponSwitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentWeapon = weaponSwitch;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitch = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            weaponSwitch = 1;
        }
        if(currentWeapon != weaponSwitch)
        {
            SelectWEapon();
        }
    }

    void SelectWEapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == weaponSwitch)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
