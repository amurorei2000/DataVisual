using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    // Text 컴포넌트 변수
    public Text name;
    public Text address;
    public Text phone;

    // 현재 선택된 리스트 번호 변수
    int currentNum = 0;

    private void Start()
    {
        PrintXmlData(currentNum);
    }

    // 다음 리스트를 출력하는 함수
    public void NextList()
    {
        // 방법 1) 리스트 번호를 제한하는 방식

        // 만일 리스트 번호가 리스트의 총 갯수 이하라면...
        //if (XML_Reader.Instance.names.Count - 1 > currentNum)
        //{
        //    // 리스트 번호를 1 증가시키기
        //    currentNum++;
        //    // 리스트 출력하기
        //    PrintXmlData(currentNum);
        //}

        // 방법 2) 리스트를 순환시키는 방식

        // 리스트 번호를 1 증가시키기
        currentNum++;
        // 리스트 번호가 순환될 수 있도록 리스트의 총 갯수로 나누어준다.
        currentNum = currentNum % XML_Reader.Instance.names.Count;

        // 리스트 출력하기
        PrintXmlData(currentNum);

    }

    // 이전 리스트를 출력하는 함수
    public void PreviousList()
    {
        // 방법 1) 리스트 번호를 제한하는 방식

        // 만일 리스트 번호가 0 이하라면...
        //if (currentNum > 0)
        //{
        //    // 리스트 번호를 1 감소시키기
        //    currentNum--;
        //    // 리스트 출력하기
        //    PrintXmlData(currentNum);
        //}

        // 방법 2) 리스트를 순환시키는 방식

        // 리스트 번호를 1 감소시키기
        currentNum--;        
        if(currentNum < 0)
        {
            currentNum += XML_Reader.Instance.names.Count;
        }

        // 리스트 출력하기
        PrintXmlData(currentNum);

    }

    void PrintXmlData(int listNum)
    {
        // 이름, 주소, 전화번호 리스트에서 값을 가져와서 Text 컴포넌트의 text 변수에 입력하기
        name.text = XML_Reader.Instance.names[listNum];
        address.text = XML_Reader.Instance.addresses[listNum];
        phone.text = XML_Reader.Instance.phones[listNum];
    }
}
