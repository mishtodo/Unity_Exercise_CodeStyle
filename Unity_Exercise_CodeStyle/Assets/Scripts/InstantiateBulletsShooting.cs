using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;
    
    [SerializeField] public Transform ObjectToShoot;

    private Coroutine _coroutine;

    private void Start()
    {
        RestartCoroutine();
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void RestartCoroutine()
    {
        _coroutine = StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        var wait = new WaitForSecondsRealtime(_timeWaitShooting);

        while (enabled)
        {
            var vector3direction = (ObjectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = vector3direction;
            newBullet.GetComponent<Rigidbody>().velocity = vector3direction * _speed;

            yield return wait;
        }
    }
}