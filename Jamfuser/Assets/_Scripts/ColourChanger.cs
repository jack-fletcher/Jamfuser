using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColourChanger : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private static ColourChanger _instance;

    /// <summary>
    /// 
    /// </summary>
    public static ColourChanger Instance
    {
        get { return _instance; }
    }

    [SerializeField] private TextMeshProUGUI m_titleText;
    [SerializeField] private int m_selectedIndex;
    [SerializeField] private Image m_image;
    [SerializeField] private Slider m_redSlider;
    [SerializeField] private Slider m_blueSlider;
    [SerializeField] private Slider m_greenSlider;
    [SerializeField] private Slider m_alphaSlider;


    private Color _color;

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
        OnSliderChange();
        OnBtnSelectChange(0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnBtnSelectChange(int change)
    {
        if (m_selectedIndex + change < 0)
        {
            m_selectedIndex = PlayerController.Instance.m_bodyParts.Length - 1;
        }
        else if (m_selectedIndex + change < PlayerController.Instance.m_bodyParts.Length)
        {
            m_selectedIndex += change;
        }
        else
        {
            m_selectedIndex = 0;
        }
        m_image.color = PlayerController.Instance.m_colours[m_selectedIndex];
        m_redSlider.value = PlayerController.Instance.m_colours[m_selectedIndex].r;
        m_greenSlider.value = PlayerController.Instance.m_colours[m_selectedIndex].g;
        m_blueSlider.value = PlayerController.Instance.m_colours[m_selectedIndex].b;
        m_alphaSlider.value = PlayerController.Instance.m_colours[m_selectedIndex].a;

        m_titleText.text = PlayerController.Instance.m_bodyParts[m_selectedIndex].name + " Colour";
    }

    /// <summary>
    /// Saves the colour 
    /// </summary>
    /// <param name="idx"></param>
    public void OnColourBtnChange()
    {
        PlayerController.Instance.m_colours[m_selectedIndex] = _color;
        PlayerController.Instance.SetColour();
    }

    public void OnSliderChange()
    {
        _color = new Color();
        _color.r = m_redSlider.value;
        _color.g = m_greenSlider.value;
        _color.b = m_blueSlider.value;
        _color.a = m_alphaSlider.value;

        m_image.color = _color;
    }
}
