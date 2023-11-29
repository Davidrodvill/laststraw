using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePlayerCombat : MonoBehaviour {
    //public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers2; //enemyLayers2;
    public static bool canAttack = true;
    //public AudioSource aud;
    //public AudioClip punchSound, whiffSound;
    //public int count = 0; //keep track of how many times the button is pressed
    public int attackDamage = 5;
    public EnemyController enemyController;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        //aud = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            if (Time.time >= nextAttackTime)
            {
                //maybe a new if statement here?

                if (Input.GetKeyDown(KeyCode.J))
                {

                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate; //can only attack half a second
                                                                  //print(Time.time + "\tnext: " + (Time.time + 1f / attackRate));

                    //Debug.Log(count);


                }
                /*
                else if (Input.GetKeyDown(KeyCode.J) && count == 1) //why does this play at the same time as attack 1?
                {
                        
                        Attack2();
                        nextAttackTime = Time.time + 1f / attackRate; //can only attack half a second
						count++;
						//Debug.Log(count);
                }
               else if (Input.GetKeyDown(KeyCode.J) && count == 2)
               {
                        Attack3();
                        nextAttackTime = Time.time + 2f / attackRate; //can only attack half a second

					count = 0; //reset the cycle after 3rd attack
               }
               
				
					

			}
			*/
            }
        }
    }

    void Attack()
    {
        //Debug.Log("Attack 1 has played");
        //play an attack animation
        //animator.SetTrigger("Attack");
        //aud.PlayOneShot(whiffSound);
        //Detect enemies in range of attack
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers1);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers2);


        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            //aud.PlayOneShot(punchSound);
            //enemy.GetComponent<BrawlerEnemy>().TakeDamage(attackDamage);
            //enemy.GetComponent<Beehives>().TakeDamage(attackDamage);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);

        }

        /*
		foreach (Collider2D enemy in hitEnemies2)
		{

			enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
			Debug.Log("bee has been attacked");
		}
		*/
    }

    /*
	void Attack2()
	{
        Debug.Log("Attack 2 has played");
        //play an attack animation
        animator.SetTrigger("Attack2");
        aud.PlayOneShot(whiffSound);
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            aud.PlayOneShot(punchSound);
            enemy.GetComponent<BrawlerEnemy>().TakeDamage(attackDamage);
        }

    }

    void Attack3()
	{
        Debug.Log("Attack 3 has played");
        //play an attack animation
        animator.SetTrigger("Attack3");
        aud.PlayOneShot(whiffSound);
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
			StartCoroutine(FinalAttack());
            aud.PlayOneShot(punchSound);
            enemy.GetComponent<BrawlerEnemy>().TakeDamage(attackDamage);
        }

    }
	*/

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    /*
	IEnumerator FinalAttack()
	{
		yield return new WaitForSeconds(1.8f);

	}
	*/
}
