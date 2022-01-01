using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _currentHealth;
    [SerializeField] protected int _maxHealth = 100;
    [SerializeField] private HealthBar HealthBar;


    [SerializeField] protected int _reward = 100;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;


        HealthBar?.UpdateFillAmmount(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<MoneyManager>().ChangeValue(_reward);
    }
}
