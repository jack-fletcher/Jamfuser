using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIUpdater : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI m_score;
    [SerializeField]private TextMeshProUGUI m_highscore;
    // Update is called once per frame
    void Update()
    {
        m_score.text = "Score: " + Convert.ToString(ScoreManager.Instance.GetScore());
        m_highscore.text = "HighScore: " + Convert.ToString(ScoreManager.Instance.m_highScore);
    }
}
