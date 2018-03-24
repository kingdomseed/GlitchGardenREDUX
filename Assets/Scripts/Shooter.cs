using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public GameObject projectile, launcher;
    private Animator anim;
    private GameObject projectileParent;
    private Spawner myLaneSpawner;

    private void Start()
    {
        anim = GameObject.FindObjectOfType<Animator>();

        // Creates a parent if necessary
        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        // Tells the shooter which Spawner is his Spawner.
        SetMyLaneSpawner();
    }

    private void Update()
    {
        if(IsAttackerAhead())
        {
            anim.SetBool("isAttacking", true);
        } else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + "Can't find spawner in lane.");
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = launcher.transform.position;
    }

    private bool IsAttackerAhead()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        // If their are attackers in lane, are they in front of us?
        foreach(Transform attackers in myLaneSpawner.transform)
        {
            if(attackers.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        // Attackers in lane but behind us
        return false;
    }
    
}
