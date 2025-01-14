using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;  // en el editor, referencia a la c�mara

    /* Factor de velocidad de rotaci�n del personaje */
    public float rotSpeed = 15.0f;

    /* Velocidad de movimiento del personaje */
    public float moveSpeed = 6.0f;
    private CharacterController _charController;

    /* Par�metros de movimiento vertical */
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;

    private float _vertSpeed;

    private ControllerColliderHit _contact;

    private Animator _animator;
    (Vector3 from, Vector3 to) StepCheck()
    {
        return (transform.position + Vector3.up * _charController.radius / 2,
                transform.position + Vector3.down * _charController.radius / 2);
    }

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput;
            movement.z = vertInput;
            movement = Vector3.ClampMagnitude(movement * moveSpeed, moveSpeed);
            Quaternion rot = Quaternion.Euler(0, target.eulerAngles.y, 0);
            movement = rot * movement;
            //transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

        }

        _animator?.SetFloat("Speed", movement.sqrMagnitude);

        bool hitGround = false;
        RaycastHit hit;
        (Vector3 from, Vector3 to) = StepCheck();
        if (_vertSpeed < 0 && Physics.Linecast(from, to, out hit))
        {
            hitGround = true;
        }

        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;
                _animator?.SetBool("Jumping", false);
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }
            _animator?.SetBool("Jumping", true);
            if (_charController.isGrounded)  //EN LA DIAPO EST� EDITADO
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * moveSpeed;
                }
                else
                {
                    movement += _contact.normal * moveSpeed;
                }
            }
        }
        movement.y = _vertSpeed;
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }


    private void OnDrawGizmos()
    {
        if (_charController != null)
        {
            Gizmos.color = Color.red;
            (Vector3 from, Vector3 to) = StepCheck();
            Gizmos.DrawLine(from, to);
        }
    }
}
