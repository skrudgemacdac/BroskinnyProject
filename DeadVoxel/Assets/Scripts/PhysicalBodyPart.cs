using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]

public class PhysicalBodyPart : MonoBehaviour
{

    [SerializeField]private Transform _target;
    private ConfigurableJoint _joint;
    private Quaternion _startRotation;

    public Transform Target { get => _target; set => _target = value; }

    void Start()
    {
        _joint = GetComponent<ConfigurableJoint>();
        _startRotation = transform.localRotation;
    }

    void FixedUpdate()
    {
        _joint.targetRotation = Quaternion.Inverse(Target.localRotation) * _startRotation;
    }
}
