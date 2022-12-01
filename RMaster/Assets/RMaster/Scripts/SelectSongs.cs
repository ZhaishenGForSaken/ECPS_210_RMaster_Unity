using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSongs : MonoBehaviour
{
    private GameObject dataController;
    // Start is called before the first frame update
    void Start()
    {
        dataController = GameObject.FindGameObjectWithTag("dataController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSongsID(int value)
    {
        dataController.GetComponent<DataControl>().setSongID(value);
        Debug.Log(dataController.GetComponent<DataControl>().getSongID());
    }
}
