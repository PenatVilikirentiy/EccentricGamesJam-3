using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform CurrentTarget;

    //renderers to change to highlight placement
    [SerializeField] private Renderer[] _renderers;
    //material to change to highlight placement
    [SerializeField] private Material _regularMaterial;
    [SerializeField] private Material _highlightedMaterial;

    [SerializeField] protected Transform _bulletSpawner;
    [SerializeField] protected Transform _turretModelToRotateLeftRight;
    [SerializeField] protected Transform _turretModelToRotateUpDown;

    [SerializeField] protected AudioSource _shotSound;

    [SerializeField] protected GameObject _muzzleFlash;

    [SerializeField] protected float _bulletSpeed = 100f;
    [SerializeField] protected float _fireRate = 5f;
    [SerializeField] protected float _rotationSpeed = 1f;
    [SerializeField] protected float _upDownAimOffset = 1.5f;

    [SerializeField] protected LayerMask _whatIsEnemy;

    protected BulletsPool _pool;
    protected float _nextTimeToFire = 0;

    protected virtual void Shoot()
    {
        AudioSource shotSound = _pool.GetAudio();
        shotSound.pitch = Random.Range(0.9f, 1.1f);
        shotSound.volume = Random.Range(0.3f, 0.5f);
        _shotSound.transform.position = _bulletSpawner.position;
        _shotSound.Play();        

        _muzzleFlash.SetActive(true);
        Invoke(nameof(HideMuzzleFlash), 0.05f);

        Bullet bullet = _pool.GetBullet(false);        
        bullet.transform.position = _bulletSpawner.position;
        bullet.transform.rotation = _bulletSpawner.rotation;
        bullet.TrailRenderer.Clear();
        bullet.gameObject.SetActive(true);

        bullet.Rigidbody.velocity = _bulletSpawner.forward * _bulletSpeed;
    }

    protected virtual bool Aim()
    {
        if (CurrentTarget == null) return false;

        Vector3 targetPos = CurrentTarget.position - _bulletSpawner.position;

        // Rotation left-right
        Quaternion goalRotation = Quaternion.LookRotation(targetPos);
        var eulerRotation = goalRotation.eulerAngles;
        var clampedQuaternion = Quaternion.Euler(0, eulerRotation.y, 0);
        _turretModelToRotateLeftRight.localRotation = Quaternion.Lerp(_turretModelToRotateLeftRight.localRotation, clampedQuaternion, Time.deltaTime * _rotationSpeed);

        // Rotation up-down
        clampedQuaternion = Quaternion.Euler(eulerRotation.x - _upDownAimOffset, 0, 0);
        _turretModelToRotateUpDown.localRotation = Quaternion.Lerp(_turretModelToRotateUpDown.localRotation, clampedQuaternion, Time.deltaTime * _rotationSpeed);

        return Physics.Raycast(_bulletSpawner.position, _bulletSpawner.forward, 100f, _whatIsEnemy);
    }

    protected virtual void HideMuzzleFlash()
    {
        _muzzleFlash.SetActive(false);
    }
    
    public void SetHightlightedMaterial (){
        foreach (Renderer renderer in _renderers) {
            renderer.material = _highlightedMaterial;
        }
    }

    public void SetNormalMaterial (){
        foreach (Renderer renderer in _renderers) {
            renderer.material = _regularMaterial;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_bulletSpawner.position, _bulletSpawner.forward * 100f);
    }
}
