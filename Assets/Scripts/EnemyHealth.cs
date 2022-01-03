using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _targetIcon;
    [SerializeField] protected int _reward = 100;

    public override void TakeDamage(int damageAmount) {
        base.TakeDamage(damageAmount);
        _healthBar.UpdateFillAmmount(_currentHealth, _maxHealth);
    }


    protected override void Die() {
        base.Die();
        FindObjectOfType<MoneyManager>().ChangeValue(_reward);

    }


    public void BecomeTarget() {
        _targetIcon.SetActive(true);
    }
    public void TurnOffTarget() {
        _targetIcon.SetActive(false);
    }
}

