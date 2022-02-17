using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Train : MonoBehaviour {
    [SerializeField] private AudioSource _trainSound;
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private PlayerHealthBar _playerHealthBar;

    [SerializeField] private int _currentTrainHealth;
    [SerializeField] private int _maxTrainHealth;
    [SerializeField] private GameObject _gameOver;

    public List<TrainWagon> ActiveTrainWagons;

    public List<TrainWagon> TrainWagons;
    public int TrainWagonsNumber = 1;
    public int TrainWagonPrice;

    public static Train Instance;

    public UnityEvent OnWagonDeath;


    public void PurchaseWagon() {
        if (MoneyManager.Instance.CoinCount >= (TrainWagonPrice * TrainWagonsNumber)) {
            MoneyManager.Instance.ChangeValue(-(TrainWagonPrice * TrainWagonsNumber));

            TrainWagonsNumber += 1;
            PlayerPrefs.SetInt("TrainWagonsNumber", TrainWagonsNumber);
            _updateWagons();

            Debug.Log("TrainWagonsNumber" + TrainWagonsNumber);
        }

    }

    private void _updateWagons() {
        for (int i = 0; i < TrainWagons.Count; i++) {
            if (i < TrainWagonsNumber) {
                TrainWagons[i].gameObject.SetActive(true);
            }
        }
    }



    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("TrainWagonsNumber")) {
            TrainWagonsNumber = PlayerPrefs.GetInt("TrainWagonsNumber");
            _updateWagons();
            Debug.Log("TrainWagonsNumber" + TrainWagonsNumber);
        }

    }

    private void LateStart() {

        UpdateTrainHealth();


        //_maxTrainHealth = _currentTrainHealth;


    }





    public void UpdateTrainHealth() {
        _currentTrainHealth = 0;
        foreach (TrainWagon _trainPartHealth in ActiveTrainWagons) {
            _currentTrainHealth += _trainPartHealth.CurrentHealth;
        }

        _playerHealthBar.UpdateFillAmmount(_currentTrainHealth, _maxTrainHealth);

        if (_currentTrainHealth < 0) {
            Debug.Log("train died");
            Die();
        }
    }


    public void Atack(Transform trainTarget) {
        foreach (TrainWagon trainWagon in ActiveTrainWagons) {
            if (trainWagon.IsActive == true) {
                trainWagon.Attack(trainTarget);
            }
        }
    }

    public void RemoveActiveWagon(TrainWagon trainPartHealth) {
        //TrainWagons.Remove(trainPartHealth);
        OnWagonDeath.Invoke();
    }


    private void Die() {
        _trainSound.enabled = false;
        _moveTrain.Speed = 0;
        _gameOver.SetActive(true);
    }


}
