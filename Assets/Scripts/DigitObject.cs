using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitObject : MonoBehaviour
{
    public int place;
    public int side;
    public string value;
    public GameObject selection_1;
    public GameObject selection_2;
    public bool selected = false;

    // Start is called before the first frame update

    
    private void OnMouseEnter()
    {
        if (GameManager.instance.digitSelect)
        {
            if (value.Equals(GameManager.instance.stringSelection))
            {
                selection_1.SetActive(true);
                selected = true;
            }
            //highlight iff this digit is the selected one
        }
        else if (GameManager.instance.digitPairSelect)
        {
            string st = GameManager.instance.currentEquationObj.GetComponent<Equation>().GetSubstrByIndex(side, place, 2);
            if (st.Equals(GameManager.instance.stringSelection)) 
      
            {
                selection_2.SetActive(true);
                selected = true;
            }
            //highlight iff this digit and the one next to it are in the dictionary
        }
    }
    private void OnMouseExit()
    {
        selected = false;
        if (GameManager.instance.digitSelect)
        {
            selection_1.SetActive(false);
        }
        else if (GameManager.instance.digitPairSelect)
        {
            selection_2.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (selected)
        {
            GameManager.instance.DigitsToMerge = this;
        }
    }

    private void OnMouseUpAsButton()
    {
        //then this digit is sent to the merge or separator 
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
