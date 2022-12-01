using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    private float movementSpeed;
    public float timeToDestroy;
    private Rigidbody rigidbody;
    public int Score;
    private GameObject dataController;
    // Start is called before the first frame update
    void Start()
    {
        dataController = GameObject.FindGameObjectWithTag("dataController");
        movementSpeed = dataController.GetComponent<DataControl>().getDifficulty();
        Score = 100;
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0, 0, -(float)(5.0 * (movementSpeed + 1)));
        StartCoroutine(fadeout());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fadeout()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(this.gameObject);
        Debug.Log("Des");
    }
}
