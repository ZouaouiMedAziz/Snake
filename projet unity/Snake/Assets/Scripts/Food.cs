using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridarea;
    public int SC = 5;
    


    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.gridarea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.Add(SC);
            RandomizePosition();
        }
    }


   
}