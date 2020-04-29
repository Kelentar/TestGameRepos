using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float Lenght, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        Lenght = GetComponent<SpriteRenderer>().bounds,size.x;
    }

    void Update()
    {
        float
    }
}
