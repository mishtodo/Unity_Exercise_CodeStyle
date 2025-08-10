using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _objectToShoot;
    
    private Coroutine _coroutine;

    private void Start()
    {
        StartCoroutine();
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSecondsRealtime(_shootingDelay);

        while (enabled)
        {
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
            newBullet.Shoot(direction);

            yield return wait;
        }
    }
}