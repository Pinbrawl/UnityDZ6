using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Catapult _catapult;
    [SerializeField] private Bullet _bullet;

    private void Awake()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _catapult.GettingReady += Spawn;
    }

    private void OnDisable()
    {
        _catapult.GettingReady -= Spawn;
    }

    private void Spawn()
    {
        Instantiate(_bullet, transform);
    }
}
