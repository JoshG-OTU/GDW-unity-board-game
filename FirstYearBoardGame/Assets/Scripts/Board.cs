using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    [SerializeField] private Transform _initialTransform;



    private Vector2[] _tilePositions = new Vector2[100];


    public int whofirst;

    public int whosecond;

    public int whothird;

    public int whofourth;








    public Vector2[] GetTilePositions()
    {
        return _tilePositions;
    }

    public void InitTilePositions()
    {
        bool reverse = false;

        _tilePositions[0] = new Vector2(_initialTransform.position.x, _initialTransform.position.y);

        for (int i = 1; i < 100; i++)
        {
            if (i % 10 == 0)
            {
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(0f, 1f);
            }
            else if (!reverse)
            {
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(1f, 0f);
            }
            else
            {
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(-1f, 0f);
            }

            if ((i + 1) % 10 == 0)
            {
                reverse = !reverse;
            }
        }
    }
}
