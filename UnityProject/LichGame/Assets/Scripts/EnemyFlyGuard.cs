using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyGuard : MonoBehaviour
{
    public float speed;

    public int distToPatrol;
    public Transform point;

    public Transform Player;
    public float stopingDist;

    public bool goRight = true;

    public bool chill = false;
    public bool angry = false;
    public bool goBack = false;


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < distToPatrol && angry == false)
        {
            chill = true;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, Player.position) < stopingDist)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, Player.position) > stopingDist)
        {
            goBack = true;
            angry = false;
        }

        if (chill)
        {
            Chill();
        }
        else if (angry)
        {
            Angry();
        }
        else if (goBack)
        {
            GoBack();
        }


        //Разворот
        if (goRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(-1, 1);
        }
    }


    public void Chill()
    {
        if (transform.position.x > point.position.x + distToPatrol)
        {
            goRight = false;
        }
        else if (transform.position.x < point.position.x - distToPatrol)
        {
            goRight = true;
        }
    }

    public void Angry()
    {
        //Разворот
        if (transform.position.x > Player.position.x)
        {
            goRight = false;
        }
        else if (transform.position.x < Player.position.x)
        {
            goRight = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, Player.position/* new Vector2(Player.position.x, transform.position.y)*/, speed * Time.deltaTime);
    }

    public void GoBack()
    {
        if (transform.position.x > point.position.x + distToPatrol)
        {
            goRight = false;
        }
        else if (transform.position.x < point.position.x - distToPatrol)
        {
            goRight = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

}
