using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);
        Debug.Log("Connetct");
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("OnClientConnect");
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        Debug.Log("OnClientDisconnect");
        
    }
    
    //ֻ��Server����
    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("OnStartServer");
    }

    //ֻ��Server����
    public override void OnStopServer()
    {
        base.OnStopServer();
        Debug.Log("OnStopServer");
    }
}
