using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This equation class holds the strings making up the two sides of an equation.
//It updates all the time so that the visible text is always correct.

public class Equation : MonoBehaviour {

   public string leftSide; 
   public string rightSide;
    
	// Use this for initialization
	void Start () {

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
	void Update () {
       // GetComponent<Text>().text = this.toString() ;
    }
}
