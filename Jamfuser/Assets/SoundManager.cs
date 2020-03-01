using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private static SoundManager _instance;

    /// <summary>
    /// 
    /// </summary>
    public static SoundManager Instance
    {
        get { return _instance; }
    }
    /// <summary>
    /// 
    /// </summary>
    public AudioClip m_DeathSound;
    /// <summary>
    /// 
    /// </summary>
    public AudioClip m_collectSound;

    public AudioSource m_audioSource;
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
}
