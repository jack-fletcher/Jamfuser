using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    private static PlayerController _instance;

    /// <summary>
    /// 
    /// </summary>
    public static PlayerController Instance
    {
        get { return _instance; }
    }

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
    [SerializeField] public Color[] m_colours;
    [SerializeField] public GameObject[] m_bodyParts;
    [SerializeField] private List<string> m_tagsToRaycast;
    [SerializeField] private Animator m_anim;
    private bool m_coroutine_Running = false;
    private float m_xf;
    private float _timer = 1.0f;
    /// <summary>
    /// Equivalent to our gravity value
    /// </summary>
    [SerializeField] private float m_yf;

    private float m_zf;

    private Vector2 m_velocity;

    private Rigidbody2D m_rb;
    /// <summary>
    /// 
    /// </summary>
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

        m_rb = this.GetComponent<Rigidbody2D>();
        m_anim = this.GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        SetColour();
    }

    public void SetColour()
    {
        for (int i = 0; i < m_bodyParts.Length; i++)
        {
            if (m_colours[i] != null)
            {
                m_bodyParts[i].GetComponent<SpriteRenderer>().color = m_colours[i];
            }
        }
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
            ScoreManager.Instance.isFalling = true;
            float yv = transform.rotation.z + 3;
            transform.Rotate(0, 0, yv );

                if (Time.time >= _timer)
                {
                    m_yf--;
                    _timer = Mathf.FloorToInt(Time.time) + 1;
                }
                
              }
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
        if (!m_coroutine_Running)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                //  GetComponent<SpriteRenderer>().color = Color.red;
                ScoreManager.Instance.ScoreUpdate(5);
                StartCoroutine("ResetPose", "Tpose");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {


                // GetComponent<SpriteRenderer>().color = Color.green;
                ScoreManager.Instance.ScoreUpdate(8);
                StartCoroutine("ResetPose", "Ultimate Pose");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Ballet");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                //  GetComponent<SpriteRenderer>().color = Color.red;
                ScoreManager.Instance.ScoreUpdate(5);
                StartCoroutine("ResetPose", "Dab");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {


                // GetComponent<SpriteRenderer>().color = Color.green;
                ScoreManager.Instance.ScoreUpdate(8);
                StartCoroutine("ResetPose", "Karate");
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Chill");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Relaxed");
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {


                // GetComponent<SpriteRenderer>().color = Color.green;
                ScoreManager.Instance.ScoreUpdate(8);
                StartCoroutine("ResetPose", "Meditate");
            }

            if (Input.GetKeyDown(KeyCode.X))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Superman");
            }

            if (Input.GetKeyDown(KeyCode.C))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Flex");
            }
            if (Input.GetKeyDown(KeyCode.V))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Swim");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Ice Skate");
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Crane");
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Praise");
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {

                // GetComponent<SpriteRenderer>().color = Color.yellow;
                ScoreManager.Instance.ScoreUpdate(10);
                StartCoroutine("ResetPose", "Run");
            }
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {

            TakeDamage(1);

        }
    
#endif
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

    IEnumerator ResetPose(string name)
    {
        m_coroutine_Running = true;
        m_anim.SetTrigger(name);
        yield return new WaitForSeconds(1f);
        m_coroutine_Running = false;
        m_anim.ResetTrigger(name);
    }
}
