using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer1 : MonoBehaviour
{

    [SerializeField] Transform spawPoint;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.position = spawPoint.position;
        }
           


    }

}
