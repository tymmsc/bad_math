using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to each button and holds the object 
//holding the Operator Script for that button (hacky but I'm
//not sure how else to do it)

//It also houses the basic button functions like clicking and unclicking,
//Later mouse hovering, etc

public class CheckButtonScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        //turn it some color
    }

    private void OnMouseDown()
    {

        bool n = GameManager.instance.CheckIfSolved();

        if (false == n)
        {
            GetComponent<SpriteRenderer>().color = new Color(.5f, .0f, .0f);
        }
        else
        {
            //if it is successful turn it gray
           GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);

        }
        //Call some other function to do somethng, maybe

    }
    private void OnMouseUp()
    {
        //turn it white again
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }



}
