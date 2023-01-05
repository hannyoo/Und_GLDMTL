using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �����յ� ������ �����ʿ�
    // Ǯ ����ϴ� �����պ� ����Ʈ �ʿ�
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int index=0; index<pools.Length; index++)
        {
            pools[index] = new List<GameObject>(); // �ʱ�ȭ
        }        
    }

    public GameObject Get(int index) // GameObject�� ��ȯ�ϴ� �Լ�
    {
        GameObject select = null;

        // ������ Ǯ�� �ִ�(��Ȱ��ȭ ��) GameObject�� ����
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf) // ���������� select������ �Ҵ�
            {
                select= item;
                select.SetActive(true);

                break;
            }        
        }
        
        // ��ã���� ��
        if(select == null)//=(!select)
        { 
            // ���Ӱ� �����ؼ� select�� �Ҵ�
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;

    }
}
