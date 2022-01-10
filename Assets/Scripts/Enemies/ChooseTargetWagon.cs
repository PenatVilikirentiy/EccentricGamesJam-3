using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTargetWagon : MonoBehaviour {
    private TrainWagon[] _targets;
    public Transform CurrentTarget;

    private void Start() {
        _targets = FindObjectsOfType<TrainWagon>();
        SetTarget();
    }

    public void SetTarget() {
        CurrentTarget = _targets[Random.Range(0, _targets.Length)]?.transform;
    }

}
