using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] private float moveSeed = 25f;
    [SerializeField] private float timeDetroy = 0.5f;

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
}
