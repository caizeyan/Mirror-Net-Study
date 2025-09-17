using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GlobalData : NetworkBehaviour
{
    private static GlobalData instance;

    public static GlobalData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GlobalData>();
            }
            return instance;
        }
    }

    /// <summary>
    /// SyncVar  由服务器更新对应Identify的数据后，向客户端发送对应Identify更新后的信息。
    /// 如果有1,2两个玩家, 玩家1的数据发生变化,服务器会向所有客户端发送新的1玩家的数据
    /// hook为数据发生改变后客户端调用
    /// </summary>
    [SyncVar(hook = nameof(HaloCountChange))]
    public int haloCount = 0;
    
    private void HaloCountChange(int oldCount, int newCount)
    {
        Debug.LogError(gameObject.name+"  "+oldCount+" "+ newCount);
    }
}
