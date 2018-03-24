using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker att;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        att = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if(!obj.GetComponent<Defender>())
        {
            return;
        }
        
        if(obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jumpTrigger");
        } else
        {
            anim.SetBool("isAttacking", true);
            att.Attack(obj);
        }

    }

}
