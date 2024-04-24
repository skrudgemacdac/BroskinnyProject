using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    [SerializeField]
    private CharacterAnimator _characterAnimator;

    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private float _rotationSpeed = 3f;

    [SerializeField]
    private float _sensitivity = 3f;

    private float _rotationX = 0;
    private Rigidbody _rigidBody;
    private Vector3 _directionVector = Vector3.zero;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _directionVector = new Vector3(horizontal, 0, vertical);

        if (_directionVector.magnitude > Mathf.Abs(0.1f))
        {
            _characterAnimator.Move(_speed);

            if (_directionVector.magnitude > Mathf.Abs(0.05f))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_directionVector), Time.deltaTime * _rotationSpeed);
            }

            Vector3 moveDir = Vector3.ClampMagnitude(_directionVector, 1) * _speed;

            _rigidBody.velocity = new Vector3(moveDir.x, _rigidBody.velocity.y, moveDir.z);
            _rigidBody.angularVelocity = Vector3.zero;
        }
        else
        {
            _characterAnimator.Move(0);
            _rigidBody.velocity = Vector3.zero;
        }

        float mouseX = Input.GetAxis("Mouse X") * _sensitivity;
        _rotationX += mouseX;

        _rotationX = Mathf.Clamp(_rotationX, -180f, 180f);

        transform.rotation = Quaternion.Euler(0, _rotationX, 0);
    }
}