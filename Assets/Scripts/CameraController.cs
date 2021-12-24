using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float LerpRate;
    private void Update() {
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * LerpRate);
    }
}
