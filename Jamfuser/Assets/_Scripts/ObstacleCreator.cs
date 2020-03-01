using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject[] m_obstacleLocationsY;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject[] m_obstaclesToSpawn;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private int m_rightLimit;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private int m_leftLimit;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in m_obstacleLocationsY)
        {
            int posX = Random.Range(m_leftLimit, m_rightLimit);
            int obstacleidx = Random.Range(0, m_obstaclesToSpawn.Length);

           GameObject _go = Instantiate(m_obstaclesToSpawn[obstacleidx], new Vector3(posX, go.transform.position.y, go.transform.position.z), Quaternion.identity);
            //_go.AddComponent<ObstacleAI>();
            //_go.GetComponent<ObstacleAI>().m_ai_type = (AI_Type)Random.Range(0,3);
            //_go.AddComponent<BoxCollider2D>();
        }
    }

}