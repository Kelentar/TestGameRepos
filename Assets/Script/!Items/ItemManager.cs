﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item item;
    PlayerWeaponManager pw;
    void Start()
    {
        pw = FindObjectOfType<PlayerWeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            col.GetComponent<PlayerWeaponManager>().inTrigger = true;
            if(Input.GetMouseButtonDown(1))
            {
                StartCoroutine("wait");
            }
        }
    }

    private void OntriggerExit2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            col.GetComponent<PlayerWeaponManager>().inTrigger = false;
        }
    }
    IEnumerator wait()
    {
        if(pw.curWeaponType != "Null")
        {
            pw.dropWeapon(pw.curWeaponType);
        }
        yield return new WaitForSeconds(0.05f);
        pw.curWeaponType = item.weapontype.ToString();
        Destroy(gameObject);
    }
}
