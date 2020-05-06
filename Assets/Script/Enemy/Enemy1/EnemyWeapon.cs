using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    //[SerializeField] Transform spawPoint;
    public int damage1;
    public PlayerHealth player;
    public Animator anim;
    // Start is called before the first frame update

    //private void Start()
    //{
    //    enemy = GetComponentInParent<PlayerHealth>();
    //}
    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.transform.CompareTag("Player"))
    //        enemy.TakeDamage(damage);

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        player = hitInfo.GetComponent<PlayerHealth>();
        if (player.transform.CompareTag("Player"))
        {
            player.TakeDamage(damage1);
        }

    }

    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("DeathEffect"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
