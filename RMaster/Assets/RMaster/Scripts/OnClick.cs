using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    private GameObject dataController;
    private int sceneID;
    // Start is called before the first frame update
    void Start()
    {
        dataController = GameObject.FindGameObjectWithTag("dataController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        sceneID = dataController.GetComponent<DataControl>().getnextSceneID();
        SceneManager.LoadScene(sceneID);
    }

}
