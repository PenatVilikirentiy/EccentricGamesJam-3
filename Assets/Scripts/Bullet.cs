using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _bulletExplosionEffect;


    private void OnEnable()
    {
        //Destroy(gameObject, 3f);
        Invoke("Die", 1.0f);


    }

    private void OnTriggerEnter(Collider collider)
    {
        Health enemyHealth = collider.attachedRigidbody?.GetComponent<Health>();

        if (enemyHealth)
        {
            enemyHealth.TakeDamage(_damage);
            Debug.Log("dealthDamage");
        }

        Die();
    }

    private void Die()
    {
        //_bulletExplosionEffect.Play();
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
