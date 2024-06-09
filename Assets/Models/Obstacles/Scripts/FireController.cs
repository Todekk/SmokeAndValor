using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float fireHealth = 100f;
    public bool isExtinguished = false;
    public ParticleSystem fireParticles;
    public ParticleSystem smokeParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireHealth <= 0f && isExtinguished == false)
        {
            StartCoroutine(RemoveFire());
        }
        
    }

    IEnumerator RemoveFire()
    {
        isExtinguished = true;
        fireParticles.Stop();
        smokeParticles.Play();
        yield return new WaitForSeconds(2);
        ObjectiveController objectiveController = FindObjectOfType<ObjectiveController>();
        objectiveController.FireExtinguished();
        Destroy(gameObject);
        
    }

    public void ExtinguishFire()
    {
        fireHealth -= 40f;        
    }
}
