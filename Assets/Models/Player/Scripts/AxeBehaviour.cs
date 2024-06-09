using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Raboti");
        if (other.CompareTag("destructibleobject"))
        {
            ObstacleController obstacleController = other.GetComponent<ObstacleController>();
            if (obstacleController != null)
            {
                Debug.Log("Stigame do tuk");
                obstacleController.HitObstacle();
            }
        }
    }
}
