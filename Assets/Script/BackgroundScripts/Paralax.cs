using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float Lenght, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        Lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + Lenght) startpos += Lenght;
        else if (temp < startpos - Lenght) startpos -= Lenght;
    }
}
