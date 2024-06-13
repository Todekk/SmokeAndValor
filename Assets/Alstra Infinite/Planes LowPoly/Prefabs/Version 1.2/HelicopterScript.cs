using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour
{
    public GameObject rotorBlade1;
    public float spinSpeed = 10000f; // Speed of rotation in degrees per second
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        // Rotate the object around the Y axis based on spinSpeed
        rotorBlade1.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
