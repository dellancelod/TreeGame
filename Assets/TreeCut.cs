using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCut : MonoBehaviour
{
    [SerializeField] GameObject drop;
    [SerializeField] int hitCount = 5;
    [SerializeField] float spread = 2f;
    private Vector3 shrinkScale = new Vector3(-0.01f, -0.01f, -0.01f);

    public void Hit()
    {
        if (hitCount > 0)
        {
            hitCount -= 1;
            Vector3 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.z += spread * UnityEngine.Random.value - spread / 2;
            pos.y = 0;

            GameObject go = Instantiate(drop);
            go.transform.position = pos;
            transform.localScale = Vector3.Lerp(transform.localScale, shrinkScale, 0.1f);
        }
        else
        {
            //grow tree back
        }
    }
}
