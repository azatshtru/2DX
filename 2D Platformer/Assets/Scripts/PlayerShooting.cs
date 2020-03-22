using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public VariableJoystick shootJoystick;
    public LineRenderer aimLine;
    public GameObject bullet;
    public float shootVelocity;

    Vector3 recDir;
    bool canShoot;
    bool isLoaded;

    private void Update()
    {
        if(isLoaded == true)
        {
            canShoot = true;
        }

        Vector3 dir = new Vector3(shootJoystick.Horizontal, shootJoystick.Vertical, 0);

        if(dir.magnitude >= 0.5f)
        {
            RenderAim(dir);
        }
        else
        {
            RenderAim(Vector3.zero);
        }

        if (dir != Vector3.zero)
        {
            canShoot = false;
            isLoaded = true;
            recDir = dir;
        }

        if(dir == Vector3.zero && canShoot == true && recDir.magnitude >= 0.5f)
        {
            GameObject bulletGO = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);

            bulletGO.GetComponent<Bullet>().GetDirection(recDir, shootVelocity);

            isLoaded = false;
            canShoot = false;
        }
    }

    void RenderAim(Vector3 direction)
    {
        aimLine.SetPosition(0, transform.position);

        Vector3 _direction = transform.position + (direction.normalized * 8f);

        aimLine.SetPosition(1, _direction);
    }
}
