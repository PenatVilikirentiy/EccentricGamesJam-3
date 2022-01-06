using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _bulletExplosionEffect;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Health enemyHealth = collider.attachedRigidbody?.GetComponent<Health>();

        if (enemyHealth)
        {
            enemyHealth.TakeDamage(_damage);
        }

        Die();
    }

    private void Die()
    {
        ParticleSystem bulletExplosionEffect = Instantiate(_bulletExplosionEffect, transform.position, Quaternion.identity);
        bulletExplosionEffect.Play();
        Destroy(bulletExplosionEffect, 0.3f);
        Destroy(gameObject);
    }
}
