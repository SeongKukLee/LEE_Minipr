using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Client : MonoBehaviour
{
    Server server;

    private void Start()
    {
        // 1.서버를 만든다
        server = new Server();

        // 2. 서버에 ResponseData라는 메서드를 등록
        // RequestData();
    }

    void RequestData()
    {
        // 2-1. ResponseData 메서드 사용 권한을 Client Dele에 전달
        ClientDele requestDele = new ClientDele(ResponseData);
        server.Request(requestDele);
    }

    void ResponseData(int data)
    {
        print(data);
    }
    public void OnConnectBtnClkEvent()
    {
        string ret = server.ConnectPLC();
        print(ret);
    }

    public void OnDisconnectBtnClkEvent()
    {
        string ret = server.DisconnectPLC();
        print(ret);
    }

    public void OnGetDataBtnClkEvent()
    {
        RequestData();
    }

    public void OnSetDataBtnClkEvent()
    {

    }
}
