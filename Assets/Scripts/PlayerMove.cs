using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;

    private float min_X = -2.7f;
    private float max_X = 2.7f;

    private float speed = 3f;

    //public Text timer_Text;
    //private int timer;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    //void Start()
    //{
    //    Time.timeScale = 1f;
    //    //StartCoroutine(CountTime());
    //    timer = 0;

    //}
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void PlayerBounds()
    {
        Vector3 temp = transform.position;
        
        if(temp.x > max_X)
        {
            temp.x = max_X;

        }
        else if(temp.x < min_X)
        {
            temp.x = min_X;
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 temp = transform.position;
        //transform.position is used to store the position of the player
        //here vector temp is equal to tranform.position which means vector3 hold the x,y,z coordinates of the player


        if (h > 0)
        {
            //going to the right side
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            //going to the left side
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;

            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

        transform.position = temp;
    }


    //IEnumerator RestartGame()
    //{
    //    yield return new WaitForSecondsRealtime(2f);

    //    UnityEngine.SceneManagement.SceneManager.LoadScene(
    //        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    //}

    //IEnumerator CountTime()
    //{
    //    yield return new WaitForSeconds(1f);
    //    timer++;

    //    timer_Text.text = "Timer: " + timer;

    //    StartCoroutine(CountTime());
    //}
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Knife")
        {
            //Time.timeScale = 0f;

            FindObjectOfType<HUDHandler>().ActiveGameState(HUDstate.GameOver);
        }
    }
   
}
