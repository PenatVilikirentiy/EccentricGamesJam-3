using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlatform : MonoBehaviour {

    public List<GameObject> TurretsToChose;
    public int ChosenTurret;

    [SerializeField] private TrainWagon wagon;

    void Start() {

        ChosenTurret = PlayerPrefs.GetInt(gameObject.name);
        for (int i = 0; i < TurretsToChose.Count; i++) {
            if (i == ChosenTurret) {
                TurretsToChose[i].gameObject.SetActive(true);
                wagon.AddTurret(TurretsToChose[i].gameObject.GetComponent<Turret>());
            } else {
                TurretsToChose[i].gameObject.SetActive(false);
                wagon.RemoveTurret(TurretsToChose[i].gameObject.GetComponent<Turret>());
            }
        }

    }

    public void chooseTurret(int turretIndex) {
        ChosenTurret = turretIndex;
        //Debug.Log(gameObject.name + "added turret index " + ChosenTurret);
        PlayerPrefs.SetInt(gameObject.name, ChosenTurret);
        for (int i = 0; i < TurretsToChose.Count; i++) {
            if (i == ChosenTurret) {
                TurretsToChose[i].gameObject.SetActive(true);
                wagon.AddTurret(TurretsToChose[i].gameObject.GetComponent<Turret>());
            } else {
                TurretsToChose[i].gameObject.SetActive(false);
                wagon.RemoveTurret(TurretsToChose[i].gameObject.GetComponent<Turret>());
            }
        }

    }




}
