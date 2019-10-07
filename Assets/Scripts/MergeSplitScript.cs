using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeSplitScript : MonoBehaviour
{
  
    public GameObject dropdownObj;
    private Dropdown dropdown;
    public bool dropdownOpen = false;

    private int selection = -1;


    public Dictionary<string, string> options;
    public string side;
    public string location;
    public string number;
    // Use this for initialization
    public Sprite spriteImage;
    Sprite spriteOver;
    public List<MergeUnmergeDictionaries.stringPair> mergeList;
    public string mode; //merge or split
    public int currentDropSelection = 0;
    public Sprite makeSelectionSprite;

    // Use this for initialization

    void Start()
    {
        
        if (mode == "merge")
        {

            mergeList = GetComponent<MergeUnmergeDictionaries>().mergeList;
        }
        else
        {
            mergeList = GetComponent<MergeUnmergeDictionaries>().splitList;
        }

        List<string> dropOptions = new List<string>();
        foreach (MergeUnmergeDictionaries.stringPair sp in mergeList) {
            string optionString = sp.first + "-->" + sp.second;
            dropOptions.Add(optionString);
        }

        dropdown = dropdownObj.GetComponent<Dropdown>();
        dropdown.AddOptions(dropOptions);

        options = new Dictionary<string, string>();
        if (side != "")
        {
            options["side"] = side;
        }
        if (location != "")
        {
            options["location"] = location;
        }
        if (number != "")
        {
            options["number"] = number;
        }
        spriteOver = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().sprite = spriteImage;

    }
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = spriteOver;
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = spriteImage;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.DigitsToMerge!=null)
        {
            //finally, call the operation
            Equation currentEquation = new Equation();
            currentEquation.leftSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().leftSide;
            currentEquation.rightSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().rightSide;
           // fs.DoOp(GameManager.instance.currentEquationObj.GetComponent<Equation>(), options);
            //replace the digit with the new digits
            int side = GameManager.instance.DigitsToMerge.side;
            int place = GameManager.instance.DigitsToMerge.place;

            int numToRemove;
            if (mode.Equals("split"))
            {
                numToRemove = 1;
            }
            else
            {
                numToRemove = 2;
            }
            string leftSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().leftSide;
            string rightSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().rightSide;
            if (side == -1)
            {
                leftSide = leftSide.Remove(place,numToRemove);
                leftSide = leftSide.Insert(place, mergeList[currentDropSelection].second);
            }
            else
            {
                
                    rightSide = rightSide.Remove(place, numToRemove);
                    rightSide = rightSide.Insert(place, mergeList[currentDropSelection].second);
                
            }
           
            GameManager.instance.currentEquationObj.GetComponent<Equation>().setEquation(leftSide, rightSide);
            GameManager.instance.pastEquations.GetComponent<EquationArray>().PushEquation(currentEquation);
            GameManager.instance.DigitsToMerge = null;
            GameManager.instance.digitSelect = false;
            GameManager.instance.digitPairSelect = false;
            GameManager.instance.stringSelection = "";
            hideDropdown();
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);

        }
    }

    public void OnMouseDown()
    {

        if (!dropdownOpen)
        {
            //open the dropdown list
            dropdownObj.SetActive(true);
            dropdownOpen = true;

            //wait until the person selects a number
            dropdown.onValueChanged.AddListener(delegate {
                myDropdownValueChangedHandler(dropdown);
            });
        }
        else
        {
            hideDropdown();
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
            GetComponent<SpriteRenderer>().sprite = spriteOver;
            GameManager.instance.digitPairSelect = false;
            GameManager.instance.stringSelection = "";
                GameManager.instance.digitSelect = false;
            currentDropSelection = 0;
            
        }
    }
    public void hideDropdown()
    {
        dropdownOpen = false;
        dropdownObj.SetActive(false);
        dropdown.onValueChanged.RemoveAllListeners();
        selection = -1;
        dropdown.value = 0;
        currentDropSelection = 0;
        GameManager.instance.digitPairSelect = false;
        GameManager.instance.stringSelection = "";
        GameManager.instance.digitSelect = false;
    }
    private void myDropdownValueChangedHandler(Dropdown target)
    {
        string selection = target.options[target.value].text;
        currentDropSelection = target.value - 1;
        Debug.Log("selected: " + selection);
       // hideDropdown();
        if (selection == " ")
        {
            return;
        }
        GameManager.instance.stringSelection = mergeList[target.value-1].first;
          
        GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
        GetComponent<SpriteRenderer>().sprite = makeSelectionSprite;
        if (mode == "merge")
        {
            GameManager.instance.digitPairSelect = true;
            
        }
        else
        {
            GameManager.instance.digitSelect = true;
        }
       // options["number"] = selection;

        //Equation currentEquation = new Equation();
        //currentEquation.leftSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().leftSide;
        //currentEquation.rightSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().rightSide;
       // bool n = fs.DoOp(GameManager.instance.currentEquationObj.GetComponent<Equation>(), options);
        //if it's not possible here, turn it red



        //if it is successful turn it gray, and update the equation panels 
        //if (n)
        //{
         //   GameManager.instance.pastEquations.GetComponent<EquationArray>().PushEquation(currentEquation);
        //}
    }
    //Call some other function to do somethng, maybe




}
