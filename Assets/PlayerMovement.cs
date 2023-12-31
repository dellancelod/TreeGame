using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private FloatingJoystick joystick;

    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float rotationSpeed;

    private Rigidbody rigidBody;

    private Vector3 moveVector;

    AnimatorController animatorController; 
    BreakController breakController;

    private void Awake()
    {
        animatorController = GetComponent<PlayerControllers>().GetAnimatorController();
        breakController = GetComponent<PlayerControllers>().GetBreakController();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

        if((joystick.Horizontal != 0 || joystick.Vertical != 0) && !breakController.GetBreakingState())
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            if (joystick.Horizontal > -0.5 && joystick.Vertical > -0.5 
                && joystick.Horizontal < 0.5 && joystick.Vertical < 0.5)
            {
                animatorController.PlayWalk();
            }
            else
            {
                animatorController.PlayRun();
            }
        }

        else if ((joystick.Horizontal == 0 || joystick.Vertical == 0) && !breakController.GetBreakingState())
        {
            animatorController.PlayIdle();
        }
        rigidBody.MovePosition(rigidBody.position + moveVector);

    }
}
