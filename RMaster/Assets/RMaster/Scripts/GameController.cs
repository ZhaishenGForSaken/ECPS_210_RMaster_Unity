using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using TMPro;
using UnityEngine.SceneManagement;
using SonicBloom.Koreo.Players;

public class GameController : MonoBehaviour
{
    public int Score;
    public GameObject ScoreTexture;
    public GameObject[] objects;
    public int NumOfLocation;
    public GameObject[] Locations;
    [EventID]
    private string eventID;

    public Koreography[] koreography;

    private GameObject dataController;
    private GameObject audioPlayer;
    private int songsID;
    // Start is called before the first frame update
    void Start()
    {
        dataController = GameObject.FindGameObjectWithTag("dataController");
        audioPlayer = GameObject.FindGameObjectWithTag("audioPlayer");
        Score = dataController.GetComponent<DataControl>().getScore();
        dataController.GetComponent<DataControl>().setnextSceneID(2);
        songsID = dataController.GetComponent<DataControl>().getSongID();
        if(songsID == 0)
        {
            eventID = "SadTripA";
        }
        else if(songsID == 1)
        {
            eventID = "SadTripB";
        }
        audioPlayer.GetComponent<SimpleMusicPlayer>().LoadSong(koreography[songsID]);
        changeScoreTexture();
        Koreographer.Instance.RegisterForEvents(eventID, instantiateObjects);
        StartCoroutine(endScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int num)
    {
        Score += num;
        dataController.GetComponent<DataControl>().setScore(Score);
        changeScoreTexture();
        return;
    }
    private void changeScoreTexture()
    {
        ScoreTexture.GetComponent<TMP_Text>().text = "Now Score =" + Score;
    }
    void instantiateObjects(KoreographyEvent evt)
    {
        if(evt.GetTextValue() == "1")
        {
            Debug.Log("1");
            Instantiate(objects[Random.Range(0,objects.Length)], Locations[0].transform);
        }
        if (evt.GetTextValue() == "2")
        {
            Instantiate(objects[Random.Range(0, objects.Length)], Locations[1].transform);
            Debug.Log("2");
        }
    }

    IEnumerator endScene()
    {
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene(dataController.GetComponent<DataControl>().getnextSceneID());
    }

}
