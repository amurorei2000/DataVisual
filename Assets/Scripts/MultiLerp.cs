using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLerp : MonoBehaviour
{
    //target의 위치를 이동시킨다
    //lerp (시작과 끝)
    public Transform start, end, earth;
    public Transform[] ends;    //도착지 목록
    //Value(0~1)
    [Range(0,1)]
    public float val;

    public ParticleSystem ps;   //파티클 공장

    public DataControlManager dcm;

    // Start is called before the first frame update
    void Start()
    {
        start = transform;  //내자신을 시작위치로 함
    }

    void ShotEmit()
    {
        // ShotEmit이라는 함수가 호출되면 파티클 하나를 생성해라
        // 기존에 생성된 파티클은 그대로 있는상태에서 하나를 추가한다
        ps.Emit(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            ShotEmit();
        }

        //transform.position = BezirePos(start.position, end.position, val);
        //추가 기능
        if(ps.particleCount > 0)
        {
            //파티클 개별적인 움직임을 제어
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
            ps.GetParticles(particles); //수령
            for(int i = 0; i < particles.Length; i++)
            {
                ParticleSystem.Particle p = particles[i]; //언박싱
                float lerpval = (p.startLifetime - p.remainingLifetime) / p.startLifetime; // Normalize(평준화)

                int div = i % ends.Length;  //파티클번호를 목적지리스트 길이로 나눈 !!나머지!!
                end = ends[div];            //나머지를 활용해서 목적지를 설정함

                if (div == 0) //B지역으로 가는 파티클
                {
                    p.color = Color.red;
                    p.size = 0.5f;
                }else if( div == 1)  //C지역으로 가는 파티클
                {
                    if(i > 20)
                    {
                        p.color = new Color32(0,0,0,0);//색과 투명도를 이용해서 숨긴다
                        //p.remainingLifetime = 0;    //남은시간을 즉시 없애라 = 바로 없애라
                    }
                    else
                    {
                        p.color = Color.green;
                    }
                    p.size = 1.5f;
                }
                else   //D지역으로 가는 파티클
                {
                    //데이터를 재가공
                    float size = float.Parse(dcm.data[1]["2017년 1월"].ToString());
                    if (size > 100)
                    {
                        size = 2;
                        p.color = Color.blue;
                    }
                    else
                    {
                        size = 0.5f;
                        p.color = Color.cyan;
                    }
                    p.size = size;
                }
                p.position = BezirePos(start.position, end.position, lerpval); //재설정
                particles[i] = p;   // 재포장
            }
            ps.SetParticles(particles); //재배송
        }
    }

    public Vector3 BezirePos(Vector3 a, Vector3 b, float v)
    {
        Vector3 eth2st = a - earth.position; //start.position >> a
        Vector3 eth2e = b - earth.position;  //end.position >> b

        //point1, point2의 위치를 구하자
        Vector3 p1 = (Vector3.Slerp(eth2st, eth2e, 0.25f) * 2f) + earth.position;
        Vector3 p2 = (Vector3.Slerp(eth2st, eth2e, 0.75f) * 2f) + earth.position;

        Vector3 AsTop1 = Vector3.Lerp(a, p1, v);//start.position >> a ; val >> v
        Vector3 Bp1Top2 = Vector3.Lerp(p1, p2, v);// val >> v
        Vector3 Cp2Toe = Vector3.Lerp(p2, b, v); //end.position >> b ; val >> v

        Vector3 D = Vector3.Lerp(AsTop1, Bp1Top2, v); // val >> v
        Vector3 E = Vector3.Lerp(Bp1Top2, Cp2Toe, v); // val >> v

        return Vector3.Lerp(D, E, v);
    }
}






        //point1.position = Vector3.Slerp(start.position, end.position, 0.25f);
        //point2.position = Vector3.Slerp(start.position, end.position, 0.75f);

        //point1.position = Vector3.Slerp(start.position - center.position, end.position - center.position, 0.25f) + center.position;
        //point2.position = Vector3.Slerp(start.position - center.position, end.position - center.position, 0.75f) + center.position;
