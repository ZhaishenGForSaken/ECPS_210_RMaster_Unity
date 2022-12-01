using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneController : MonoBehaviour
{
    private GameObject dataController;
    private int sceneID;

    public GameObject EndScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        dataController = GameObject.FindGameObjectWithTag("dataController");
        sceneID = 0;
        dataController.GetComponent<DataControl>().setnextSceneID(sceneID);
        score = dataController.GetComponent<DataControl>().getScore();
        EndScore.GetComponent<TMP_Text>().text = "Your score is " + score;
        dataController.GetComponent<DataControl>().setScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
