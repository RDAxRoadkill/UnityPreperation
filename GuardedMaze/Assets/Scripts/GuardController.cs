using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuardController : MonoBehaviour
{
    private Rigidbody rb;
    public Text winText;
    public float speed;
    public float min;
    public float max;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        min = transform.position.x;
        max = transform.position.x + 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "VerticalGuard")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, max - min) + min);
        }
        //else if (gameObject.tag == "Gate")
        //{
        //    transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.z);
        //}
        else
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(Vector3.forward * speed);
    }
    //Probably should move this to a seperate function. Instead of including this to every guard
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SetFailText();
           // Application.LoadLevel(Application.loadedLevel);
            
        }
    }
    //Probably should move this to a seperate function. Instead of including this to every guard
    void SetFailText()
    {
        winText.text = "You Lost!";
    }
}
