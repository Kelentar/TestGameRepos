using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public float speed;

    public int positionOfPatrol;
    public Transform point;

    bool moveRight;

    Transform player;
    public float stoppingOfDistence;

    bool chill = false;
    bool angry = false;
    bool goback = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if(Vector2.Distance(transform.position, player.position) < stoppingOfDistence)
        {
            angry = true;
            chill = false;
            goback = false;
        }
        if(Vector2.Distance(transform.position, player.position) > stoppingOfDistence)
        {
            goback = true;
            angry = false;
        }

        if(chill == true)
        {
            Chill();
        }
        else if(angry == true)
        {
            Angry();
            speed = 5;
        }
        else if(goback == true)
        {
            GoBack();
        }

    }

    void Chill()
    {
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            moveRight = false;
        }
        else if(transform.position.x < point.position.x - positionOfPatrol)
        {
            moveRight = true;
        }

        if(moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
