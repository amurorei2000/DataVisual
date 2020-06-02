using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructureTest : MonoBehaviour
{
    // 리스트 변수 만들기
    List<int> ages = new List<int>();
    

    void Start()
    {
        // 1. 리스트 변수에 값을 넣기

        // 방식 1) Add() 함수를 이용하여 값 넣기
        ages.Add(39);
        ages.Add(37);
        ages.Add(45);

        // 방식 2) 인덱스를 지정하여 값 넣기
        ages[0] = 55;
        ages[1] = 100;
        

        print("삭제 전의 리스트 개수: " + ages.Count);

        // 2. 리스트 값을 출력하기(for 문)
        for(int i = 0; i < ages.Count; i++)
        {
            print("삭제 전: " + ages[i]);
        }

        // 3. 리스트 변수의 값을 지우기 - Remove() 함수

        // 1) 값으로 지우기
        //ages.Remove(37);
        // 2) 인덱스로 지우기
        //ages.RemoveAt(2);        
        // 3) 리스트 전체를 지우기
        //ages.Clear();

        //print("삭제 후의 리스트 개수: " + ages.Count);

        //for (int i = 0; i < ages.Count; i++)
        //{
        //    print("삭제 후: " + ages[i]);
        //}

        // 4. 리스트 값을 확인하기
        bool isExist1 = ages.Contains(45);
        bool isExist2 = ages.Contains(30);

        
    }

    void Update()
    {
        
    }
}
