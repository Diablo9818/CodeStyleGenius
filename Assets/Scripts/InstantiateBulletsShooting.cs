using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField]  private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _timeWaitShooting;

    private WaitForSeconds _timeWaitForNextShooting;

    private void Awake()
    {
        _timeWaitForNextShooting = new WaitForSeconds(_timeWaitShooting);
    }

    void Start()
    {

        StartCoroutine(_shootingWorker());
    }

    IEnumerator _shootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var _vector3direction = (_objectToShoot.position - transform.position).normalized;
            var NewBullet = Instantiate(_bullet, transform.position + _vector3direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            NewBullet.GetComponent<Rigidbody>().velocity = _vector3direction * _speed;

            yield return _timeWaitForNextShooting;
        }
    }
}
