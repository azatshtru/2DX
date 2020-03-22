using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;
    float shootSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * shootSpeed);
    }

    public void GetDirection(Vector3 _dir, float _speed)
    {
        direction = _dir;
        shootSpeed = _speed;
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
