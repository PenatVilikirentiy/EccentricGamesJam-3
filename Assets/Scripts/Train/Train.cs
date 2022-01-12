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

    public List<TrainWagon> TrainWagons;

    public static Train Instance;

    public UnityEvent OnWagonDeath;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {

        UpdateTrainHealth();
        _maxTrainHealth = _currentTrainHealth;

    }


    public void UpdateTrainHealth() {
        _currentTrainHealth = 0;
        foreach (TrainWagon _trainPartHealth in TrainWagons) {
            _currentTrainHealth += _trainPartHealth.CurrentHealth;
        }

        _playerHealthBar.UpdateFillAmmount(_currentTrainHealth, _maxTrainHealth);

        if (_currentTrainHealth < 0) {
            Debug.Log("train died");
            Die();
        }
    }


    public void Atack(Transform trainTarget) {
        foreach (TrainWagon trainWagon in TrainWagons) {
            if (trainWagon.IsActive == true) {
                trainWagon.Attack(trainTarget);
            }
        }
    }

    public void RemoveWagon(TrainWagon trainPartHealth) {
        //TrainWagons.Remove(trainPartHealth);
        OnWagonDeath.Invoke();
    }


    private void Die() {
        _trainSound.enabled = false;
        _moveTrain.Speed = 0;
        _gameOver.SetActive(true);
    }


}
