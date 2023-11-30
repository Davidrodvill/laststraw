using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Video;
public class EnemyController : MonoBehaviour {
	public GameObject pointA, pointB;
	private Rigidbody2D rb2d;
	public int beehp = 20;
    public int attackDamage = 5;
    public Slider healthBar;
    public Transform healthbarPos;
    public Color color1Player; //should be normal
    public Color color2Player; //should be red (switch to this color after enemy gets hit)
    public SpriteRenderer sr1;
    private Transform currentPoint;
	public float _beespeed;

    /*
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    */

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		currentPoint = pointB.transform;
		flip();

		_beespeed = Random.Range(0f, 6f);

        GameObject hb = Instantiate(healthBar.gameObject);
        //put the healthbar on the canvas
        hb.transform.SetParent(GameObject.Find("EnemyHealthbars").transform);
        healthBar = hb.GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
		Vector2 point = currentPoint.position - transform.position;
        //update heath bar
        healthBar.transform.position = Camera.main.WorldToScreenPoint(healthbarPos.transform.position);
        healthBar.value = beehp;
        if (currentPoint == pointB.transform)
		{
			rb2d.velocity = new Vector2(_beespeed, 0);
		}
		else
		{
			rb2d.velocity = new Vector2(-_beespeed, 0);
		}

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
		{
			flip();
			currentPoint = pointA.transform;
		}
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {
			flip();
            currentPoint = pointB.transform;
        }

    }

    

	void FixedUpdate()
	{
        if (beehp <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator waitsomeSeconds()
    {
        yield return new WaitForSeconds(0.5f);

    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Bee has been attacked");
        beehp -= damage;

        StartCoroutine(BeeHit());

        if (beehp <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar.gameObject);
        }

    }
    IEnumerator BeeHit()
    {
        sr1.color = color2Player;
        yield return new WaitForSeconds(.5f);
        sr1.color = color1Player;

    }
    private void flip()
	{
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
		Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
		Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
	}

    /*
    public void Attack()
    {

        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerControllerLVL2>().TakeDamage(attackDamage);
            //aud.PlayOneShot(punchSound);
        }
        Debug.Log("Enemy has attacked");
    }
    */

    /*
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);

    }
    */
}
