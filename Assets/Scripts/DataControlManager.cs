using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //유니티 UGUI를 위한 네임스페이스

// CSV_test와 파싱된 데이터를 전달받는다
// 전달받은 데이터를 파티클 오브젝트에 전달한다
public class DataControlManager : MonoBehaviour
{
    //CSV_test에서 전달받을 데이터
    public List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

    public float curTime = 0;
    public int count = 0;

    public string[] dataCul = { "2017년 1월", "2017년 2월", "2017년 3월", "2018년 1월", "2018년 2월", "2018년 3월" };
    int dataculCount = 0;
    public Dropdown dd, dm; //날짜(데이터 열)를 선택하기 위한 UI  dd = year , dm = month

    bool isplay = false;    //시각화 애니메이션 작동하느냐?

    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        data = CSV_Test.Instance.myData;    //myData를 복사
        isplay = true;
        print(data[count][dataCul[dataculCount]]);       //검증
    }

    public void DateChange()
    {
        //드롭다운에서 선택지가 변경이되면 dataculCount를 변경시킨다
        dataculCount = (dd.value * 3) + dm.value;
        print(dataculCount);
    }

    // Update is called once per frame
    void Update()
    {
        if(isplay == true)
        {
            //2초가 지나가면, List의 다음 항목을 보여줘라
            if (curTime < 2)     //curTime 2초보다 작다면
            {
                curTime += Time.deltaTime;  //cutTime에 deltaTime을 더해라
            }
            else //curTime이 보다 크거나 같으면
            {
                curTime = 0;    //curTime 초기화
                count++;        //카운트(행)을 1증가한다
                if (count >= data.Count)
                {
                    count = 0;
                    dataculCount++;
                    if (dataculCount >= dataCul.Length)
                    {
                        //예외처리
                        isplay = false;
                        dataculCount = 0;
                        print("finish");
                        return; //Update함수를 강제 종료
                    }
                }

                float targparticleCount = float.Parse((string)data[count][dataCul[dataculCount]]) / 2;
                ps.emissionRate = targparticleCount;
                //print(data[count][dataCul[dataculCount]]);
            }
        }
        
    }
}
