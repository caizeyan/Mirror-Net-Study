using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    //�ɷ���������ֵ��Ȼ��ͬ�����ͻ��ˡ� ÿ��Player��һ��halloCount
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
    /// Command �ͻ������������������,�ɷ����ִ��
    /// </summary>
    [Command]
    private void HaloToServer()
    {
        GlobalData.Instance.haloCount++;
        Debug.LogError("Server Get Halo");
        HaloResponse();
    }

    /// <summary>
    /// ClientRpc ��������ͻ��˷���ָ��ɿͻ���ִ��
    /// </summary>
    [ClientRpc]
    private void HaloToClient()
    {
        Debug.LogError("Client Get Halo");
    }

    /// <summary>
    /// TargetRpc ��������ָ���Ŀͻ��˻ظ���Ϣ���ڿͻ���ִ��.
    /// �Զ�Ѱ�ҵ��ø÷�����Client�����û���������пɼ��Ŀͻ��˷���
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
