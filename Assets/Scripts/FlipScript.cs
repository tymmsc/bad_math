using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : OperatorScript {

    public Dictionary<string, string> mapping = new Dictionary<string, string>() {
        { "0", "0" },
        { "1","1" },
        {"2", "5" },
        {"3", null },
        {"4", null },
        {"5", "2" },
        {"6", null },
        {"7", null },
        {"8", "8" },
        {"9",null },
        {"-", null }
    };
   
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FlipEquation(Equation inputEq, string newLeft, string newRight)
    {


        GameManager.instance.currentEquationObj.GetComponent<Animator>().SetBool("flip", true);
        yield return new WaitForSeconds(0.67f);
        GameManager.instance.currentEquationObj.GetComponent<Animator>().SetBool("flip", false);
        yield return new WaitForSeconds(0.01f);
        inputEq.setEquation(newLeft, newRight);
    }

    public override bool DoOp(Equation inputEq, Dictionary<string, string> options)
    {
        //flip the input equation and output the new one. 
        //if there are non-allowed characters, then return null 
        string newRight = "";
        string newLeft = "";
     
        for (int i =0; i<inputEq.leftSide.Length; i++)
        {
            string toFlip = inputEq.leftSide.Substring(i, 1);
            string flipped = mapping[toFlip];
            if (null == flipped)
            {
                return false;
            }
            newRight = flipped + newRight; //the first becomes last
        }
        for (int i = 0; i < inputEq.rightSide.Length; i++)
        {
            string toFlip = inputEq.rightSide.Substring(i, 1);
            string flipped = mapping[toFlip];
            if (null == flipped)
            {
                return false;
            }
            newLeft = flipped + newLeft;
        }
        StartCoroutine(FlipEquation(inputEq, newLeft, newRight));

  
        return true;

        //left side = right side
        //for each chara
    }
}
