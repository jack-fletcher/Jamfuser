using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    private static GameStageManager _instance;

    public static GameStageManager Instance
    {
        get { return _instance; }   
    }

    /// <summary>
    /// object to repeat
    /// </summary>
    [SerializeField] private GameObject m_gameStage;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private BoxCollider2D m_hitCollider;


    private void Awake()
    {
        if (Instance != null & !this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnCollision()
    {
        float _gameStageY = m_gameStage.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        Vector3 _pos = m_gameStage.transform.position;
        float _newPosY = _pos.y - _gameStageY;
        _pos.y = _newPosY;
        GameObject go = Instantiate(m_gameStage, _pos, Quaternion.identity);
        go.name = "GameStage";
        m_gameStage = go;
    }
}
