
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject enemyBullet;
    public float time;
    public float delay;

    void Start()
    {
        InvokeRepeating("Bullet", delay, time);
    }

    void Bullet()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }
}
