using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Transform _cameraTarget;
    [SerializeField] private Image HealthBarImage;


    private void Start() {;
        _cameraTarget = Camera.main.transform;
    }

    void Update()
    {
        Vector3 toTarget = _cameraTarget.position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);
        transform.rotation = Quaternion.LookRotation(toTargetXZ);
    }


    public void UpdateFillAmmount(float _currentHealth, float _maxHealth) {
        HealthBarImage.fillAmount = _currentHealth / _maxHealth;
    }

}
