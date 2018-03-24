using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;
    private float currentSpeed;
    private Animator anim;
    private GameObject currentTarget;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if(currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.GetDamage(damage);
            }
        }
        
    }

    // 
    public void Attack (GameObject obj)
    {
        currentTarget = obj;
    }
}
