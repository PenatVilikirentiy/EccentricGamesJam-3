using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float LerpRate;
    public List<TrainWagon> WagonsToChose;
    public TrainWagon ChosenCar;
    public int ChosenCarIndex;


    public static CameraController Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {

        ChosenCar = WagonsToChose[0];
    }

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, ChosenCar.transform.position, Time.deltaTime * LerpRate);
    }

    public void ChoseCarToTheLeft() {
        if (ChosenCarIndex < WagonsToChose.Count - 1) {
            ChosenCarIndex = ChosenCarIndex + 1;
            ChosenCar = WagonsToChose[ChosenCarIndex];
        }

    }
    public void ChoseCarToTheRight() {
        if (ChosenCarIndex > 0) {
            ChosenCarIndex = ChosenCarIndex - 1;
            ChosenCar = WagonsToChose[ChosenCarIndex];
        }
    }

}
