using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviourPun
{
    [SerializeField]
    private ConfigurableJoint _joint;

    public GameObject player;

    [SerializeField]
    private Transform _pelvisTransform;

    [SerializeField]
    private float _speed;

    private Rigidbody _rigidBody;
    private Vector3 _directionVector = Vector3.zero;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField] 
    private AudioSource _source;

    [SerializeField] private PhysicalBodyPart _leftLeg;
    [SerializeField] private PhysicalBodyPart _rightLeg;
    [SerializeField] private PhysicalBodyPart _leftHand;
    [SerializeField] private PhysicalBodyPart _rightHand;

    public PhysicalBodyPart LeftLeg { get => _leftLeg; set => _leftLeg = value; }
    public PhysicalBodyPart RightLeg { get => _rightLeg; set => _rightLeg = value; }
    public PhysicalBodyPart LeftHand { get => _leftHand; set => _leftHand = value; }
    public PhysicalBodyPart RightHand { get => _rightHand; set => _rightHand = value; }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _directionVector = new Vector3(horizontal, 0, vertical);

        if (_directionVector.magnitude > Mathf.Abs(0.1f))
        {
            Vector3 moveDir = Vector3.ClampMagnitude(_directionVector, 1) * _speed;

            Quaternion rotation = Quaternion.LookRotation(_directionVector);

            _joint.targetRotation = Quaternion.Inverse(rotation);

            _rigidBody.velocity = new Vector3(moveDir.x, _rigidBody.velocity.y, moveDir.z);
            _rigidBody.angularVelocity = Vector3.zero;

            if (!_source.isPlaying) 
            {
                _source.Play();
            }
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
            _source.Stop();
        }
    }
}