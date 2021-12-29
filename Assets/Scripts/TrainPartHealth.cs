using UnityEngine;

public class TrainPartHealth : Health
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private AudioSource _trainSound;
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private PlayerHealthBar _playerHealthBar;

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        _playerHealthBar.UpdateFillAmmount(_currentHealth, _maxHealth);
    }

    public void AddHealth(int healthAmount)
    {
        _currentHealth += healthAmount;

        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    protected override void Die()
    {
        //base.Die();
        _trainSound.enabled = false;
        _moveTrain.Speed = 0;

        _gameOver.SetActive(true);
    }

}
