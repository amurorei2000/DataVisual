using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;    // 스트림과 파일 입출력 관련 네임 스페이스
using System.Text;  // 문자열의 Encoding 관련 네임 스페이스
using System.Xml;   // XML 파일의 파싱 관련 네임 스페이스

public class XML_Reader : MonoBehaviour
{
    public static XML_Reader Instance;
    public string filePath = "Datas/도봉구 우체국 현황.xml";

    public List<string> names = new List<string>();
    public List<string> addresses = new List<string>();
    public List<string> phones = new List<string>();

    // Singletone
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        // XML 데이터 파싱하기
        Read();
    }

    void Read()
    {
        // 1. 파일 스트림을 "오픈 모드 + 읽기 모드"로 생성한다.
        FileStream fs = new FileStream(Application.dataPath + "/" + filePath, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs, Encoding.UTF8);

        // 2. 파일 전체를 읽어서 string 변수에 담아 놓는다.
        string all_data = sr.ReadToEnd();
        //print(all_data);

        // 3. 파일을 읽어드린 문자열을 XML 태그(노드) 별로 분리하기.
        XmlDocument xml_data = new XmlDocument();
        xml_data.LoadXml(all_data);
        XmlNodeList nodes = xml_data.SelectNodes("DobongShareDataService/CONT_DATA_ROW");

        // 4. xml 데이터에서 우체국 이름/ 주소/ 전화번호를 출력하기
        foreach(XmlNode node in nodes)
        {
            string name = node.SelectSingleNode("SHD_NM").InnerXml;
            string address = node.SelectSingleNode("CO_F2").InnerXml;
            string phone = node.SelectSingleNode("CO_F3").InnerXml;

            //print("우체국 이름: " + name);
            //print("우체국 주소: " + address);
            //print("우체국 전화번호: " + phone);

            // 이름/ 주소/ 전화번호를 각각의 리스트에 추가하기.
            names.Add(name);
            addresses.Add(address);
            phones.Add(phone);
        }

    }

}
