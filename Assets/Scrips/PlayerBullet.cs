using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] private float moveSeed = 25f;
    [SerializeField] private float timeDetroy = 0.5f;
    [SerializeField] private float damage = 5f;
    [SerializeField] GameObject bloodPrefabs;

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
                GameObject blood = Instantiate(bloodPrefabs, transform.position, Quaternion.identity);
                Destroy(blood, 1f);
            }
            Destroy(gameObject);
        }
    }
}
