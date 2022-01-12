using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        //TrainPartHealth enemyHealth = collider.attachedRigidbody?.GetComponent<TrainPartHealth>();
        TrainWagon enemyHealth = collider.GetComponent<TrainWagon>();

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
