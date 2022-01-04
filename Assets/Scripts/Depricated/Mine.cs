using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 100;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _explosionSound;

    private void OnTriggerEnter(Collider other)
    {
        TrainPartHealth partHealth = other.attachedRigidbody.GetComponent<TrainPartHealth>();

        if (partHealth)
        {
            partHealth.TakeDamage(_damage);
            Die();
        }
    }

    private void Die()
    {
        // _explosionSound.Play();
        // _explosionEffect.Play();
        Destroy(gameObject);
    }
}
