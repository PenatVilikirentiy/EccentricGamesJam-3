using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public TrainWagon _currentTarget;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _rotationSpeed = 0.01f;
    [SerializeField] private Vector3 _randomPosition;
    private Vector3 _targetDirection;




    private void Start() {

        //Target = GameObject.FindObjectOfType<MoveTrain>().transform;

        _setRandomPosition();
        //Debug.Log(gameObject.name + "position " + _randomPosition);

    }

    public void _getTarget(TrainWagon currentTarget) {
         _currentTarget = currentTarget;
    }


    private void FixedUpdate() {
        if (_currentTarget.IsActive == true) {

            Vector3 randomMove = new Vector3(0, 0, Random.Range(-0.2f, 0.2f));

            //moving forvard
            _targetDirection = (_currentTarget.transform.position + _randomPosition + randomMove) - transform.position;
            _targetDirection = new Vector3(_targetDirection.x, 0, _targetDirection.z);

            float distance = _targetDirection.magnitude;
            distance = Mathf.Clamp(distance, 0f, 10f);
            _rigidbody.AddForce(transform.forward * distance * _speedMultiplier, ForceMode.VelocityChange);

            //rotation
            float angle = Vector3.SignedAngle(transform.forward, _targetDirection, Vector3.up);
            _rigidbody.AddTorque(0, angle * _rotationSpeed, 0, ForceMode.VelocityChange);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<EnemyMove>()) {
            _moveAway();
                //Debug.Log("Colided with enemy");
        }
    }


    private void _moveAway() {
        _randomPosition =  new Vector3(Random.Range(-1f, -4f)*3f, 0, _randomPosition.z);
        //Debug.Log(gameObject.name + "position " + _randomPosition);
        //_rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation, Quaternion.identity, 1);

    }
    private void _setRandomPosition() {
        _randomPosition = new Vector3(Random.Range(-1f, -4f) * 3f, 0, Random.Range(-5f, 1f) * 3f);
        //Debug.Log(gameObject.name + "position " + _randomPosition);

    }



}
