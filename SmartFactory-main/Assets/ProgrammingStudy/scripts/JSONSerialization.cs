using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class DeviceInfo
{
    public string name;             // 송출실린더
    public string serialNumber;     // 실린더A 실린더B ...
    public int operationTime;       // Play 버튼 누른 후의 누적시간
    public int operationCount;      // 실린더 전진, 후진 횟수
    public string freeWarrenty;     // 하드웨어 무상 보증기간

    public DeviceInfo(string name, string serialNumber, int operationTime, int operationCount, string paidWarrenty)
    {
        this.name = name; 
        this.serialNumber = serialNumber; 
        this.operationTime = operationTime; 
        this.operationCount = operationCount; 
        this.freeWarrenty = freeWarrenty; 
    }
}

public class JSONSerialization : MonoBehaviour
{
    public static JSONSerialization instance;
    public List<DeviceInfo> devices = new List<DeviceInfo>();
    // Object(Class) -> JSON
    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age) //생성자 
        {
            this.name = name;
            this.age = age;
        }
    }




    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // 버튼을 누르면, 모든 device의 정보를 전달한다. 

    // Start is called before the first frame update
    void Start()
    {
        /*
        // 단일 데이터를 저장하는 방법
        DeviceInfo info = new DeviceInfo("이성국", "123456", 55555, 5555, "2024.05.30");

        string json = JsonUtility.ToJson(info); //직렬화 (serialization)
        print(json);

        FileStream fs = new FileStream("file.json", FileMode.Create); // 파일을 열고, 닫는 기본적인 입,출력 기능
        StreamWriter sw = new StreamWriter(fs);                       // 문자 단위로 데이터 쓰기, 인코딩 처리
        sw.Write(json);
        sw.Close();
        fs.Close();
        */
        // 여러개의 데이터를 저장하는 방법
        DeviceInfo info1 = new DeviceInfo("공급감지센서", "SensorA", 55555, 5555, "2024.05.30");
        DeviceInfo info2 = new DeviceInfo("공급실린더", "CylinderA", 55555, 5555, "2024.05.30");
        DeviceInfo info3 = new DeviceInfo("가공실린더", "CylinderB", 55555, 5555, "2024.05.30");
        DeviceInfo info4 = new DeviceInfo("송출실린더", "CylinderC", 55555, 5555, "2024.05.30");
        DeviceInfo info5 = new DeviceInfo("컨베이어", "ConveyorA", 55555, 5555, "2024.05.30");
        DeviceInfo info6 = new DeviceInfo("금속감지센서", "SensorB", 55555, 5555, "2024.05.30");
        DeviceInfo info7 = new DeviceInfo("배출실린더", "CylinderD", 55555, 5555, "2024.05.30");
        
        List<DeviceInfo> devices = new List<DeviceInfo>();
        devices.Add(info1);
        devices.Add(info2);
        devices.Add(info3);
        devices.Add(info4);
        devices.Add(info5);

        /*
        string json2 = JsonConvert.SerializeObject(devices);
        print(json2);

        fs = new FileStream("Assets/file2.json", FileMode.Create);     
        sw = new StreamWriter(fs);
        sw.Write(json2);
        sw.Close();
        fs.Close();
        
        // DeviceInfo 라는 컨테이너 클래스의 모양을 알고 있을 경우에 사용
        List<DeviceInfo> newdevices = new List<DeviceInfo>();
        newdevices = JsonConvert.DeserializeObject<List<DeviceInfo>>(json2);
        DeviceInfo deviceFound = newdevices.Find(x => x.name == "이성국3");
        print(deviceFound.freeWarrenty);
        
        Person person = new Person("이성국", 19);// Person 인스턴스화 

        // 객체 -> JSON 변환
        string json = JsonUtility.ToJson(person);
        print(json);

        JsonUtility.FromJson<Person>(json); //json 파일을 Person으로 변환

        Person person2 = JsonUtility.FromJson<Person>(json);
        print($"{person2.name} {person2.age}");
        */


        //JsonUtility.FromJson(json)  JSON 파일을 Object로 사용하기 위해  
        //


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FileStream fs = new FileStream("Assets/file.json", FileMode.Open); 
            StreamReader sr = new StreamReader(fs);                       
            string json = sr.ReadToEnd();
            print(json);
            sr.Close();
            fs.Close();
        }
    }


}