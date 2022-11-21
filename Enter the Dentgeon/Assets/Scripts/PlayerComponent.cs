using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour
{
    public float movementSpeed = 1;
    public float dashDistance = 100;
    public LayerMask ennemiLayer;
    public Rigidbody2D rb;
    public Image abilityDash;
    public float coolDown = 5;
    public List<Item> inventaire;
    public GameObject menuPause;

    private float horizontal;
    private float vertical;
    private Vector2 lastMovement;

    private bool isFacingRight = true;
    private bool isDashing = false;
    private bool isCoolDown = false;
    private LayerMask wall;
    private bool isPause = false;

    static SpriteRenderer sr;
    public static bool isBlinking = false;

    private void Start()
    {
        wall = 11;
        menuPause.SetActive(false);
        abilityDash.fillAmount = 0;
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        rb.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (lastMovement.x * dashDistance), transform.position.y + (lastMovement.y * dashDistance)), lastMovement);
        if (Physics2D.Raycast(new Vector2(transform.position.x + (lastMovement.x * dashDistance), transform.position.y + (lastMovement.y * dashDistance)), lastMovement,dashDistance,11))
        {
            Debug.Log(hit.collider);
            Debug.DrawRay(new Vector2(transform.position.x + (lastMovement.x * dashDistance), transform.position.y + (lastMovement.y * dashDistance)), lastMovement, Color.blue, 2);
        }
        else
        Debug.DrawRay(new Vector2(transform.position.x + (lastMovement.x * dashDistance), transform.position.y + (lastMovement.y * dashDistance)), lastMovement,Color.red,2);
      

         

        HandleDash();
        /*RaycastHit hit;
        if (Physics.Raycast(rb.position, new Vector2(transform.position.x + (lastMovement.x * dashDistance), transform.position.y + (lastMovement.y * dashDistance)), out hit, Mathf.Infinity, 7))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }*/
        

       // RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2 (rb.position.x,rb.position.y), new Vector2(transform.position.x, transform.position.y), dashDistance, 7);
        //Debug.Log("WOOOOOOOOOOOOOOOW"+ raycastHit.collider);
       // Debug.DrawLine(new Vector2(rb.position.x, rb.position.y), new Vector2(transform.position.x + (lastMovement.x * dashDistance), transform.position.y + (lastMovement.y * dashDistance)), Color.red, 2);
       /* if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
       */
        
        
    }
    private void HandleDash()
    {
        if (isDashing)
        {
            isCoolDown = true;
            abilityDash.fillAmount = 1;

            rb.MovePosition(new Vector2(transform.position.x + (lastMovement.x * dashDistance), transform.position.y + (lastMovement.y * dashDistance)));
            isDashing = false;
        }
        if (isCoolDown)
        {
            abilityDash.fillAmount -= 1 / coolDown * Time.deltaTime;
            if (abilityDash.fillAmount <= 0)
            {
                abilityDash.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f,0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 6)
            HeartComponent.TakeDamage();   
    }
    //InputSystem Get
    public void Move(InputAction.CallbackContext context)
    {
        lastMovement = new Vector2(horizontal, vertical).normalized;
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;

        
    }

    public void Pause(InputAction.CallbackContext context)
    {
        isPause = !isPause;
        if(isPause)
        {

            menuPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            menuPause.SetActive(false);
        }

    }
    public void Pause()
    {
        isPause = !isPause;
        if (isPause)
        {

            menuPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            menuPause.SetActive(false);
        }

    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(!isCoolDown)
            isDashing = true;
    }
    
    public static IEnumerator Blink()
    {
        sr.color = new Color(1,1,1,0);
        yield return new WaitForSeconds(.1f);
        sr.color = new Color(1, 1, 1, 1);
    }


}
