using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;

    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _bulletExplosionEffect;

    public Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = transform.position;
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        Vector3 direction = transform.position - _lastPosition;
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, direction.magnitude))
        {
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = Vector3.zero;
            
            transform.position = hit.point;
            Health health = hit.collider.attachedRigidbody?.GetComponent<Health>();

            if (health)
            {
                health.TakeDamage(_damage);
            }

            Die();
        }

        _lastPosition = transform.position;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Health enemyHealth = collision.collider.attachedRigidbody?.GetComponent<Health>();

    //    if (enemyHealth)
    //    {
    //        enemyHealth.TakeDamage(_damage);
    //    }

    //    Die();
    //}

    //private void OnTriggerEnter(Collider collider)
    //{
    //    Health enemyHealth = collider.attachedRigidbody?.GetComponent<Health>();

    //    if (enemyHealth)
    //    {
    //        enemyHealth.TakeDamage(_damage);
    //    }

    //    Die();
    //}

    private void Die()
    {
        ParticleSystem bulletExplosionEffect = Instantiate(_bulletExplosionEffect, transform.position, Quaternion.identity);
        bulletExplosionEffect.Play();
        Destroy(bulletExplosionEffect.gameObject, 0.3f);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Vector3 direction = transform.position - _lastPosition;
        Ray ray = new Ray(transform.position, direction);
        Gizmos.color = Color.black;
        Gizmos.DrawRay(ray);
    }
}
