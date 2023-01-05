using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹들 보관할 변수필요
    // 풀 담당하는 프리팹별 리스트 필요
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int index=0; index<pools.Length; index++)
        {
            pools[index] = new List<GameObject>(); // 초기화
        }        
    }

    public GameObject Get(int index) // GameObject를 반환하는 함수
    {
        GameObject select = null;

        // 선택한 풀에 있는(비활성화 된) GameObject에 접근
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf) // 접근했을때 select변수에 할당
            {
                select= item;
                select.SetActive(true);

                break;
            }        
        }
        
        // 못찾았을 때
        if(select == null)//=(!select)
        { 
            // 새롭게 생성해서 select에 할당
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;

    }
}
