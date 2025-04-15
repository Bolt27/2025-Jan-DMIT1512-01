using System.Collections;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    private Renderer _myRenderer;
    private Rigidbody2D _myRB;
    void Awake()
    {
        _myRenderer = GetComponent<Renderer>();
        _myRB = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        _myRenderer.material.color = Color.green;
        StartCoroutine("WaitThenFall");
    }
    IEnumerator WaitThenFall()
    {
        yield return new WaitForSeconds(2);
        _myRB.bodyType = RigidbodyType2D.Dynamic;
    }
}
