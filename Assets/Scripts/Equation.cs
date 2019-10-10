using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This equation class holds the strings making up the two sides of an equation.
//It updates all the time so that the visible text is always correct.

public class Equation : MonoBehaviour
{

    public string leftSide;
    public string rightSide;

    // Use this for initialization
    void Start()
    {

        // GetComponent<Text>().text = this.toString();
    }
    public void setEquation(string leftSide, string rightSide)
    {
        this.leftSide = leftSide;
        this.rightSide = rightSide;
        GetComponent<EquationGameObject>().setEquation(this);
    }
    /*public void setSides(string leftSide, string rightSide)
    {
        this.leftSide = leftSide;
        this.rightSide = rightSide;
    }*/
    public string ToString()
    {
        return leftSide + "=" + rightSide;
    }
    // Update is called once per frame
    void Update()
    {
        // GetComponent<Text>().text = this.toString() ;
    }
    public string GetSubstrByIndex(int side, int place, int length)
    {
        string side_str;
        if (side == -1)
        {
            side_str = leftSide;
        }
        else
        {
            side_str = rightSide;
        }
        if (place + length > side_str.Length)
        {
            return "";
        }
        else
        {
            return (side_str.Substring(place, length));
        }
    }

    //function to check if an equation string is valid, ie that it doesn't have a - somewhere in the middle or have only "-"s 
    public bool checkIfValid(string equationSide)
    {
        if (equationSide[equationSide.Length - 1] == '-')
        {
            return false;
        }
        bool foundDigit = false;
        for (int i = 0; i < equationSide.Length; i++)
        {
            char tocheck = equationSide[i];
            if (tocheck == '=')
            {
                return false;

            }
            else if (tocheck != '-')
            {
                foundDigit = true;
            }

        }
        return true;
    }
}
