using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private GameObject dataController;
    public GameObject difficultyBar;
    private int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        dataController = GameObject.FindGameObjectWithTag("dataController");
        dataController.GetComponent<DataControl>().setnextSceneID(1);

    }

    // Update is called once per frame
    void Update()
    {
        difficulty = (int)difficultyBar.GetComponent<Slider>().value;
        //Debug.Log(difficulty);
        dataController.GetComponent<DataControl>().setDifficulty(difficulty);
    }
}
