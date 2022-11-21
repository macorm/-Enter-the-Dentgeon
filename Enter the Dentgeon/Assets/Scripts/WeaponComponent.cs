using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    public Transform canon;
    public GameObject bulletPrefab;
    public float damage = 1;

    //public LineRenderer line;
    public void Shoot()
    {
        Instantiate(bulletPrefab, canon.position, canon.rotation);
        FindObjectOfType<audioManager>().Play("Shoot");
        /*RaycastHit2D hitInfo = Physics2D.Raycast(canon.position, canon.right);
        if (hitInfo)
        {
            EnnemieComponent enemy = hitInfo.transform.GetComponent<EnnemieComponent>();
            if (enemy)
            {
                enemy.TakeDomage(damage);
            }

            line.SetPosition(0, canon.position);
            line.SetPosition(1, hitInfo.point);
        }
        else
        {
            line.SetPosition(0, canon.position);
            line.SetPosition(1, canon.position + canon.right * 100);
        }

        line.enabled = true;

        yield return 0;

        line.enabled = false;
        */
    }
}
