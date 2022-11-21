using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolipopManBehaviourScript : MonoBehaviour
{
    private Transform player;
    private float speed = 5;
    private float rangeMoreOrLess = 1;
    public float waitTime = 8;
    private float coolDown;
    private bool facingRight = true;

    public Animator animator;
    public GameObject projectile;
    private Transform spawner;
    private bool hasShot = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawner = gameObject.transform.GetChild(0);
        coolDown = waitTime;
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (player.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        if (coolDown <= 0)
        {
            
            //bouger de haut en bas jusqua un collision et changer pour bas en haut
            //ou peut etre pas
            //si le joueur est a plus ou moins 1 en y du lolipop et a 10 ou moins de x
            if (player.position.y - rangeMoreOrLess <= transform.position.y && transform.position.y <= player.position.y + rangeMoreOrLess)
            {
                Vector2 difference = player.position - transform.position;
                if (Mathf.Abs(difference.x) <= 10)
                {
                    animator.SetBool("isAttack", true);
                    hasShot = false;
                }
            }
            coolDown = waitTime;
        }
        else
        {
            coolDown -= Time.deltaTime;
        }
        /*if (animator.GetCurrentAnimatorStateInfo(0).IsName("LolipopMan_Attack"))
        {
            
        }*/
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LolipopMan_CoolDown") && !hasShot)
        {
            Instantiate(projectile, spawner.position, Quaternion.identity);
            FindObjectOfType<audioManager>().Play("EnemyAttack"); 
            animator.SetBool("isAttack", false);
            hasShot = true;
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
