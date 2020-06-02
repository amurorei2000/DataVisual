using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //씬과 관련된 기능을 가진 네임스페이스

//씬을 관리 하는 오브젝트
public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this.GetComponent<SceneChanger>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    //버튼과의 연결을 위한 메서드(public 선언이 필수)
    public void ChangeNextScene()
    {
        SceneManager.LoadScene(1);  //빌드셋팅에 있는 1번씬을 불러와라
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
