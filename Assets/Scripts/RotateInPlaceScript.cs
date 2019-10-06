using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInPlaceScript : OperatorScript
{
    public Dictionary<string, string> mapping90 = new Dictionary<string, string>() {
        { "0", "0" },
        { "1","-" },
        {"2", null },
        {"3", null },
        {"4", null },
        {"5", null },
        {"6", null },
        {"7", null },
        {"8", "∞" },
        {"9",null },
        { "-","1"}
    };
    public Dictionary<string, string> mapping180 = new Dictionary<string, string>() {
        { "0", "0" },
        { "1","1" },
        {"2", "2" },
        {"3", null },
        {"4", null },
        {"5", "5" },
        {"6", "9" },
        {"7", null },
        {"8", "8" },
        {"9","6" },
        {"-", "-" }
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool DoOp(Equation inputEq, Dictionary<string, string> options)
    {
        int rotation;
        if (null == options || !options.ContainsKey("number"))
        {
            rotation = 180;
        }
        else
        {
            rotation = int.Parse(options["number"]);
        }
       

        string newRight = "";
        string newLeft = "";
     
        for (int i =0; i<inputEq.leftSide.Length; i++)
        {
            string toRotate = inputEq.leftSide.Substring(i, 1);
            string rotated = "";
            //if it's a single digit 1, it can't be rotated 90
            //and if it's a 1 that in't the first digit, it also can't
            if (rotation==90 && toRotate.Equals("1") && (i != 0 || inputEq.leftSide.Length <= 1)){
                return false;
            }
            if (rotation == 180)
            {
                if (!mapping180.ContainsKey(toRotate))
                {
                    return false;
                }
                rotated = mapping180[toRotate];
            }
            else if (rotation == 90)
            {
                if (!mapping90.ContainsKey(toRotate))
                {
                    return false;
                }
                rotated = mapping90[toRotate];
            }
            else
            {
                Debug.Log("Error in rotateInPlaceScript: wrong rotation given");
                return false;
            }
            if (null == rotated)
            {
                return false;
            }
            newLeft = newLeft + rotated;
        }
        for (int i =0; i<inputEq.rightSide.Length; i++)
        {

            string toRotate = inputEq.rightSide.Substring(i, 1);
            string rotated = "";
            if (rotation == 90 && toRotate.Equals("1") && (i != 0 || inputEq.rightSide.Length <= 1)){
                return false;
            }
            if (rotation == 180)
            {
                if (!mapping180.ContainsKey(toRotate))
                {
                    return false;
                }
                rotated = mapping180[toRotate];
            }
            else if (rotation == 90)
            {
                if (!mapping90.ContainsKey(toRotate))
                {
                    return false;
                }
                rotated = mapping90[toRotate];
            }
            else
            {
                Debug.Log("Error in rotateInPlaceScript: wrong rotation given");
                return false;
            }
            if (null == rotated)
            {
                return false;
            }
            newRight = newRight + rotated;
        }
      

        inputEq.leftSide = newLeft;
        inputEq.rightSide = newRight;
        return true;
    }
}
