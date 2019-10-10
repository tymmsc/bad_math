using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager is a class that is global, so all other functions can access it
// by using GameManager.instance

//It holds global stuff, like the current equation being worked on, 
//The score, the level, etc. It also is supposed to persist across scenes. 

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public float score;
    public GameObject currentEquation;
    public GameObject currentEquationObj;
    public GameObject pastEquations;
    public int level;
    public GameObject qedStamp;
    public bool digitSelect = false;
    public bool digitPairSelect = false;
    public string stringSelection = "";
    public DigitObject DigitsToMerge = null;
    public int[] order;

    private void Awake()
    {
        order = new int[] { 0, 10, 8, 1, 3, 7, 9, 6, 5, 2 };
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);
        score = 0;


    }
    // Use this for initialization
    IEnumerator Wait(float duration)
    {
        //This is a coroutine
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        Debug.Log("Float duration = " + duration);
        yield return new WaitForSeconds(duration);   //Wait
        Debug.Log("End Wait() function and the time is: " + Time.time);
    }

    public bool CheckIfSolved()
    {
        string leftSide = currentEquationObj.GetComponent<Equation>().leftSide;
        string rightSide = currentEquationObj.GetComponent<Equation>().rightSide;
        bool solved = leftSide.Equals(rightSide);
        bool parse_solved = (int.Parse(leftSide) == int.Parse(rightSide));
        if (solved || parse_solved){
            StartCoroutine(GoToNextLevel());
            return true;
        }
        return false;
  
    }
    IEnumerator GoToNextLevel()
    {
        qedStamp.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        qedStamp.SetActive(false);
        level = level + 1;
        initializeLevel();
    }
    void Start () {
        initializeLevel();
	}

    void initializeLevel()
    {
        //setting left side and right side
        if (level >= order.Length)
        {
            currentEquationObj.GetComponent<Equation>().setEquation("0", level.ToString());
        }
        else
        {
            currentEquationObj.GetComponent<Equation>().setEquation("0", order[level].ToString());
        }
        
        pastEquations.GetComponent<EquationArray>().Reset();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
