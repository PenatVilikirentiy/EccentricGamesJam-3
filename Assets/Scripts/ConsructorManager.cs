using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConsructorManager : MonoBehaviour {

    public GameObject CanvasConstructorOnly;
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private int _currentTurretIndex = 0;
    [SerializeField] private int _currentTurretPrice = 0;
    //_choosingTurret = true after pressing the turret button
    [SerializeField] private bool _choosingTurret = false;

    //create a list of all turretplatforms
    public List<TurretPlatform> TurretPlatforms;


    void Update() {

        //placing the turret
        if (_choosingTurret == true) {
            //going through all TurretPlatforms and turning HighlightTurretON method
            //sending an index of chosen turret to all turret platforms for highlighting
            foreach (TurretPlatform turretPlatform in TurretPlatforms) {
                turretPlatform.HighlightTurretON(_currentTurretIndex);
            }




            if (Input.GetMouseButtonDown(0)) {

                //after click going through all TurretPlatforms and turning HighlightTurretOFF method
                foreach (TurretPlatform turretPlatform in TurretPlatforms) {
                    turretPlatform.HighlightTurretOFF(_currentTurretIndex);
                }

                _choosingTurret = false;


                if (_moneyManager.CoinCount >= _currentTurretPrice) {

                    Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(cameraRay, out RaycastHit hit, 100f)) {
                        TurretPlatform platform = hit.collider?.GetComponent<TurretPlatform>();
                        if (platform) {
                            platform.SetTurret(_currentTurretIndex);
                            //Debug.Log("TurretChosen" + CurrentTurretIndex);
                            _moneyManager.ChangeValue(-_currentTurretPrice);
                            _currentTurretIndex = 0;
                            _currentTurretPrice = 0;
                        }
                    }

                } else {
                    Debug.Log("not enought money");
                    _currentTurretIndex = 0;
                    _currentTurretPrice = 0;
                }
            }
        }
    }

    public void ReadyToFight() {
        CanvasConstructorOnly.SetActive(false);
        gameObject.SetActive(false);
        _moveTrain.Speed = 10f;
        //отключить расстановку турелей
    }

    public void SetCurrentTurretPrice(int currentTurretPrice) {
        _currentTurretPrice = currentTurretPrice;
    }

    public void SetTurret(int turretIndex) {
        _choosingTurret = true;
        _currentTurretIndex = turretIndex;
        Debug.Log("button SentTurretIndex" + _currentTurretIndex + "for _currentTurretPrice" + _currentTurretPrice);
    }
}






