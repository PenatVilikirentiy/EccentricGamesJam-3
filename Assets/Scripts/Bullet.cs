using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public TrailRenderer TrailRenderer;

    [SerializeField] private ParticleSystem _bulletExplosionEffect;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifetime = 3f;

    private Vector3 _lastPosition;

    private void OnEnable()
    {
        // Just a little offset because when a bullet is created there is no previous position
        _lastPosition = transform.position - new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        _lastPosition = transform.TransformPoint(_lastPosition);
        Invoke(nameof(Deactivate), _lifetime);
    }

    private void FixedUpdate()
    {
        HitCheck();
    }

    private void HitCheck()
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
                health.TakeDamage(_damage);

            Die();
        }

        _lastPosition = transform.position;
    }

    private void Die()
    {
        ParticleSystem bulletExplosionEffect = Instantiate(_bulletExplosionEffect, transform.position, Quaternion.identity);
        bulletExplosionEffect.Play();

        Destroy(bulletExplosionEffect.gameObject, 0.3f);
        Invoke(nameof(Deactivate), 0.3f);
    }

    private void Deactivate()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);        
    }

    private void OnDrawGizmos()
    {
        Vector3 direction = transform.position - _lastPosition;
        Ray ray = new Ray(transform.position, direction);
        Gizmos.color = Color.black;
        Gizmos.DrawRay(ray);
    }
}
