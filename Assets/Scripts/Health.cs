using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float hp = 100f;

    public void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // Optionally trigger animation
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
