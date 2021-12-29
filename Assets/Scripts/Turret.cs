using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;
    public Collider Collider;
    public Transform CurrentTarget;
    public Transform _raycast;

    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private Transform _turretModel;

    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private AudioSource _shotSound;

    [SerializeField] private ParticleSystem _shotEffect;

    [SerializeField] private GameObject _muzzleFlash;

    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _fireRate = 5f;
    [SerializeField] private float _rotationSpeed = 1f;

    [SerializeField] private LayerMask _whatIsEnemy;

    public Vector2Int _size = Vector2Int.one;

    private float _nextTimeToFire = 0;


    private void Update()
    {
        if (Aim() && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1 / _fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        //var shotSound = Instantiate(_shotSound);
        //shotSound.volume = 0.3f;
        _shotSound.pitch *=  Random.Range(0.9f, 1.1f); 
        _shotSound.Play();
        //Destroy(shotSound.gameObject, 1f);

        //_muzzleFlash.SetActive(true);
        //Invoke(nameof(HideMuzzleFlash), 0.1f);

GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
  if (bullet != null) {
    bullet.transform.position = _bulletSpawner.position;
    bullet.transform.rotation = Quaternion.identity;
    bullet.SetActive(true);
    bullet.GetComponent<Rigidbody>().velocity = _bulletSpawner.forward * _bulletSpeed;
        }
       // Bullet bullet = Instantiate(_bulletPrefab, _bulletSpawner.position, Quaternion.identity);
       // bullet.Rigidbody.velocity = _bulletSpawner.forward * _bulletSpeed;
    }

    public bool Aim()
    {
        if (CurrentTarget == null) return false;

        Vector3 target = CurrentTarget.position - _turretModel.position;
        Quaternion targetRotation = Quaternion.LookRotation(target);
        _turretModel.rotation = Quaternion.Lerp(_turretModel.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

        return Physics.Raycast(_bulletSpawner.position, _bulletSpawner.forward, 100f, _whatIsEnemy);
    }

    private void HideMuzzleFlash()
    {
        _muzzleFlash.SetActive(false);
    }

    public void SetTranparent(bool isAvailable)
    {
        if(isAvailable)
        {
            foreach(Renderer renderer in _renderers)
            {
                renderer.material.color = new Color(0, 1, 0, .2f);
            }
        }
        else
        {
            foreach (Renderer renderer in _renderers)
            {
                renderer.material.color = new Color(1, 0, 0, .2f);
            }
        }
    }

    public void SetNormal()
    {
        foreach (Renderer renderer in _renderers)
        {
            renderer.material.color = new Color(1, 1, 1, 1);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(_bulletSpawner.position, _bulletSpawner.forward * 100f);

    //    for (int x = 0; x < _size.x; x++)
    //    {
    //        for (int y = 0; y < _size.y; y++)
    //        {
    //            Gizmos.color = Color.yellow;
    //            Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
    //        }
    //    }
    //}
}
