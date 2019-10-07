using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeUnmergeDictionaries : MonoBehaviour
{
    public struct stringPair
    {
        public string first;
        public string second;
        public stringPair(string f, string s)
        {
            first = f;
            second = s;
        }

    }
    public List<stringPair> mergeList;
    public List<stringPair> splitList;
    // Start is called before the first frame update
    void Start()
    {
        mergeList = new List<stringPair>();
        splitList = new List<stringPair>();
        // mergeLists= new List<string, string>();

        // 8 --> -0 or 13 or 19 or 61
        // 9 --> 51
        // 7 --> -1
        // 6 --> 15
        
        mergeList.Add(new stringPair("-0", "8"));
        splitList.Add(new stringPair("6", "15"));
        mergeList.Add(new stringPair("-1", "7"));
        splitList.Add(new stringPair("7", "-1"));
        mergeList.Add(new stringPair("13", "8"));
        splitList.Add(new stringPair("8", "-0"));
        mergeList.Add(new stringPair("15", "6"));
        splitList.Add(new stringPair("8", "13"));
        mergeList.Add(new stringPair("19", "8"));
        splitList.Add(new stringPair("8", "19"));
        mergeList.Add(new stringPair("51", "9"));
        splitList.Add(new stringPair("8", "61"));
        mergeList.Add(new stringPair("61", "8"));
        splitList.Add(new stringPair("9", "51"));

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
