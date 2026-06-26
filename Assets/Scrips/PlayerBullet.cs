using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] private float moveSeed = 25f;
    [SerializeField] private float timeDetroy = 0.5f;
    [SerializeField] private float damage = 5f;

    void Start()
    {
        Destroy(gameObject, timeDetroy);
    }

    void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        transform.Translate(Vector2.right * moveSeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamge(damage);
            }
            Destroy(gameObject);
        }
    }
}
