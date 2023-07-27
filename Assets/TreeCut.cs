using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCut : MonoBehaviour
{
    [SerializeField] GameObject drop;
    [SerializeField] int hitAmount = 5;
    private int hitCount;
    [SerializeField] float spread = 2f;
    [SerializeField] int growingSpeed = 5;
    private Vector3 shrinkScale = new Vector3(-0.01f, -0.01f, -0.01f);
    private bool isTreeBroken = false;

    private void Awake()
    {
        hitCount = hitAmount;
    }

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
    }

    private void Update()
    {
        if (hitCount <= 0 && !isTreeBroken)
        {
            isTreeBroken = true;
            StartCoroutine("GrowBack");
        }
    }

    private void Grow()
    {
        transform.localScale = new Vector3(1f,1f,1f);
        hitCount = hitAmount;
        isTreeBroken = false;
    }

    private IEnumerator GrowBack()
    {
        yield return new WaitForSeconds(growingSpeed);
        Grow();
    }

    public bool GetBrokenState()
    {
        return isTreeBroken;
    }
}
