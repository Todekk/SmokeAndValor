using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float obstacleHealth = 100f;
    public BoxCollider doorCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obstacleHealth == 0f)
        {
            doorCollider.enabled = true;
            Destroy(gameObject);
        }
        
    }

    public void HitObstacle()
    {
        obstacleHealth -= 20f;     
    }
}
