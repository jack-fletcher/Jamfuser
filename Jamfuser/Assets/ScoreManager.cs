using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private static ScoreManager _instance;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private TextMeshProUGUI m_scoreText;

    public bool isFalling = false;
    /// <summary>
    /// 
    /// </summary>
    public static ScoreManager Instance
    {
        get { return _instance; }
    }
    /// <summary>
    /// 
    /// </summary>
    private int m_score = 0;

    public int m_highScore;
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
        m_scoreText.text = "Score: 0";

    }
    /// <summary>
    /// 
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        ScoreUpdate(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return m_score;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_score"></param>
    public void SetScore(int _score)
    {
        m_score = _score;
    }

    public void ScoreUpdate(int addition)
    {

        if (isFalling == true)
        {
            m_score++;
            m_score += addition;
            m_scoreText.text = "Score: " + m_score;
        }
        if (m_score > m_highScore)
        {
            m_highScore = m_score;
        }
    }


}
