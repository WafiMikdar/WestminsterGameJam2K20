using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class MonsterWall : MonoBehaviour
{
    [SerializeField] private float solidificationAlpha, solidificationDuration, duration = 5f;

    private SpriteRenderer rend;

    private Collider2D coll;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        StartCoroutine(Solidifying());
    }

    private IEnumerator Solidifying()
    {
        float startA = rend.color.a;
        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, solidificationAlpha);
        coll.enabled = false;

        yield return new WaitForSeconds(solidificationDuration);

        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, startA);
        coll.enabled = true;

        Invoke("Remove", duration);
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}