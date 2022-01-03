using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlatform : MonoBehaviour {

    public List<GameObject> TurretsToChose;
    public int ChosenTurret;
    public bool TurretIsChosen = false;

    [SerializeField] private TrainWagon wagon;

    void Start() {

        ChosenTurret = PlayerPrefs.GetInt(gameObject.name + "index");
        //checking if there is a saved turret in playerprefs
        if (PlayerPrefs.GetString(gameObject.name) == "TurretIsChosen") {
            TurretIsChosen = true;
        }
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

    public void SetTurret(int turretIndex) {
        if (TurretIsChosen == false) {

            ChosenTurret = turretIndex;
            //save the index of a chosen turret in player prefs
            PlayerPrefs.SetInt(gameObject.name + "index", ChosenTurret);
            //save that the turret is chosen in player prefs
            PlayerPrefs.SetString(gameObject.name, "TurretIsChosen");
            for (int i = 0; i < TurretsToChose.Count; i++) {
                if (i == ChosenTurret) {
                    //spesifiing that this TurretPlatform has it's turret already chosen
                    TurretIsChosen = true;
                    TurretsToChose[i].gameObject.SetActive(true);
                    TurretsToChose[i].GetComponent<Turret>()?.SetNormalMaterial();
                    wagon.AddTurret(TurretsToChose[i].gameObject.GetComponent<Turret>());
                } else {
                    TurretsToChose[i].gameObject.SetActive(false);
                    wagon.RemoveTurret(TurretsToChose[i].gameObject.GetComponent<Turret>());
                }
            }
        }
    }

    public void HighlightTurretON(int turretIndex) {
        ChosenTurret = turretIndex;
        if (TurretIsChosen == false) {
            for (int i = 0; i < TurretsToChose.Count; i++) {
                if (i == ChosenTurret) {
                    TurretsToChose[i].gameObject.SetActive(true);
                    TurretsToChose[i].GetComponent<Turret>()?.SetHightlightedMaterial();
                } else {
                    TurretsToChose[i].gameObject.SetActive(false);
                }
            }
        }

    }
    public void HighlightTurretOFF(int turretIndex) {
        ChosenTurret = turretIndex;
        if (TurretIsChosen == false) {
            foreach (GameObject turret in TurretsToChose) {
                turret.GetComponent<Turret>()?.SetNormalMaterial();
                turret.gameObject.SetActive(false);
            }

        }




    }
}