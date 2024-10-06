using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class TextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _monsterText;

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void SetMonsterText(string text)
    {
        _monsterText.text = text;
    }

    public void Flash()
    {
        _text.outlineWidth = 0.5f;
        StartCoroutine(FadeOut(0.5f));
    }

    public void MonsterFlash()
    { 
        StartCoroutine(MonsterFadeOut(4.0f));
    }

    public void Revert()
    {
        _text.outlineWidth = 0f;
        StartCoroutine(FadeIn(0.5f));
    }

    // credit https://stackoverflow.com/questions/44933517/fading-in-out-gameobject
    IEnumerator FadeOut(float duration)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, counter / duration);

            _text.color = new Color(255f, 255f, 255f, alpha);
            yield return null;
        }
    }

    IEnumerator MonsterFadeOut(float duration)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, counter / duration);

            _monsterText.color = new Color(184f, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeIn(float duration) {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, counter / duration);

            _text.color = new Color(255f, 255f, 255f, alpha);
            yield return null;
        }
    }
}
