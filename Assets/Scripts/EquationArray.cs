using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationArray : MonoBehaviour
{
    public Stack<Equation> equations = new Stack<Equation>();
    Text mytext;
    // Start is called before the first frame update
    void Start()
    {
        mytext = GetComponent<Text>();
        Reset();
    }

    public void Reset()
    {
        mytext.text = "";
        equations.Clear();
    }

    public bool PopEquation() { 
        if(equations.Count< 1){
            return false;
        }
        Equation previous = equations.Pop();
        GameManager.instance.currentEquationObj.GetComponent<Equation>().setEquation(previous.leftSide, previous.rightSide);

        int lastLineStart = mytext.text.LastIndexOf("\n");
        mytext.text = mytext.text.Substring(0,lastLineStart);
        return true;
 
    }
    public void PushEquation(Equation e)
    {

        //Write the equation to a new line
        mytext.text = mytext.text + "\n" + e.ToString();
        //And put it in the stack too
        equations.Push(e);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
