using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public class Serialization : MonoBehaviour
{
    private static Serialization _instance;

    public static Serialization Instance
    {
        get { return _instance; }
    }

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
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveData()
    {
        PlayerData _data = new PlayerData();
        _data.highscore = ScoreManager.Instance.m_highScore;

        FileStream _fs = new FileStream("Saves\\Highscore.cat", FileMode.Create);
        BinaryFormatter _bf = new BinaryFormatter();

            _bf.Serialize(_fs, _data);
            _fs.Close();
        
    }

    public void LoadData()
    {
        if (File.Exists("Saves\\Highscore.cat"))
        {
            BinaryFormatter _bf = new BinaryFormatter();
            FileStream _fs = new FileStream("Saves\\Highscore.cat", FileMode.Open, FileAccess.Read, FileShare.Read);
            PlayerData _data = (PlayerData)_bf.Deserialize(_fs);
            ScoreManager.Instance.m_highScore = _data.highscore;
            _fs.Close();
        }
        else
        {
            SaveData();
            LoadData();
        }
    }
    
}

[System.Serializable]
public class PlayerData
{   /// <summary>
    /// 
    /// </summary>
    public int highscore = 0;
}