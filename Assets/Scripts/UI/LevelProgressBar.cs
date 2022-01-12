using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _levelProgressBarSlider;
    [SerializeField] private Transform _trainTransform;
    [SerializeField] private Transform _finishTransform;
    private float _fullDistanceToFinish;
    private float _currentDistanceToFinish;


    private void Start() {
        _fullDistanceToFinish = Vector3.SqrMagnitude(_finishTransform.position - _trainTransform.position);
    }


    private void Update() {
        _currentDistanceToFinish = Vector3.SqrMagnitude(_finishTransform.position - _trainTransform.position);
        _levelProgressBarSlider.value = (_fullDistanceToFinish - _currentDistanceToFinish) / _fullDistanceToFinish;

    }

}
