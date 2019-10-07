using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertLeadingDigitButton : MonoBehaviour
{

    public GameObject dropdownObj;
    private Dropdown dropdown;
    public bool dropdownOpen = false;

    private int selection = -1;

    public GameObject operatorObject;
    protected OperatorScript fs;
    public Dictionary<string, string> options;
    public string side;
    public string location;
    public string number;
    // Use this for initialization
    public Sprite spriteImage;
    Sprite spriteOver;

    // Use this for initialization

    void Start()
    {
        dropdown = dropdownObj.GetComponent<Dropdown>();
        fs = operatorObject.GetComponent<OperatorScript>();
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

    }

    public void OnMouseDown()
    {
        //if the first digit of either side is -1, we can't do this


        if (!dropdownOpen) {
            //open the dropdown list
            dropdownObj.SetActive(true);
            dropdownOpen = true;

            //wait until the person selects a number
            dropdown.onValueChanged.AddListener(delegate { myDropdownValueChangedHandler(dropdown);
            });
        }
        else
        {
            hideDropdown();
        }
    }
    public void hideDropdown()
    {
        dropdownOpen = false;
        dropdownObj.SetActive(false);
        dropdown.onValueChanged.RemoveAllListeners();
        selection = -1;
        dropdown.value = 0;
    }
    private void myDropdownValueChangedHandler(Dropdown target)
    {
        string selection = target.options[target.value].text;
        Debug.Log("selected: " + selection);
        hideDropdown();
        if(selection ==" ")
        {
            return;
        }

        options["number"] = selection;

        Equation currentEquation = new Equation();
        currentEquation.leftSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().leftSide;
        currentEquation.rightSide = GameManager.instance.currentEquationObj.GetComponent<Equation>().rightSide;
        bool n = fs.DoOp(GameManager.instance.currentEquationObj.GetComponent<Equation>(), options);
        //if it's not possible here, turn it red



        //if it is successful turn it gray, and update the equation panels 
        if (n) {
            GameManager.instance.pastEquations.GetComponent<EquationArray>().PushEquation(currentEquation);
        }
    }
        //Call some other function to do somethng, maybe
        
    


}
