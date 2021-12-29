using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider) {
        MoveTrain moveTrain = collider.attachedRigidbody?.GetComponent<MoveTrain>();

        if (moveTrain) {
            moveTrain.Speed = 0f;
            Debug.Log("TrainStopped");
        }

    }
}
