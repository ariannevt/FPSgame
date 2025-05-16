using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_demo1 : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 9.8f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController m_CharacterController;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (m_CharacterController.isGrounded)
            moveDirection = Vector3.forward * speed;

        moveDirection.y -= gravity * Time.deltaTime;

        m_CharacterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // don't move the rigidbody if the character is on top of it
        if (m_CharacterController.collisionFlags == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }

        body.AddForceAtPosition(m_CharacterController.velocity * 0.1f,
                                hit.point,
                                ForceMode.Impulse);
    }
}
