using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
  public float speed;

  public float min_Y, max_Y, min_X, max_X;

  public float attackTimer = 0.01f;
  private float currentAttackTimer;
  private bool canAttack;
  public int bulletStash;

  private BoxCollider2D boxCollider;
  private Vector3 moveDelta;
  private RaycastHit2D hit;

  public Text bulletText;


    // Start is called before the first frame update
    void Start()
    {
      currentAttackTimer = attackTimer;
      boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      MovePlayer();
      Shoot();
    }

    public void MovePlayer()
    {
      float x = Input.GetAxisRaw("Horizontal");
      float y = Input.GetAxisRaw("Vertical");
      moveDelta = new Vector3(speed*x,speed*y,0);

      hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Wall"));
      if (hit.collider == null)
      {
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
      }

      hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Wall"));
      if (hit.collider == null)
      {
        transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
      }

/*
      if(Input.GetAxisRaw("Vertical") > 0f)
      {
        //transform.position ei ole muuttuja, siksi temp
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Wall"));
        if (hit.collider == null)
        {
          transform.position = temp;
        }


      }
      else if (Input.GetAxisRaw("Vertical") < 0f)
      {
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Wall"));
        if (hit.collider == null)
        {
          transform.position = temp;
        }
      }

      if(Input.GetAxisRaw("Horizontal") > 0f)
      {
        //transform.position ei ole muuttuja, siksi temp
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;


        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.x), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Wall"));
        if (hit.collider == null)
        {
          transform.position = temp;
        }
      }

      else if (Input.GetAxisRaw("Horizontal") < 0f)
      {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.x), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Wall"));
        if (hit.collider == null)
        {
          transform.position = temp;
        }
      }
*/
    }

    void Shoot(){


      attackTimer += Time.deltaTime;
      if (attackTimer > currentAttackTimer && bulletStash > 0){
        canAttack = true;
      }

      if (Input.GetKeyDown(KeyCode.Z)){
        if (canAttack){
          canAttack = false;
          attackTimer = 0f;
          GetComponent<FireBullets>().Fire();
          bulletStash = bulletStash-1;
          bulletText.text = bulletStash.ToString();
          //sound fx
        }

      }

    }

}
