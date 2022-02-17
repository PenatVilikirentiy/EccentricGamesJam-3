using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConsructorManager : MonoBehaviour {

    public GameObject CanvasConstructorOnly;
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private int _currentTurretIndex = 0;
    [SerializeField] private int _currentTurretPrice = 0;

    //_choosingTurret = true after pressing the turret button
    [SerializeField] private bool _choosingTurret = false;
    //_removingTurret = true after pressing the remove turret button
    [SerializeField] private bool _removingTurret = false;

    //create a list of all turretplatforms
    public List<TurretPlatform> TurretPlatforms;

    public static ConsructorManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void AddPlatform(TurretPlatform turretPlatform) {
        TurretPlatforms.Add(turretPlatform);
    }

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


                if (MoneyManager.Instance.CoinCount >= _currentTurretPrice) {

                    Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(cameraRay, out RaycastHit hit, 1000f)) {
                        TurretPlatform platform = hit.collider?.GetComponent<TurretPlatform>();
                        if (platform) {
                            if (platform.TurretIsChosen == false) {
                                platform.SetTurret(_currentTurretIndex);
                                MoneyManager.Instance.ChangeValue(-_currentTurretPrice);
                                _currentTurretIndex = -1;
                                _currentTurretPrice = 0;
                            }

                        }
                    }

                } else {
                    Debug.Log("not enought money");
                    _currentTurretIndex = -1;
                    _currentTurretPrice = 0;
                }
            }
        }

        if (_removingTurret == true) {
            if (Input.GetMouseButtonDown(0)) {
                _removingTurret = false;
                    Debug.Log("removingTurret");
                Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(cameraRay, out RaycastHit hit, 1000f)) {
                    TurretPlatform platform = hit.collider?.GetComponent<TurretPlatform>();
                    if (platform) {
                        if (platform.TurretIsChosen == true) {
                            platform.SetTurret(-1);
                            Debug.Log("send SetTurret(-1) ");
  
                        }

                    }
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
    //Debug.Log("button SentTurretIndex" + _currentTurretIndex + "for _currentTurretPrice" + _currentTurretPrice);
}

public void RemovingTurret() {
    _removingTurret = true;
}
}






