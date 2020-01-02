using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public GameObject CameraArm;

    float rotationSpeed = 125.0f;
    float translationSpeed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Translation
        if (Input.GetKey(KeyCode.A))
        {
            CameraArm.transform.Translate(Vector3.left * translationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CameraArm.transform.Translate(Vector3.right * translationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            CameraArm.transform.Translate(Vector3.forward * translationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            CameraArm.transform.Translate(Vector3.back * translationSpeed * Time.deltaTime, Space.Self);
        }

        // Rotation
        if (Input.GetKey(KeyCode.E))
        {
            // WorldController.transform.Rotate(0, 125.0f * Time.deltaTime, 0);
            CameraArm.transform.RotateAround(CameraArm.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.Q))
        {
            // WorldController.transform.Rotate(0, 125.0f * Time.deltaTime, 0);
            CameraArm.transform.RotateAround(CameraArm.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
        }
    }
}
