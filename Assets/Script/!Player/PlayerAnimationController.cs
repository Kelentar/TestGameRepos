using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    internal static object rb;
    Animator anim;

    PlayerWeaponManager pw;

    int weaponID = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pw = GetComponent<PlayerWeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponAnimation(pw.curWeaponType);
    }

    void WeaponAnimation(string weapon)
    {
        switch(weapon)
        {
            case "Null":
                weaponID = 0;
                anim.SetInteger("weapon", weaponID);
                break;
            case "item1":
                weaponID = 1;
                anim.SetInteger("weapon", weaponID);
                break;
            case "item2":
                weaponID = 2;
                anim.SetInteger("weapon", weaponID);
                break;
        }
    }
}
