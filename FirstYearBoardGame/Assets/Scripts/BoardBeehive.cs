using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BoardBeehive : MonoBehaviour
{
    [SerializeField] private Transform _initialTransform;

    Vector2[] _tilePositions = new Vector2[100];

    public Vector2[] GetTilePositions()
    {
        return _tilePositions;
    }

    public void initTilePositions()
    {
        bool reverse = false;


        _tilePositions[0] = new Vector2(_initialTransform.position.x, _initialTransform.position.y);

        for (int i = 1; i < 18; i++)
        {
            if (i % 6 == 0)
            {
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(1f, 0f);
            }
            else if (!reverse)
            {
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(0f, 1f);

            }
            else if (reverse)
            {
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(-1f, 0f);

            }

            if ((i + 1) % 6 == 0)
            {
                reverse = !reverse;
            }
        }
    }
}
