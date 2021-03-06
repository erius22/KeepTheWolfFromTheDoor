﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : MonoBehaviour
{

    public int speed;
    public float power;

    protected Animator animator;
    private StressManager stressManager;
    GameObject stressManagerObject;
    public GameObject particleDeath;

    public float timeBeforeHiddenMesh = 3;
    public float timeBeforeDestroyObject = 4;

    public bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
        /*if(animator == null)
        {
            animator = gameObject.GetComponentInChildren<Animator>();
        }*/
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerStay(Collider collider)
    {
        if(stressManagerObject == null)
        {
            stressManagerObject = GameObject.FindWithTag("client");
            stressManager = stressManagerObject.GetComponent<StressManager>();
        }
     
        if (collider.gameObject.tag == "zone1")
        {

            stressManager.SlowStressIncrease(power);
        }
        else
        {
            stressManager.onExitZoneStress();

        }
    }

    void OnTriggerExit(Collider other)
    {
        stressManager.onExitZoneStress();

    }


 

    public virtual void Interracted(MasterObject interractedObject)
    {
        //Debug.Log("message from enemy interacted");


    }


    /*public IEnumerator delaySpawnParticle()
    {
        isDead = true;
        GameObject particle = Instantiate(particleDeath, transform.position, transform.rotation);
        var emission = particle.GetComponent<ParticleSystem>().emission;

        /*if (this.gameObject.GetType() ==  typeof(Ghost))
        {
        }
        animator.SetTrigger("dead");

        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(timeBeforeHiddenMesh);
        emission.enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(timeBeforeDestroyObject);
        Destroy(particle);
        death();


    }*/

    void attack()
    {

    }

    public virtual void deathBomb()
    {
      
    }

    protected virtual void death()
    {
        Destroy(this.gameObject);
    }
}
