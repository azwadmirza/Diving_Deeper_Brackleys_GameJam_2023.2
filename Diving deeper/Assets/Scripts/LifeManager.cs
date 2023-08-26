using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lives;
    public Player player;
    public bool canBeHurt;
    private float lastHurt;
    public float hurtCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        lastHurt = Time.time;
        canBeHurt = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastHurt >= hurtCoolDown) 
        {
            lastHurt = Time.time;
            canBeHurt = true;
        }
        if (player.getHurtVal() && canBeHurt)
        {
            for(int i = lives.Length - 1; i >= 0; i--)
            {
                SpriteRenderer spriteRenderer = lives[i].GetComponent<SpriteRenderer>();
                if(spriteRenderer.sprite.name == "heart" && spriteRenderer.color != Color.black)
                {
                    spriteRenderer.color = Color.black;
                    canBeHurt=false;
                    break;
                }
            }
        }
    }
}
