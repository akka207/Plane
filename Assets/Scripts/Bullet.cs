using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = CanonBv.bulletSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () 
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
        if(transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
