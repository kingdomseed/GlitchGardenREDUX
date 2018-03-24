using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker att = collision.gameObject.GetComponent<Attacker>();

        if(att)
        {
            anim.SetTrigger("underAttackTrigger");
        }
        
    }

}
