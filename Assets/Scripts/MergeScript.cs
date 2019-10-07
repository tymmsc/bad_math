using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeScript : OperatorScript
{
    public Dictionary<string, string> mapping = new Dictionary<string, string>() {
        {"02", "8" },
        {"03", "8" },
        {"04", "8" },
        {"05", "8" },
        {"06", "8" },
        {"09", "8" },
        {"-0", "8" },
        {"13", "8"},
        {"19", "8"},
        {"20", "8"},
        {"24", "8"},
        {"25", "8"},
        {"26", "8"},
        {"29", "8"},
        {"30", "8"},
        {"31", "8"},
        {"34", "9"},
        {"35" ,"9"},
        {"36", "8"},
        {"40", "8"},
        {"42", "8"},
        {"43", "9"},
        {"45", "9"},
        {"46", "8"},
        {"50", "8"},
        {"52", "8"},
        {"53", "9"},
        {"54", "9"},
        {"57", "9"},
        {"60", "8"},
        {"62", "8"},
        {"63", "8"},
        {"64", "8"},
        {"67", "8"},
        {"69", "8"},
        {"75", "9"},
        {"76", "8"},
        {"90", "8"},
        {"91", "8"},
        {"92", "8"},
        {"96", "8"},
        {"-0", "8"},
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override bool DoOp(Equation inputEq, Dictionary<string, string> options)
    {
        if (options==null || !options.ContainsKey("side") || !options.ContainsKey("location"))
        {
            return false;
        }
        string side = options["side"];
        string location = options["location"];

        int i = int.Parse(location);
        string newString = "";
        if(side == "right") 
        {
            newString = newString + inputEq.rightSide.Substring(0, i);
            if(!mapping.ContainsKey(inputEq.rightSide.Substring(i, 2))) {
                return false;
            }
            newString = newString + mapping[inputEq.rightSide.Substring(i, 2)];
            newString = newString + inputEq.rightSide.Substring(i+2);
            inputEq.setEquation(inputEq.leftSide, newString);
            return true;
        }
        else if(side == "left")
        {
            newString = newString + inputEq.leftSide.Substring(0, i);
            if(!mapping.ContainsKey(inputEq.leftSide.Substring(i, 2))) {
                return false;
            }
            newString = newString + mapping[inputEq.leftSide.Substring(i, 2)];
            newString = newString + inputEq.leftSide.Substring(i+2);
            inputEq.setEquation(newString, inputEq.rightSide);
            return true;
        }
        return false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
