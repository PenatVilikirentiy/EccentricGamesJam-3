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

    private void OnEnable()
    {        
        //Invoke("Die", 1.0f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Health enemyHealth = collider.attachedRigidbody?.GetComponent<TrainPartHealth>();

        if (enemyHealth)
        {
            enemyHealth.TakeDamage(_damage);
            //Debug.Log("dealthDamage");
        }

        Die();
    }

    private void Die()
    {
        //_bulletExplosionEffect.Play();
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
