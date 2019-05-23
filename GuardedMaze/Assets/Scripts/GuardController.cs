using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardController : MonoBehaviour
{
    private Rigidbody rb;
    public Text winText;
    public float speed;
    public float min = 2f;
    public float max = 3f;

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
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(Vector3.forward * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SetFailText();
        }
    }

    void SetFailText()
    {
        winText.text = "You Lost";
    }
}
