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
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
