using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.02f * Time.deltaTime;

        direction.z = forwardSpeed;

        controller.Move(direction * Time.deltaTime);
    }
}
