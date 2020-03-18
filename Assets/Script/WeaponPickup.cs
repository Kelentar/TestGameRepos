using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponPickup : MonoBehaviour
{
    public float coolDown = 2f;
    float counter;
    public GameObject[] weapons;
    public GameObject weaponHere;
    bool caught;
    //HeroScript plus;
    // Start is called before the first frame update
    void Start()
    {
        weaponHere = weapons[Random.Range(0, weapons.Length)];
        GetComponent<SpriteRenderer>().sprite = weaponHere.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (caught)
        {
            counter += Time.deltaTime;
        }
        if(counter >= coolDown)
        {
            caught = false;
            counter = 0;
            weaponHere = weapons[Random.Range(0, weapons.Length)];
            GetComponent<SpriteRenderer>().sprite = weaponHere.GetComponent<SpriteRenderer>().sprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            {
            other.transform.Find("WeaponSlots").GetComponent<WeaponManager>().UpdateWeapon(weaponHere);
            caught = true;
            GetComponent<SpriteRenderer>().sprite = null;

            
        }

    }
}
