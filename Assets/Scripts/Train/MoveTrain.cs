using UnityEngine;

public class MoveTrain : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    public float Speed = 10f;
    [SerializeField] private float _damper = 0.2f;

    private void FixedUpdate()
    {
        Vector3 speed = Vector3.Lerp(_rb.velocity, new Vector3(0f, 0f, Speed), Time.deltaTime * _damper);
        _rb.velocity = speed;
    }
}
