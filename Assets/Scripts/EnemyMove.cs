using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform Target;
    public Rigidbody TrainRigidbody;
    [SerializeField] private Rigidbody _rigidbody;
    private Vector3 _targetDirection;


    private void FixedUpdate() {


        //float distance = Mathf.Clamp(Vector3.Distance(_targetDirection, transform.position), 1f, 3f);
        //_rigidbody.velocity = Vector3.Scale(_targetDirection.normalized, TrainRigidbody.velocity);
        //_rigidbody.AddForce(Vector3.ClampMagnitude(_targetDirection, 5f) , ForceMode.VelocityChange);
        //_rigidbody.velocity = _targetDirection* (TrainRigidbody.velocity - _rigidbody.velocity);

        _rigidbody.velocity = _targetDirection;


        // _rigidbody.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetDirection), Time.deltaTime * 15f);
        Vector3 directionZ = new Vector3(0, 0, _targetDirection.z);
        _rigidbody.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionZ), Time.deltaTime * 3f);  
    }

    private void Update() {

        _targetDirection = Target.position - transform.position;
      

    }

}
