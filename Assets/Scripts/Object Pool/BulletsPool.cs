using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public  PoolType PoolType;

    [SerializeField] private int _poolCount = 200;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private ParticleSystem _bulletExplosionVFX;
    [SerializeField] private AudioSource _shotSound;

    [Header("Containers")]
    [SerializeField] private Transform _bulletsContainer;
    [SerializeField] private Transform _soundsContainer;
    [SerializeField] private Transform _vfxContainer;

    private List<Bullet> _bulletsPool;
    private List<AudioSource> _audioPool;
    private List<ParticleSystem> _vfxPool;

    private void Awake()
    {
        _bulletsPool = new List<Bullet>(_poolCount);
        _audioPool = new List<AudioSource>(_poolCount);
        _vfxPool = new List<ParticleSystem>(_poolCount);

        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            AudioSource audio = Instantiate(_shotSound, _soundsContainer);
            ParticleSystem particle = Instantiate(_bulletExplosionVFX, _vfxContainer);

            CreateBullet();
            _audioPool.Add(audio);
            _vfxPool.Add(particle);
        }
    }

    private Bullet CreateBullet(bool isActive = false)
    {
        Bullet bullet = Instantiate(_bulletPrefab, _bulletsContainer);
        bullet.SetPool(this);
        bullet.gameObject.SetActive(isActive);
        _bulletsPool.Add(bullet);
        return bullet;
    }

    public Bullet GetBullet(bool isActive = false)
    {
        foreach (Bullet bullet in _bulletsPool)
        {
            if (bullet.gameObject.activeInHierarchy)
                continue;

            bullet.gameObject.SetActive(isActive);
            return bullet;
        }

        return CreateBullet(isActive);
    }

    public AudioSource GetAudio()
    {
        foreach(AudioSource audio in _audioPool)
        {
            if (audio.isPlaying) continue;
            return audio;
        }

        AudioSource audioSource = Instantiate(_shotSound);
        _audioPool.Add(audioSource);

        return audioSource;
    }

    public ParticleSystem GetParticle()
    {
        foreach (ParticleSystem particle in _vfxPool)
        {
            if (particle.isPlaying) continue;
            return particle;
        }

        ParticleSystem particleSystem = Instantiate(_bulletExplosionVFX);
        _vfxPool.Add(particleSystem);

        return particleSystem;
    }



}
