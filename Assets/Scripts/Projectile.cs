using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker att = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();
        if(att && health)
        {
            health.GetDamage(damage);
            Destroy(gameObject);
        }
    }

}