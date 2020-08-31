using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorPrefabs : MonoBehaviour
{
    [SerializeField] private GameObject[] m_floorPrefabs;
    [SerializeField] private Transform m_playerTrasform;

    private float m_spawnZ = 0.0f;
    private float m_floorLength = 50.0f;
    private int m_amountOfFloarOnScreen = 5;
    private int m_lastPrfabIndex = 0;
    private List<GameObject> m_activeFloor;

    // Start is called before the first frame update
    private void Start()
    {
        m_activeFloor = new List<GameObject>();
        for(int i = 0; i < m_amountOfFloarOnScreen; i++)
        {
            if(i < 2)
            {
                SpawnFloor(0);
            }
            else
            {
                SpawnFloor();
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(m_playerTrasform.position.z > (m_spawnZ - m_amountOfFloarOnScreen * m_floorLength))
        {
            SpawnFloor();
            DeleteFloor();
        }
    }

    private void SpawnFloor(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        {
            go = Instantiate(m_floorPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(m_floorPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * m_spawnZ;
        m_spawnZ += m_floorLength;
        m_activeFloor.Add(go);
    }

    private void DeleteFloor()
    {
        Destroy(m_activeFloor[0]);
        for (int i = 0; i < m_activeFloor.Count; i++)
        {
            if (m_activeFloor[i] == null)
            {
                m_activeFloor.RemoveAt(0);
            }
        }
    }

    private int RandomPrefabIndex()
    {
        if(m_floorPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = m_lastPrfabIndex;
        while(randomIndex == m_lastPrfabIndex)
        {
            randomIndex = Random.Range(0, m_floorPrefabs.Length);
        }

        m_lastPrfabIndex = randomIndex;
        return randomIndex;
    }
}
