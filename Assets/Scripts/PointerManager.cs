using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointerManager : MonoBehaviour {

    public GameObject CanvasConstructorOnly;
    [SerializeField] private MoveTrain moveTrain;
    [SerializeField] private MoneyManager MoneyManager;
    [SerializeField] private int CurrentTurretIndex = 0;



    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
   
            if (Physics.Raycast(cameraRay, out RaycastHit hit, 100f)) {
                TurretPlatform platform = hit.collider?.GetComponent<TurretPlatform>();
                if (platform) {
                    platform.chooseTurret(CurrentTurretIndex);
                    Debug.Log("TurretChosen" + CurrentTurretIndex);
                }

            }

        }
    }

    public void ReadyToFight() {
        CanvasConstructorOnly.SetActive(false);
        moveTrain.Speed = 10f;
        //отключить расстановку турелей
    }

    public void SetTurret(int turretIndex) {
         CurrentTurretIndex = turretIndex;
        Debug.Log("button SentTurretIndex" + CurrentTurretIndex);
    }


}
