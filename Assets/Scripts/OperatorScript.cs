using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is a superclass for all of the operator scripts, so that they can 
//be called even if the exact operator script is not known. 

public class OperatorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		public virtual bool DoOp(Equation e) {
			return false;
		}
    public virtual bool DoOp(Equation e, string side)
    {
        return false;
    }
}
