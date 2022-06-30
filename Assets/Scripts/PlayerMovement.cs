using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateSpeed = 300f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation(){
         rb.freezeRotation = true;
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
         rb.freezeRotation = false;
    }
}
