using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPos;
    public float YIncrement;
    public float speed;

    //public Animator camAnim;

    public float maxHeight;
    public float minHeight;

    public int health = 3;
    public GameObject effect;
    public Text healthDisplay;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + YIncrement);
            //camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - YIncrement);
            //camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
