using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationGameObject : MonoBehaviour
{
    //The prefab will hold the sprites for every character
    public GameObject[] digitSprites;
    Dictionary<char, GameObject> digitDict;
    public Equation equation;
    public List<GameObject> digitListRight;
    public List<GameObject> digitListLeft;
    float digit_width; 
    // Start is called before the first frame update
    void Start()
    {
        digitDict = new Dictionary<char, GameObject>();
        digitDict.Add('0', digitSprites[0]);
        digitDict.Add('1', digitSprites[1]);
        digitDict.Add('2', digitSprites[2]);
        digitDict.Add('3', digitSprites[3]);
        digitDict.Add('4', digitSprites[4]);
        digitDict.Add('5', digitSprites[5]);
        digitDict.Add('6', digitSprites[6]);
        digitDict.Add('7', digitSprites[7]);
        digitDict.Add('8', digitSprites[8]);
        digitDict.Add('9', digitSprites[9]);
        digitDict.Add('-', digitSprites[10]);
        digitDict.Add('=', digitSprites[11]);
        //digitDict["5"] = digitSprites[5];
        digit_width = digitDict['0'].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }
    public void setEquation(Equation e)
    {
        digitListLeft.Clear();
        digitListRight.Clear();
        //first delete all the old gameobjects
        foreach (Transform child in transform.Find("leftside"))
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in transform.Find("rightside"))
        {
            GameObject.Destroy(child.gameObject);
        }
        equation = e;
        //write out the equation by placing the digit prefabs
        string fullString = equation.ToString();
        int equals_index = fullString.IndexOf('=');

        for (int i = 0; i < fullString.Length; i++)
        {
            //Instantiate the digit prefab and put it as a child on the correct side

            GameObject digit = Instantiate(digitDict[fullString[i]]);
    
            if (i < equals_index) {
                digitListLeft.Add(digit);
                digit.transform.SetParent(transform.GetChild(0));
                digit.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                digit.GetComponent<DigitObject>().side = -1;
            digit.GetComponent<DigitObject>().place = i;
            digit.GetComponent<DigitObject>().value = e.leftSide[i].ToString();
            }
            else if(i > equals_index)
            {
                digitListRight.Add(digit);
                digit.transform.SetParent(transform.GetChild(1));
                digit.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                int sideInd = i - equals_index - 1;
                
                digit.GetComponent<DigitObject>().side = 1;
                digit.GetComponent<DigitObject>().place = sideInd ;
                digit.GetComponent<DigitObject>().value = e.rightSide[sideInd].ToString();
            }
            else
            {
                digit.transform.SetParent(transform.GetChild(0));
                digit.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                digit.GetComponent<DigitObject>().value = "=";
                digit.GetComponent<DigitObject>().side = 0;
            }
            //put it i* one digit-width away from the start
            float spacing = 1.1f;
            float total_length = (digit_width * spacing * fullString.Length) - (digit_width * (spacing - 1));
            Transform startPosition = transform.parent.Find("currentLineStart");
            transform.position = new Vector3(startPosition.position.x + total_length/2.0f, this.transform.position.y, this.transform.position.z);
            digit.transform.position = new Vector3(startPosition.position.x + digit_width/2.0f+ i * digit_width*spacing, this.transform.position.y, this.transform.position.z);

        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
