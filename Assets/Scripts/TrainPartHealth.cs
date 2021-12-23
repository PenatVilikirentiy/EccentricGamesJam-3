public class TrainPartHealth : Health
{
    public void AddHealth(int healthAmount)
    {
        _currentHealth += healthAmount;

        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}
