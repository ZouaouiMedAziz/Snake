using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> Body;
    public Transform BodyPrefab;
    public bool Isdead = false;

    private void Start()
    {
        Body = new List<Transform>();
        Body.Add(this.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ((direction.y != -1))
            {
                direction = Vector2.up;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if ((direction.y != 1))
            {
                direction = Vector2.down;
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if ((direction.x != 1))
            {
                direction = Vector2.left;
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((direction.x != -1))
            {
                direction = Vector2.right;
                transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
    }

    public void UP()
    {
        if ((direction.y != -1))
        {
            direction = Vector2.up;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void Down()
    {
        if ((direction.y != 1))
        {
            direction = Vector2.down;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
    public void Left()
    {
        if ((direction.x != 1))
        {
            direction = Vector2.left;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }

    public void Right()
    {
        if ((direction.x != -1))
        {
            direction = Vector2.right;
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }


    private void FixedUpdate()
    {
        for (int i = Body.Count - 1; i > 0; i--)
        {
            Body[i].position = Body[i - 1].position;
        }
        this.transform.position = new Vector3
        (
        Mathf.Round(this.transform.position.x) + direction.x,
        Mathf.Round(this.transform.position.y) + direction.y,
        0.0f
        );
    }
    public void Grow()
    {
        Transform sbody = Instantiate(this.BodyPrefab);
        sbody.position = Body[Body.Count - 1].position;
        Body.Add(sbody);
    }
    private void ResetState()
    {
        for (int i = 1; i < Body.Count; i++)
        {
            Destroy(Body[i].gameObject);
        }
        Body.Clear();
        Body.Add(this.transform);
        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Food")
        {
            Grow();
           
        } 

        if (other.tag == "obstacle")
        {
            ResetState();
            Isdead = true;
        }



        if (other.gameObject.tag == "LeftS")
            transform.position = new Vector3(12f, transform.position.y, transform.position.z);
        if (other.gameObject.tag == "RightS")
            transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
        if (other.gameObject.tag == "UpS")
            transform.position = new Vector3(transform.position.x, -8.05f, transform.position.z);
        if (other.gameObject.tag == "DownS")
            transform.position = new Vector3(transform.position.x, 8.07f, transform.position.z);
    }


    
}