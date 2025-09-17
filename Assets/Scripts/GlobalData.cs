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
    /// SyncVar  �ɷ��������¶�ӦIdentify�����ݺ���ͻ��˷��Ͷ�ӦIdentify���º����Ϣ��
    /// �����1,2�������, ���1�����ݷ����仯,�������������пͻ��˷����µ�1��ҵ�����
    /// hookΪ���ݷ����ı��ͻ��˵���
    /// </summary>
    [SyncVar(hook = nameof(HaloCountChange))]
    public int haloCount = 0;
    
    private void HaloCountChange(int oldCount, int newCount)
    {
        Debug.LogError(gameObject.name+"  "+oldCount+" "+ newCount);
    }
}
