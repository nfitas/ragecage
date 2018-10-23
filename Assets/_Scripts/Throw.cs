﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour {

    public float strength;
    public Boolean firstTableTouch = false;
    public Boolean validTableTouch = false;
    public Boolean successPlay = false;
    public Slider strengthSlider;
    public int maxStrengthValue = 10;
    public int minStrengthValue = 0;


    private Rigidbody ball;

    private Vector3 initialPos;
	// Use this for initialization
	void Start () {

        firstTableTouch = false;
        validTableTouch = false;
        successPlay = false;

        initialPos = transform.position;

        strength = 0;
        ball = GetComponent<Rigidbody>();

        //stop ball in the air during initial play
        ball.isKinematic = true;

        UiInit();
	}

    //Initializes UI
    void UiInit () {
        strengthSlider.maxValue = maxStrengthValue;
        strengthSlider.minValue = minStrengthValue;
    }

    // Update is called once per frame
    void Update()
    {


        decreaseStrenght();
        increaseStrenght();
        strengthSlider.value = strength;

        launchBall();

        reset();
    }

    void reset()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            firstTableTouch = false;
            validTableTouch = false;
            successPlay = false;
            
            transform.position = initialPos;
            ball.isKinematic = true;

        }
    }

    void decreaseStrenght(){

        //increase strenght
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (strength > minStrengthValue)
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
            if (strength < maxStrengthValue){
                strength++;
                Debug.Log("Up Arrow key was pressed.");
            }
        }
    }

    void launchBall()
    {
        //launch ball
        if (Input.GetKeyDown(KeyCode.Return))
        {

            Vector3 movement = new Vector3(-1.0f, 0.0f, -1.0f);

            ball.isKinematic = false;
            ball.AddForce(100 * strength * movement);

        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (successPlay){
            return;
        }
            

        if (col.gameObject.name == "Table")
        {

            if (firstTableTouch == false)
            {
                firstTableTouch = true;
                validTableTouch = true;
            }
            else
            {
                validTableTouch = false;
            }
        }

        if (col.gameObject.name == "CupBase")
        {
            if(validTableTouch){

                successPlay = true;
            }

        }
    }
}
