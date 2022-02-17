using System.Collections.Generic;
using UnityEngine;

public class TurretPlatform : MonoBehaviour {

    public List<Turret> TurretsToChose;
    public int ChosenTurret =-1;
    public bool TurretIsChosen = false;


    void Start() {

        Debug.Log(transform.parent.name + gameObject.name + "index" + PlayerPrefs.GetInt(transform.parent.name + gameObject.name));
         ConsructorManager.Instance.AddPlatform(this) ;

        if (PlayerPrefs.HasKey(transform.parent.name + gameObject.name)) {
            ChosenTurret = PlayerPrefs.GetInt(transform.parent.name + gameObject.name);
            TurretIsChosen = true;

            for (int i = 0; i < TurretsToChose.Count; i++) {
                if (i == ChosenTurret) {
                    TurretsToChose[i].gameObject.SetActive(true);
                } else {
                    TurretsToChose[i].gameObject.SetActive(false);
                }
            }
        } 

    }

    public Turret GetCurrentTurret() {
        if (ChosenTurret >= 0) {
            return TurretsToChose[ChosenTurret];
        } else { return null; }
    }


    public void SetTurret(int turretIndex) {
        if (TurretIsChosen == false) {

            ChosenTurret = turretIndex;

            //save the index of a chosen turret in player prefs
            PlayerPrefs.SetInt(transform.parent.name + gameObject.name , ChosenTurret);

            for (int i = 0; i < TurretsToChose.Count; i++) {
                if (i == ChosenTurret) {
                    //spesifiing that this TurretPlatform has it's turret already chosen
                    TurretIsChosen = true;
                    TurretsToChose[i].gameObject.SetActive(true);
                    TurretsToChose[i].GetComponent<Turret>()?.SetNormalMaterial();
                } else {
                    TurretsToChose[i].gameObject.SetActive(false);
                }
            }
        } else {
            ChosenTurret = turretIndex;
            PlayerPrefs.DeleteKey(transform.parent.name + gameObject.name);
            TurretIsChosen = false;

            for (int i = 0; i < TurretsToChose.Count; i++) {
                    TurretsToChose[i].gameObject.SetActive(false);
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
            foreach (Turret turret in TurretsToChose) {
                turret.GetComponent<Turret>()?.SetNormalMaterial();
                turret.gameObject.SetActive(false);
            }
        }

        ChosenTurret = -1;
    }
}