using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    //由服务器更新值，然后同步给客户端。 每个Player有一个halloCount
    private void Update()
    {
        Move();   
    }

    private void Move()
    {
        if (isLocalPlayer)
        {
            var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0)*0.1f;
            transform.position += move;
        }
        
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            HaloToServer();
        }

        if (isLocalPlayer && isServer && Input.GetKeyDown(KeyCode.Z))
        {
            HaloToClient();
        }

    }

    private void OnGUI()
    {
        if (isLocalPlayer)
        {
            GUILayout.Label("Halo Count:" + GlobalData.Instance.haloCount);
        }
    }

    /// <summary>
    /// Command 客户端向服务器发送命令,由服务端执行
    /// </summary>
    [Command]
    private void HaloToServer()
    {
        GlobalData.Instance.haloCount++;
        Debug.LogError("Server Get Halo");
        HaloResponse();
    }

    /// <summary>
    /// ClientRpc 服务器向客户端发送指令，由客户端执行
    /// </summary>
    [ClientRpc]
    private void HaloToClient()
    {
        Debug.LogError("Client Get Halo");
    }

    /// <summary>
    /// TargetRpc 服务器向指定的客户端回复信息，在客户端执行.
    /// 自动寻找调用该方法的Client，如果没有则向所有可见的客户端发送
    /// </summary>
    [TargetRpc]
    private void HaloResponse()
    {
        Debug.LogError("Server Response Halo");
    }
    
    [TargetRpc]
    private void HaloResponse(NetworkConnection connection)
    {
        Debug.LogError("Server Response Halo");
    }

   
}
