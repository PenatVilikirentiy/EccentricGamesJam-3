using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float LerpRate;
    public List<Transform> CarsToChose;
    public Transform ChosenCar;
    public int ChosenCarIndex;


    private void Start() {
        ChosenCar = CarsToChose[0];
        //Debug.Log("CarsToChose.Count" + CarsToChose.Count);
    }

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, ChosenCar.position, Time.deltaTime * LerpRate);
    }

    public void ChoseCarToTheLeft() {
        if (ChosenCarIndex < CarsToChose.Count - 1) {
            ChosenCarIndex = ChosenCarIndex + 1;
            ChosenCar = CarsToChose[ChosenCarIndex];
        }

    }
    public void ChoseCarToTheRight() {
        if (ChosenCarIndex > 0) {
            ChosenCarIndex = ChosenCarIndex - 1;
            ChosenCar = CarsToChose[ChosenCarIndex];
        }
    }

}
