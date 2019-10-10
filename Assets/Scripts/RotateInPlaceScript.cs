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
        {"8", "00" },
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

    IEnumerator RotateNumbers(Equation inputEq, string newLeft, string newRight, int rot)
    {
        EquationGameObject eqObj = inputEq.GetComponent<EquationGameObject>();
        //for each digit of eqObj:
        string animBoolName;
        if(rot == 90)
        {
            animBoolName = "rot90"; 
        }
        else
        {
            animBoolName = "rot180";
        }
        List<GameObject> digitListAll = new List<GameObject>();
        digitListAll.AddRange(eqObj.digitListLeft);
        digitListAll.AddRange(eqObj.digitListRight);
        foreach (GameObject g in digitListAll)
        {
            g.GetComponent<Animator>().SetBool(animBoolName, true);
        }
        yield return new WaitForSeconds(0.67f);
        foreach (GameObject g in digitListAll)
        {
            g.GetComponent<Animator>().SetBool("flip", false);
        }
        yield return new WaitForSeconds(0.01f);


        inputEq.setEquation(newLeft, newRight);
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
            //For a 1 to be able to rotate, it has to have a non-1 to the right, and only 1s to the right.
            if (toRotate.Equals("1") && rotation==90)
            {
                for (int j=0; j<i; j++)
                {
                    if (inputEq.leftSide[j] != '1')
                    {
                        return false;
                    }
                }
                if(inputEq.leftSide[inputEq.leftSide.Length-1] == '1')
                {
                    return false;
                }
               
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
            if (toRotate.Equals("1") && rotation == 90)
            {
                for (int j = 0; j < i; j++)
                {
                    if (inputEq.rightSide[j] != '1')
                    {
                        return false;
                    }
                }
                if (inputEq.rightSide[inputEq.rightSide.Length - 1] == '1')
                {
                    return false;
                }

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


        StartCoroutine(RotateNumbers(inputEq,newLeft,newRight,rotation));
        return true;
    }
}
