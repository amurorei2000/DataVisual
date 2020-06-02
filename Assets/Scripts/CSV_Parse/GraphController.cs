using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GraphController : MonoBehaviour
{
    // 그래프 크기를 정할 데이터 변수
    #region
    // 타입 1> 기본 방식
    //public float graph1;
    //public float graph2;
    //public float graph3;
    //public float graph4;
    //public float graph5;
    #endregion
    // 타입 2> 배열 사용
    public float[] graphs;

    #region
    // 그래프 모양을 가진 바 오브젝트
    // 타입 1> 기본 방식
    //public Transform graphBar1;
    //public Transform graphBar2;
    //public Transform graphBar3;
    //public Transform graphBar4;
    //public Transform graphBar5;
    #endregion
    // 타입 2> 배열 사용
    public Transform[] graphBars;
    // 생성시킬 그래프 바 프리팹 변수
    public GameObject barPrefab;
    // 생성시킬 그래프 바의 총 갯수
    public int graphCount;
    // 그래프 바의 색상 변수
    public Color[] graphColor = new Color[10];
    // 그래프 애니메이션을 하기 위한 반복 횟수 변수
    int repeatCount = 0;
    // 그래프 애니메이션 반복 체크용 변수
    //int updateCount = 0;
    // 그래프의 초기 스케일 저장용 변수
    Vector3[] originScale = new Vector3[10];
    // 그래프의 초기 색상 저장용 변수
    Color originColor = Color.white;
    // 시간 누적용 변수
    [Range(0, 1)]
    public float currentTime = 0;

    void Start()
    {
        graphCount = CSV_Test.Instance.myData.Count;

        // graph 배열을 초기화 하기
        graphs = new float[graphCount];

        // graph 배열에 데이터 값을 넣기
        for(int i= 0; i< graphs.Length; i++)
        {
            //graphs[i] = float.Parse(CSV_Test.Instance.myData[i]["나이"].ToString());            
            graphs[i] = Convert.ToSingle(CSV_Test.Instance.myData[i]["나이"]);
        }

        // 반복 횟수 계산하기
        repeatCount = (int)(1 / Time.fixedDeltaTime);

        // graphBars 배열의 초기화
        graphBars = new Transform[graphCount];

        #region
        // 데이터의 값에 따라 그래프 바의 스케일 y 값을 변화시키겠다.
        // 그래프 바의 스케일(localScale) y = 데이터 값(Vector3 타입)

        // 풀이 1>
        //graphBar1.localScale = new Vector3(1, graph1, 1);
        //graphBar2.localScale = new Vector3(1, graph2, 1);
        //graphBar3.localScale = new Vector3(1, graph3, 1);
        //graphBar4.localScale = new Vector3(1, graph4, 1);
        //graphBar5.localScale = new Vector3(1, graph5, 1);

        // 풀이 2>
        //Vector3 defaultVector = new Vector3(1, 0, 1);
        //graphBar1.localScale = defaultVector + Vector3.up * graph1;
        //graphBar2.localScale = defaultVector + Vector3.up * graph2;
        //graphBar3.localScale = defaultVector + Vector3.up * graph3;
        //graphBar4.localScale = defaultVector + Vector3.up * graph4;
        //graphBar5.localScale = defaultVector + Vector3.up * graph5;

        // 풀이 3(오브젝트 자체의 기본 스케일 값을 (1,0,1)로 만들어 놓은 상태
        //graphBar1.localScale += Vector3.up * graph1;
        //graphBar2.localScale += Vector3.up * graph2;
        //graphBar3.localScale += Vector3.up * graph3;
        //graphBar4.localScale += Vector3.up * graph4;
        //graphBar5.localScale += Vector3.up * graph5;

        // 배열 선언 방법 1
        //int[] points = new int[6] ;

        // 배열 선언 방법 2
        //int[] points = new int[6] { 13, 24, 32, 0, 1, 5 };

        // 배열에 값 넣기
        //graphs[0] = 2.4f;
        //graphs[1] = 0;
        //graphs[2] = 4;
        //graphs[3] = -2.1f;
        //graphs[4] = -1.2f;

        // graphs 배열의 초기화
        //graphs = new float[graphCount];

        // for문
        // for(반복자 변수 선언; 반복 종료 조건; 반복자의 증감식)
        // {
        //      to do(반복 시키고자 하는 것)
        // }
        #endregion

        // 4. 위의 1~3번 작업을 지정한 횟수(그래프 총 갯수)만큼 반복한다.
        for (int i = 0; i < graphCount; i++)
        {
            // 1. 그래프 프리팹을 생성한다.
            GameObject gp = Instantiate(barPrefab);
            // 2. GraphContoller 오브젝트를 기준으로 x축으로 1.5미터씩 띄워서 위치시킨다.
            // gp의 위치 = 기준 오브젝트의 위치 + 벡터(1.5f * i, 0, 0)
            gp.transform.position = transform.position + new Vector3(1.5f * i, 0, 0);
            // 3. 생성된 프리팹을 graphBars 배열에 추가한다.
            graphBars[i] = gp.transform;
            // 4. 생성된 프리팹의 매터리얼 색상(graphColor 배열)을 추가한다.
            gp.GetComponentInChildren<MeshRenderer>().material.color = graphColor[i];
            // 5. 생성된 프리팹을 이 게임 오브젝트의 자식으로 등록(==부모로 등록)한다.
            gp.transform.parent = transform;
            // 6. 초기 스케일 값을 저장한다.
            originScale[i] = gp.transform.localScale;
        }

        #region  
        //for(int i = 0; i < graphCount; i++)
        //{
        //    // 1. -3.0f ~ +3.0f 사이의 랜덤한 값을 graphs 배열에 추가한다.
        //    // 2. graphCount 만큼 반복한다.

        //    float randomValue = Random.Range(-3.0f, 3.0f);
        //    graphs[i] = randomValue;
        //}

        //그래프 바에 데이터를 이용하여 scale y 값을 변화시키는 반복문
        //for (int i = 0; i < graphBars.Length; i++)
        //{
        //    // graphs 배열의 값이 양수일 때에만 반복문을 실행하고,
        //    // 만일 graphs 배열의 값이 음수가 나오기 시작하면 반복문을 강제로 종료하겠다!

        //    //if (graphs[i] > 0)
        //    //{
        //    //    graphBars[i].localScale = new Vector3(1, graphs[i], 1);
        //    //}
        //    //else
        //    //{
        //    //    break;
        //    //}

        //    graphBars[i].localScale = new Vector3(1, graphs[i], 1);
        //}
        #endregion
    }

    private void Update()
    {
        // Lerp(Linear interpolation)
        //  -> 시작 위치, 목표 위치, 진행률(%)

        // 예시 1. 시작은 빠르나 목표에 가까워질수록 스케일 변화가 느려지는 애니메이션
        //for (int i = 0; i < graphBars.Length; i++)
        //{
        //    graphBars[i].localScale = Vector3.Lerp(graphBars[i].localScale,
        //                                            new Vector3(1, graphs[i], 1),
        //                                            Time.deltaTime);
        //}

        // 예시 2. 일정한 속도로 스케일이 변하는 애니메이션
        // 1. 초기 위치를 저장하기
        // 2. 진행률을 누적시키기
        if (currentTime < 1)
        {
            currentTime += Time.deltaTime * 0.5f;

            for (int i = 0; i < graphCount; i++)
            {
                graphBars[i].localScale = Vector3.Lerp(originScale[i],
                                                        new Vector3(1, graphs[i], 1),
                                                        currentTime);
                graphBars[i].GetComponentInChildren<MeshRenderer>().material.color = Color.Lerp(originColor,
                                                                                                graphColor[i],
                                                                                                currentTime);
            }
        }       

    }
    
    private void FixedUpdate()
    {        
        //  >> 1초에 걸쳐서 목표 크기(y축)에 도달하게 하고 싶다!
        // 1. 만일, 크기를 키우는 횟수가 아직 목표 횟수 만큼이 안됬다면...
        // 2. 사이즈를 키우자!
        //   - 목표 횟수(50회) = 1초 / fixed timeStep(0.02f)
        //   - 1회당 커져야 할 크기 = (최종 목표 y값 - 최초의 y값) / 목표 횟수                
        //if (updateCount < repeatCount)
        //{
        //    for (int i = 0; i < graphBars.Length; i++)
        //    {
        //        float repeatSize = (graphs[i] - 0) / (float)repeatCount;
        //        graphBars[i].localScale += new Vector3(0, repeatSize, 0);
        //    }
        //    updateCount++;
        //}

    }
}
