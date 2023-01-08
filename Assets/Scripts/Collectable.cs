using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite sprite;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Char")
        {
            col.gameObject.GetComponent<PlayerScript>().inventory.add(this);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE,
    SEED
}
