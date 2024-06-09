using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public RawImage fireAxeIcon;
    public RawImage fireExtinguisherIcon;
    public GameObject fireAxe;

    public BoxCollider fireAxeCollider;

    public BoxCollider feConeCollider;


    public GameObject fireExtinguisher;
    private KeyCode[] numberKeys = {
        KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2,
        KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5,
        KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8,
        KeyCode.Alpha9
    };

    // Rotation speed or angle increment per frame
    public float rotationSpeed = 100f;

    // Rotation angle for swinging
    public float swingAngle = 30f;

    // Duration of each swing in seconds
    public float swingDuration = 1f;

    private bool isSwinging = false;

    public GameObject feCone;

    // Reference to the particle system
    public ParticleSystem frParticleSystem;

    // Flag to track if the object is currently active
    private bool isExtinguishing = false;

    public
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            // Toggle the object's activation only if it's not already active
            if (!isExtinguishing)
            {
                ActivateObject();
            }
        }
        else
        {
            // If the left mouse button is not held down, deactivate the object
            if (isExtinguishing)
            {
                DeactivateObject();
            }
        }
        //Axe swing
        if (Input.GetMouseButtonDown(0) && !isSwinging)
        {
            StartCoroutine(SwingAnimationCoroutine());
        }

        //Inventory
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                PerformAction(i);
            }
        }
    }

    void ActivateObject()
    {
        if (feCone != null)
        {
            feCone.SetActive(true);
            isExtinguishing = true;

            // Start the particle system emission
            if (frParticleSystem != null)
            {
                frParticleSystem.Play();
            }

            StartCoroutine(ExtinguishFireRoutine());
        }
    }

    IEnumerator ExtinguishFireRoutine()
    {
        while (isExtinguishing)
        {
            Collider[] colliders = Physics.OverlapBox(feCone.transform.position, feConeCollider.bounds.extents, feCone.transform.rotation);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("fire"))
                {
                    // Check if the collider has a component with ExtinguishFire() method
                    FireController fireController = collider.GetComponent<FireController>();
                    if (fireController != null)
                    {
                        // Call the ExtinguishFire method
                        fireController.ExtinguishFire();
                    }
                }
            }

            yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds before checking again
        }
    }

    void DeactivateObject()
    {
        if (feCone != null)
        {
            feCone.SetActive(false);
            isExtinguishing = false;

            // Stop the particle system emission
            if (frParticleSystem != null)
            {
                frParticleSystem.Stop();
            }
        }
    }

    IEnumerator SwingAnimationCoroutine()
    {
        isSwinging = true;

        float step = rotationSpeed * Time.deltaTime;
        float targetRotation = fireAxe.transform.rotation.eulerAngles.x + swingAngle;

        while (fireAxe.transform.rotation.eulerAngles.x < targetRotation)
        {
            fireAxe.transform.Rotate(Vector3.right * step);
            yield return null;
        }

        Collider collider = CheckForCollisionWithTag("destructibleobject");
        if (collider != null)
        {
            ObstacleController obstacleController = collider.GetComponent<ObstacleController>();
            if (obstacleController != null)
            {
                obstacleController.HitObstacle();
            }
        }

        yield return new WaitForSeconds(swingDuration / 2f);

        targetRotation = fireAxe.transform.rotation.eulerAngles.x - swingAngle;
        while (fireAxe.transform.rotation.eulerAngles.x > targetRotation)
        {
            fireAxe.transform.Rotate(-Vector3.right * step);
            yield return null;
        }

        isSwinging = false;
    }

    void PerformAction(int number)
    {
        switch (number)
        {
            case 0:

                break;
            case 1:
                ChangeRawImageColor(fireAxeIcon, fireExtinguisherIcon);
                fireExtinguisher.SetActive(false);
                fireAxe.SetActive(true);
                break;
            case 2:
                ChangeRawImageColor(fireExtinguisherIcon, fireAxeIcon);
                fireAxe.SetActive(false);
                fireExtinguisher.SetActive(true);
                break;
            case 3:
                Debug.Log("Number 3 key was pressed!");
                // Action for number 3
                break;
            case 4:
                Debug.Log("Number 4 key was pressed!");
                // Action for number 4
                break;
            case 5:
                Debug.Log("Number 5 key was pressed!");
                // Action for number 5
                break;
            case 6:
                Debug.Log("Number 6 key was pressed!");
                // Action for number 6
                break;
            case 7:
                Debug.Log("Number 7 key was pressed!");
                // Action for number 7
                break;
            case 8:
                Debug.Log("Number 8 key was pressed!");
                // Action for number 8
                break;
            case 9:
                Debug.Log("Number 9 key was pressed!");
                // Action for number 9
                break;
            default:
                Debug.Log("Unknown key pressed");
                break;
        }
    }

    Collider CheckForCollisionWithTag(string tag)
    {
        Collider[] colliders = Physics.OverlapBox(fireAxe.transform.position, fireAxeCollider.bounds.extents, fireAxe.transform.rotation);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return collider;
            }
        }
        return null;
    }

    void ChangeRawImageColor(RawImage activeIcon, RawImage inactiveIcon)
    {
        //TO DO - inactiveIcon da se napravi array ako stanat poveche
        activeIcon.enabled = true;

        inactiveIcon.enabled = false;
    }
}
