using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField]  private float _speed;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _delay;

    private WaitForSeconds _timeWaitForNextShooting;

    private void Awake()
    {
        _timeWaitForNextShooting = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        Rigidbody bulletRigidbody = _bullet.GetComponent<Rigidbody>();

        while (isWork)
        {
            var vector3direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + vector3direction, Quaternion.identity);

            newBullet.transform.up = vector3direction;
            bulletRigidbody.velocity = vector3direction * _speed;

            yield return _timeWaitForNextShooting;
        }
    }
}
