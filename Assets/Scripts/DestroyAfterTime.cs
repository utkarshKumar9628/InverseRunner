using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    private float lifetime;

    public void SetLifetime(float time)
    {
        lifetime = time;
        Invoke("DestroyBullet", lifetime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}