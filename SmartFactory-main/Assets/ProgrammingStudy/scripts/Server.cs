using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using ActUtlType64Lib;
using System;
public delegate void ClientDele(int data);
public class Server
{
    Thread thread;
    ClientDele dele;
    ActUtlType64 mxComponent;
    public Server() 
    {
        thread = new Thread(() => Run());

        mxComponent = new ActUtlType64();
        mxComponent.ActLogicalStationNumber = 1;
    }

    // 3. 서버에서 권한을 받고, 작업을 실행
    public void Request(ClientDele dele)
    {
        this.dele = dele;

        thread.Start();
    }

    // 4. 작업 후 Client에게 ClientDele을 통한 데이터 전송
    void Run()
    {
        Thread.Sleep(3000); // 작업

        Response();
    }

    void Response()
    {
        int deviceValue = 0;
        int ret = mxComponent.GetDevice("D0", out deviceValue);

        dele(deviceValue); // 4-1. Client의 Response 메서드 실행
    }

    public string ConnectPLC()
    {
        int ret = mxComponent.Open();
        if (ret != 0)
        {
            return ret.ToString("X");
        }
        else
            return DateTime.Now + " : PLC is connected";
    }

    public string DisconnectPLC()
    {
        int ret = mxComponent.Close();
        if (ret != 0)
        {
            return DateTime.Now + ":" + ret.ToString("X");
        }
        else
            return DateTime.Now + " : PLC is disconnected";
    }
}

