using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public float topSpeed;
    private float currentSpeed = 0;
    private float pitch = 1f;
    [SerializeField] private float _pitchControl = 1f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Rigidbody _rigidbody;

    void Update() {

        currentSpeed = _rigidbody.velocity.magnitude;

        if (currentSpeed > topSpeed) {
            currentSpeed = topSpeed;
        }


         pitch = Mathf.Clamp(currentSpeed * 2f / topSpeed , 0.5f, 3f);
        _audioSource.pitch = pitch * _pitchControl;


        //Debug.Log("currentSpeed" + currentSpeed);
        //Debug.Log("topSpeed" + topSpeed);
        //Debug.Log("pitch" + pitch);
    }
}
