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
}
