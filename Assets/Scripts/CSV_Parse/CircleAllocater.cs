using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAllocater : MonoBehaviour
{
    // 반지름
    public float radius = 5f;
    // 배치할 수량
    public int graphCount = 8;
    // 배치할 프리팹
    public GameObject barObj;
    // 기준이 될 오브젝트
    public Transform baseObj;
    
    // 각도(사잇각)
    float degree = 0;
    
    void Start()
    {
        // 수량에 따른 사잇각 구하기
        // -> 사잇각 = 360 / 수량
        degree = 360.0f / (float)graphCount;
        Vector3[] graphPos = new Vector3[graphCount];
        GameObject[] go1 = new GameObject[graphCount];

        for (int i = 0; i < graphCount; i++)
        {
            // 반지름이 r, 사잇각이 theta일때 x 좌표와 y(또는 z) 좌표는
            // -> (x, y) = (r*cos(Theta), r*sin(Theta))
            graphPos[i] = baseObj.position 
                          + new Vector3(radius * Mathf.Cos(degree * i * Mathf.Deg2Rad),
                                        0,
                                        radius * Mathf.Sin(degree * i * Mathf.Deg2Rad));

            // 프리팹을 생성한다.
            GameObject go = Instantiate(barObj);

            // 생성한 프리팹의 위치를 위에서 구한 좌표로 이동시킨다.
            go.transform.position = graphPos[i];

            // 생성된 프리팹의 방향을 기준 오브젝트를 바라보는 방향으로 회전시킨다.
            go.transform.LookAt(baseObj);

            // 생성된 프리팹을 기준 오브젝트의 자식으로 넣는다.
            go.transform.parent = baseObj;
        }

        
    }

    void Update()
    {
        
    }
}
