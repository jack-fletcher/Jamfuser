using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator m_deathScreenAnim;
    /// <summary>
    /// Health of player
    /// </summary>
    [SerializeField] private float m_health;
    /// <summary>
    /// Drop speed of player
    /// </summary>
    [SerializeField] private float m_speed;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Sprite[] m_playerSprites;

    [SerializeField] private List<string> m_tagsToRaycast;
    private float m_xf;

    /// <summary>
    /// Equivalent to our gravity value
    /// </summary>
    private float m_yf;

    private float m_zf;

    private Vector2 m_velocity;

    private Rigidbody2D m_rb;
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        m_rb = this.GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Pose();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Movement()
    {
            bool _isFalling = isFalling();

            if (_isFalling == true)
            {
            ScoreManager.Instance.isFalling = true;            }
            else
            {
            ScoreManager.Instance.isFalling = false;
            }

            m_xf = Input.GetAxis("Horizontal");
            m_velocity = new Vector3(m_xf * m_speed, m_yf);
            m_rb.velocity = m_velocity;
     
    }

    /// <summary>
    /// Check if falling
    /// </summary>
    /// <returns></returns>
    private bool isFalling()
    {
        //check floor for raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);


        if (m_tagsToRaycast.Contains(hit.collider.tag))
        { 

            return false;
        }
        return true;
    }


    private void Pose()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q pressed");
            GetComponent<SpriteRenderer>().color = Color.red;
            ScoreManager.Instance.ScoreUpdate(5);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");

            GetComponent<SpriteRenderer>().color = Color.green;
            ScoreManager.Instance.ScoreUpdate(8);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W pressed");

            // GetComponent<SpriteRenderer>().color = Color.yellow;
            //ScoreManager.Instance.ScoreUpdate(10);
            Debug.Log(ScoreManager.Instance.m_highScore);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("W pressed");

            TakeDamage(1);

        }
    }


    public void TakeDamage(int damage)
    {
        m_health -= damage;
        if (m_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ///Do Death
        this.gameObject.SetActive(false);
        ScoreManager.Instance.isFalling = false;
        Serialization.Instance.SaveData();
        m_deathScreenAnim.SetTrigger("isDead");
    }
}
