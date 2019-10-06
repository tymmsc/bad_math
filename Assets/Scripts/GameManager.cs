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
    public GameObject pastEquations;
    public int level; 

    private void Awake()
    {
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

    public bool CheckIfSolved()
    {
        string leftSide = currentEquation.GetComponent<Equation>().leftSide;
        string rightSide = currentEquation.GetComponent<Equation>().rightSide;
        bool solved = leftSide.Equals(rightSide);
        bool parse_solved = (int.Parse(leftSide) == int.Parse(rightSide));
        if (solved || parse_solved){
            level = level + 1;
            initializeLevel();
            return true;
        }
        return false;
  
    }
    void Start () {
        initializeLevel();
	}

    void initializeLevel()
    {
        currentEquation.GetComponent<Equation>().leftSide = "0";
        currentEquation.GetComponent<Equation>().rightSide = level.ToString();
        pastEquations.GetComponent<EquationArray>().Reset();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
