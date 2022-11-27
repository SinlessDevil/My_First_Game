using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    public float speed;

    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;
    

    Transform player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    public bool FaceRight = true;

    [SerializeField] private AudioSource enemifootstep;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemifootstep = GetComponent<AudioSource>();
    } 


    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) 
        {
            goBack = true;
            angry = false;         
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();          
        }
        else if (goBack == true)
        {
            GoBack();     
        }
    }

    void Chill()
    {
        if ((transform.position.x > point.position.x + positionOfPatrol) && (!FaceRight))
        {
            moveingRight = false;
            Flip();
        }
        else if ((transform.position.x < point.position.x - positionOfPatrol) && (FaceRight))
        {
            moveingRight = true;
            Flip();
        }

        if (moveingRight)
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

    void Flip()
    {
        FaceRight = !FaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void Enemifootstep()
    {
        enemifootstep.Play();
    }

}


