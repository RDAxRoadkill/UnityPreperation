using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject square;
    public GameObject triangle;
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Optimize this
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Instantiate(square, transform.position, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Instantiate(triangle, transform.position, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Instantiate(circle, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("EnemySquare") || other.CompareTag("EnemyCircle") || other.CompareTag("EnemyTriangle"))
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(int obstacle)
    {
        Debug.Log("Pew Pew" + obstacle);
        if(obstacle == 0)
        {
            Instantiate(square, transform.position, Quaternion.identity);
        } else if (obstacle == 1)
        {
            Instantiate(triangle, transform.position, Quaternion.identity);
        } else if (obstacle == 2)
        {
            Instantiate(circle, transform.position, Quaternion.identity);
        }
        
    }
}
