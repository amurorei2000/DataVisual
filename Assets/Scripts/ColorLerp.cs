using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    //시작 지점과 끝지점의 컬러 (마테리얼)
    Color start, end;
    public Renderer matS, matE, myRD;

    public float val;

    // Start is called before the first frame update
    void Start()
    {
        myRD = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        start = matS.material.color;    //렌더러 컴포넌트 > 마테리얼 > 컬러
        end = matE.material.color;      //렌더러 컴포넌트 > 마테리얼 > 컬러
        //나의 컬러를 바꾼다(start컬러와 end컬러 사이의 val를 기준)
        myRD.material.color = Color.Lerp(start, end, val);
    }
}
