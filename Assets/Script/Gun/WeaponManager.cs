using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject activeWeapon;
    weapon wpn;
    bool canShoot = true;
    public Transform shotDir;
    public float timeShot = 0;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        wpn = activeWeapon.GetComponent<weapon>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        
            if (Input.GetKeyDown(KeyCode.Mouse0) /*&& timeShot <= 0*/)
                {


            
                if (wpn.projectileMode == weapon.Modes.Straight)
                    {
                    
                    GameObject projectile = (GameObject)Instantiate(wpn.projectile, shotDir.position, transform.rotation);
                    
                    //timeShot = startTime;
                    }
                    else if (wpn.projectileMode == weapon.Modes.Trow)
                    {
                    
                }
            //timeShot -= Time.deltaTime;
        }
            
        

        





    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(wpn.coolDown);
        canShoot = true;
    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        activeWeapon = newWeapon;
        wpn = activeWeapon.GetComponent<weapon>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
    }
}
