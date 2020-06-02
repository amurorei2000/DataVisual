using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UI_Input_Data : MonoBehaviour
{
    // 사용자에게서 입력받은 데이터 텍스트
    public List<InputField> inputData = new List<InputField>();

    // 저장 경로
    string path = "/Datas";

    // 저장될 파일 이름
    string fileName = "myUser.json";

    private void Start()
    {
        // 상대 경로를 절대 경로로 변경하기
        path = Application.dataPath + path;
    }

    // 데이터를 json 파일로 저장하는 함수
    public void OnDataSave()
    {
        // 1. 클래스 변수를 하나 생성한다.
        UserData uData = new UserData();

        // 2. 입력받은 텍스트 내용을 userData 클래스에 저장한다.
        uData.index = int.Parse(inputData[0].text);
        uData.name = inputData[1].text;
        uData.age = int.Parse(inputData[2].text);
        uData.job = inputData[3].text;
        fileName = inputData[4].text + ".json";

        // 3. 클래스 변수를 json 파일로 저장한다.
        // 3-1. 클래스 변수의 내용을 json 형식으로 변환해서 string 변수에 넣기.
        string jData = JsonUtility.ToJson(uData, true);
        //print(jData);
        // 3-2. json 형태로 변환된 string 변수를 json 파일로 저장한다.        
        FileStream fs = new FileStream(path + "/" + fileName, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        sw.Write(jData);
        sw.Close();
        fs.Close();
    }

    // 데이터를 json 파일에서 읽어오는 함수
    public void OnDataLoad()
    {
        // 읽어올 파일 경로 지정해주기
        fileName = inputData[4].text + ".json";

        // 1. json 파일을 열어서 안에 있는 문자열 데이터를 읽어오기
        FileStream fs = new FileStream(path + "/" + fileName, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
        string readData = sr.ReadToEnd();
        sr.Close();
        fs.Close();
        //print(readData);

        // 2. 불러온 readData를 UserData 클래스 변수에 넣기
        UserData rData = new UserData();
        rData = JsonUtility.FromJson<UserData>(readData);

        // 3. UserData의 각 변수들의 값을 대응되는 InputField에다 입력해주기.
        inputData[0].text = rData.index.ToString();
        inputData[1].text = rData.name;
        inputData[2].text = rData.age.ToString();
        inputData[3].text = rData.job;
    }

    // 인풋 필드를 전부 지워주는 함수
    public void OnDataClear()
    {
        for(int i= 0; i < inputData.Count; i++)
        {
            // TEXT 오브젝트의 부모 오브젝트에 있는 InputField 컴포넌트에 접근
            // InputField 컴포넌트의 text 변수에 빈 문자열을 넣어준다.
            //inputData[i].GetComponentInParent<InputField>().text = "";
            inputData[i].text = "";
        }
    }
}
