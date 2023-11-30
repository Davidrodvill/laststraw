using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class Beehives : MonoBehaviour
{
    public int beehivehp = 20;
    public Slider healthBar;
    public Transform healthbarPos;
    public Color color1Player; //should be normal
    public Color color2Player; //should be red (switch to this color after enemy gets hit)
    public SpriteRenderer sr1;
    int hivedown = 1;
    public PlayerControllerLVL2 playercontlvl2;
    //public int numOfB
    

    // Use this for initialization
    void Start()
    {
        GameObject hb = Instantiate(healthBar.gameObject);
        //put the healthbar on the canvas
        hb.transform.SetParent(GameObject.Find("BeehiveHealthbars").transform);
        healthBar = hb.GetComponent<Slider>();
        
        
    }

    void Update()
    {
        //update heath bar
        healthBar.transform.position = Camera.main.WorldToScreenPoint(healthbarPos.transform.position);
        healthBar.value = beehivehp;

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (beehivehp <= 0)
        {
            //GetComponent<PlayerControllerLVL2>().OneHiveDestroyed(hivedown + 1);

            playercontlvl2.GetComponent<PlayerControllerLVL2>().OneHiveDestroyed();
            //Debug.Log("Number of hives left: " + playercontlvl2.numOfHivesLeft);


            Destroy(gameObject);
            Destroy(healthBar.gameObject);


            //GetComponent<PlayerControllerLVL2>().OneHiveDestroyed();
            //GetComponent<PlayerControllerLVL2>().numOfHivesLeft--;
           // Debug.Log("Number of hives left: " + GetComponent<PlayerControllerLVL2>().numOfHivesLeft);
            
        }
        
    }
    
    IEnumerator waitsomeSeconds()
    {
        yield return new WaitForSeconds(0.5f);

    }

    
    public void TakeDamage(int damage)
    {
        Debug.Log("Hive has been attacked");
        beehivehp -= damage;

        StartCoroutine(BeehiveHit());
        /*
        if(beehivehp <= 0)
        {
            //GetComponent<PlayerControllerLVL2>().OneHiveDestroyed(hivedown + 1);
            playercontlvl2.GetComponent<PlayerControllerLVL2>().numOfHivesLeft--;
            Debug.Log("Number of hives left: " + playercontlvl2.numOfHivesLeft);
            Destroy(gameObject);
            Destroy(healthBar.gameObject);
        }
        */
    }

    IEnumerator BeehiveHit()
    {
        sr1.color = color2Player;
        yield return new WaitForSeconds(.5f);
        sr1.color = color1Player;

    }

}