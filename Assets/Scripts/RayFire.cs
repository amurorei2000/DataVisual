using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayFire : MonoBehaviour
{
    //CrossHair를 위한 오브젝트
    public Transform crosshair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //레이캐스팅을위한 ray (내 위치를 기준으로 정면방향으로 쏴라!)
        Ray ray = new Ray(transform.position, transform.forward);
        crosshair.position = transform.forward;

        //Debug.DrawRay(transform.position, transform.forward *10f, Color.red);
        if (Input.GetButtonDown("Fire1"))    //왼쪽마우스버튼을 누르면 작동해라
        {
            RaycastHit hit; //레이캐스팅으로 검출된 오브젝트의 정보를 담는 그릇
            //레이져를 쏘면된다!
            if(Physics.Raycast(ray, out hit, 10f))
            {
                
                if (hit.transform.GetComponent<Rigidbody>())
                {
                    //hit 로 검출된 오브젝트에 명령을 내린다
                    print("hit : " + hit.transform.name);
                    hit.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
                }
            }
        }
    }
}
