using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _bulletExplosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Health enemyHealth = collision.collider?.attachedRigidbody?.GetComponent<Health>();

        if (enemyHealth)
        {
            enemyHealth.TakeDamage(_damage);
        }

        Die();
    }

    private void Die()
    {
        //_bulletExplosionEffect.Play();
        Destroy(gameObject);
    }
}
