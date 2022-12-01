using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour
{
    public static DataControl instance;
    private int songID;
    private int difficulty;
    private int score;
    private int nextSceneID;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        nextSceneID = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getSongID()
    {
        return songID;
    }
    public void setSongID(int num)
    {
        songID = num;
    }
    public int getDifficulty()
    {
        return difficulty;
    }
    public void setDifficulty(int num)
    {
        difficulty = num;
    }
    public int getScore()
    {
        return score;
    }
    public void setScore(int num)
    {
        score = num;
    }
    public int getnextSceneID()
    {
        return nextSceneID;
    }
    public void setnextSceneID(int num)
    {
        nextSceneID = num;
    }
}
