using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class ArrayData
{
    public string[] names = new string[3];
    public int[] ages = new int[3];
    public string[] jobs = new string[3];

    // JsonUtility로는 불가능, Newtonsoft.Json.JsonConverter로는 가능
    //public List<string> height = new List<string>();
    //public Dictionary<string, float> weight = new Dictionary<string, float>();
}
