using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithMouse : MonoBehaviour
{
    Vector3 cubeScreenPos;
    Vector3 offset;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("gameController");
        StartCoroutine(OnMouseDown());
    }

    // Update is called once per frame
    void Update()
    {
        //fixed 
        if(this.transform.position.x >= 0.2f)
        {
            this.transform.position = new Vector3(0.2f, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x <= -0.2f)
        {
            this.transform.position = new Vector3(-0.2f, this.transform.position.y, this.transform.position.z);
        }
    }
    IEnumerator OnMouseDown()
    {

        cubeScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubeScreenPos.z);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        offset = transform.position - mousePos;


        while (Input.GetMouseButton(0))
        {

            Vector3 curMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubeScreenPos.z);

            curMousePos = Camera.main.ScreenToWorldPoint(curMousePos);


            transform.position = curMousePos + offset;
            yield return new WaitForFixedUpdate(); 
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            gameController.GetComponent<GameController>().addScore(other.gameObject.GetComponent<ObjectsMovement>().Score);
            other.gameObject.GetComponent<Animation>().enabled = true;
            StartCoroutine(breakObjects(other.gameObject));
            
        }
    }
    IEnumerator breakObjects(GameObject objectDestroy)
    {
        yield return new WaitForSeconds(2f);
        Destroy(objectDestroy.gameObject);
    }
}
