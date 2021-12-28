using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _rotationSpeed = 0.01f;
    [SerializeField] private Vector3 _newPosition;
    private Vector3 _targetDirection;

    private void Start() {

        _newPosition =  new Vector3(Random.Range(0f, -3f)*3f, 0, Random.Range(-3f, 3f) * 3f);
        Debug.Log(gameObject.name + "position " + _newPosition);

    }


    private void FixedUpdate() {


        Vector3 randomMove = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));

        //moving forvard
        _targetDirection = (Target.position + _newPosition + randomMove) - transform.position;
        _targetDirection = new Vector3(_targetDirection.x, 0, _targetDirection.z);

        float distance = _targetDirection.magnitude;
        distance = Mathf.Clamp(distance, 0f, 10f);
        _rigidbody.AddForce(transform.forward * distance * _speedMultiplier, ForceMode.VelocityChange);

        //rotation
        float angle = Vector3.SignedAngle(transform.forward, _targetDirection, Vector3.up);
        _rigidbody.AddTorque(0, angle * _rotationSpeed, 0, ForceMode.VelocityChange);


    }
    private void Update() {



    }

}
