using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    public int strength;
    private Rigidbody ball;

    private Vector3 initialPos;
	// Use this for initialization
	void Start () {
        initialPos = transform.position;


        strength = 0;
        ball = GetComponent<Rigidbody>();

        //stop ball in the air during initial play
        ball.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {


        decreaseStrenght();

        increaseStrenght();

        launchBall();

        reset();
	}

    void reset()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            transform.position = initialPos;
            ball.isKinematic = true;

        }
    }

    void decreaseStrenght(){

        //increase strenght
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (strength != 0)
            {
                strength--;
                Debug.Log("Down Arrow key was pressed.");
            }
        }
    }

    void increaseStrenght()
    {

        //decrease strenght
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            strength++;
            Debug.Log("Up Arrow key was pressed.");

        }
    }

    void launchBall()
    {
        //launch ball
        if (Input.GetKeyDown(KeyCode.Return))
        {

            Vector2 movement = new Vector2(-1.0f, 0.0f);

            ball.isKinematic = false;
            ball.AddForce(100 * strength * movement);

        }
    }
}
