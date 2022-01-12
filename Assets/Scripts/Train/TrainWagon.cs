using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWagon : MonoBehaviour {

    

    public int CurrentHealth;
    [SerializeField] private int _maxHealth = 100;

    public bool IsActive = true;
    [SerializeField] private PlayerHealthBar _wagonHealthBar;
     public List<TurretPlatform> TurretPlatforms;

    public void Attack(Transform wagonTarget) {
        foreach (TurretPlatform turretPlatform in TurretPlatforms) {
            Turret turret = turretPlatform.GetCurrentTurret();
            if (turret) {
                turret.CurrentTarget = wagonTarget.transform;
            }
        }
    }

    private void Start() {

        CurrentHealth = _maxHealth;
        Train.Instance.TrainWagons.Add(this);
    }

    public void TakeDamage(int damageAmount) {
        CurrentHealth -= damageAmount;

        Train.Instance.UpdateTrainHealth();

        _wagonHealthBar.UpdateFillAmmount(CurrentHealth, _maxHealth);

        if (CurrentHealth <= 0) {
            CurrentHealth = 0;
            Die();
        }
    }

    private void Die() {
        //Deactivate the turrets
        Train.Instance.RemoveWagon(this);
        IsActive = false;
        _wagonHealthBar.gameObject.SetActive(false);
    }


}
