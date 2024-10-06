using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTurn;
    public int playerID;
    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // credit https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/#mouse_position_world_2D
    private void Update()
    {
        if (isTurn)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z += Camera.main.nearClipPlane;
            transform.position = mousePosition; 
        }
    }

    public IEnumerator FadeOut(float duration)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, counter / duration);

            _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, alpha);
            yield return null;
        }
    }
}
