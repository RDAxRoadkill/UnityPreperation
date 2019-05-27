using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public float lifetime;
    
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: Optimize this, can be way easier
        if (other.CompareTag("EnemySquare") && gameObject.tag == "SquareProjectile")
        {
            Destroy(other.gameObject);
            DestroyGameObject();
        } else if (other.CompareTag("EnemyCircle") && gameObject.tag == "CircleProjectile")
        {
            Destroy(other.gameObject);
            DestroyGameObject();
        } else if (other.CompareTag("EnemyTriangle") && gameObject.tag == "TriangleProjectile")
        {
            Destroy(other.gameObject);
            DestroyGameObject();
        }
    }

    void DestroyGameObject(){
        //Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
