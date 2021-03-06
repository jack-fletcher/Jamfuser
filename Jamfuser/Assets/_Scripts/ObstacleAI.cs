﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum AI_Type
{
    Stationary,
    MovingHorizontal,
    MovingVertical,
    Collectable
}
public class ObstacleAI : MonoBehaviour
{
    [SerializeField] private int m_scoreToGive;
    /// <summary>
    /// The first position to pingpong between - Left or top side.
    /// </summary>
    [SerializeField] private Vector3 m_position1;
    /// <summary>
    /// The second position to pingpong between - Right or bottom side.
    /// </summary>
    [SerializeField] private Vector3 m_position2;
    /// <summary>
    /// The speed the obstacle moves at.
    /// </summary>
    [SerializeField] private float m_speed;
    /// <summary>
    /// The type of AI to implement.
    /// </summary>
    public AI_Type m_ai_type;
    // Start is called before the first frame update
    void Start()
    {
        switch (this.m_ai_type)
        {
            case AI_Type.Stationary:
                //Do nothing
                break;
            case AI_Type.MovingVertical:
                //Move vertical
                m_speed = 5;

                m_position1 = this.transform.position;
                m_position2 = this.transform.position + new Vector3(0,10,0);
                break;
            case AI_Type.MovingHorizontal:
                //Move Horizontal
                m_speed = 0.5f;
                m_position1 = new Vector3(23, this.transform.position.y, 0);
                m_position2 = new Vector3(4, this.transform.position.y, 0);
                break;
            case AI_Type.Collectable:
                //Do nothing
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.m_ai_type)
        {
            case AI_Type.Stationary:
                //Do nothing
                break;
            case AI_Type.MovingVertical:
                //Move vertical
                transform.position = Vector3.Lerp(m_position1, m_position2, Mathf.Sin(Time.time * m_speed + 1.0f));
                break;
            case AI_Type.MovingHorizontal:
                //Move Horizontal
                transform.position = Vector3.Lerp(m_position1, m_position2, Mathf.PingPong(Time.time * m_speed, 1.0f));
                break;
            case AI_Type.Collectable:
                //Do nothing
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (this.m_ai_type)
        {
            case AI_Type.Stationary:
                if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
                    this.gameObject.SetActive(false);

                }
                break;
            case AI_Type.MovingVertical:
                if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
                    this.gameObject.SetActive(false);

                }
                break;
            case AI_Type.MovingHorizontal:
                if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
                    this.gameObject.SetActive(false);

                }
                break;
            case AI_Type.Collectable:
                ScoreManager.Instance.ScoreUpdate(m_scoreToGive);
                SoundManager.Instance.m_audioSource.clip = SoundManager.Instance.m_collectSound;
                SoundManager.Instance.m_audioSource.Play();
                this.gameObject.SetActive(false);
                break;
        }
    }
}
