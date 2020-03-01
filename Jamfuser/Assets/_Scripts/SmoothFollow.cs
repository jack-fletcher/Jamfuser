using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{

    [SerializeField] private Transform m_target;

    private Vector3 m_targetOffset;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float target_distance; 
    [SerializeField] private float m_smoothTime;
    private 
    // Start is called before the first frame update
    void Start()
    {
        m_targetOffset = transform.position - m_target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, m_target.position+m_targetOffset, m_smoothTime);
    }
}
