using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    public enum Modes
    { melee, Straight, Follow, Trow }

    public Sprite sprite;
    public GameObject projectile;
    public float projectileSpeed;
    public float coolDown;
  
    public Modes projectileMode;


   // public int currentAmmo = 20;
   // public int allAmmo = 0;
   // public int fullAmmo = 45;

   // [SerializeField]
   // private Text ammoCount;

   //void Start()
   // {
        
   // }

   // void Update()
   // {
   //     ammoCount.text = currentAmmo + "/" + allAmmo;
   // }
   // private void OntriggerEnter2D(Collider2D collision)
   // {
   //     allAmmo += 15;
   //     Destroy(collision.gameObject);
   // }
    

}
