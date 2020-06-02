using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStrurctureTest2 : MonoBehaviour
{
    // 딕셔너리 변수 만들기
    Dictionary<string, float> weights = new Dictionary<string, float>();
       
    void Start()
    {
        // 1. 딕셔너리 변수에 값 넣기

        // 방법 1) Add() 함수를 이용하여 키, 값 넣기
        weights.Add("박원석", 79.5f);
        weights.Add("장독대", 79.5f);
        weights.Add("김현진", 70.3f);

        // 방법 2) 키를 이용하여 값을 넣기
        //weights["장독대"] = 100f;


        // 2. 딕셔너리 내용물 출력하기
        #region
        // foreach문 예시
        //int[] test = new int[3] { 24, 35, 100 };

        //foreach(int abc in test)
        //{
        //    print(abc);
        //}
        #endregion

        // 방법 1) 전체 보기
        print("삭제 전");
        ItemPrint(weights);

        // 방법 2) 키를 이용하여 저장된 값을 출력하기

        //string myKey = "박현상";

        //// 만일, 내가 찾으려는 키가 존재한다면...
        //if (weights.ContainsKey(myKey))
        //{
        //    // 그 키에 해당하는 값을 출력하고 싶다.
        //    float result = weights[myKey];
        //    print(result);
        //}

        // 3. 딕셔너리 데이터 삭제하기

        // 방법 1) 전체 삭제
        //weights.Clear();
        //print("삭제 후");
        //ItemPrint(weights);

        // 방법 2) 일부만 삭제
        weights.Remove("장독대");
        print("삭제 후");
        ItemPrint(weights);

        
    }

    public void ItemPrint(Dictionary<string, float> dict)
    {
        foreach (KeyValuePair<string, float> d in dict)
        {
            //print(weight.Key);
            //print(weight.Value);

            //print("이름: " + weight.Key + ", 체중: " + weight.Value + "kg");
            print(d);
        }
    }

}
