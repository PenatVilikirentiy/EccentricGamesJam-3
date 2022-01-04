using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image HealthBarImage;

    public void UpdateFillAmmount(float _currentHealth, float _maxHealth)
    {
        HealthBarImage.fillAmount = _currentHealth / _maxHealth;
    }
}


