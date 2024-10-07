using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<Player> _players;
    
    public float _speed;

    [SerializeField] private Board _board;
    [SerializeField] private Text _text;

    Vector2 _currentPos;
    Vector2 _nextPos;

    float _totalTime;
    float _deltaT;

    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    public int _currentPlayer = 0;
    int _tileMovementAmount;


    public int play1place = 1;
    public int play2place = 2;
    public int play3place = 3;
    public int play4place = 4;

    Die _die = new Die();

    void Start()
    {
        _board.InitTilePositions();
        _text.text = "press space to roll the die";
    }

    void CheckWin()
    {
        if (_gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("BoardGame");
        }

        if ((_players[0].GetCurrentTile() == 30 || _players[1].GetCurrentTile() == 30 || _players[2].GetCurrentTile() == 30 || _players[3].GetCurrentTile() == 30 ) && !_isMoving)
        {
            _gameIsOver = true;
            _text.text = "Game over wahoo. player " + (_currentPlayer + 1) + " wins yay woohoo. press space to do the thing again yay";
        }
    }

    void Update()
    {
        CheckWin();

        if (!_gameIsOver)
        {
            _currentPos = _players[_currentPlayer].GetPosition();

            _text.color = (_currentPlayer == 0) ? Color.magenta : Color.yellow;

            if (Input.GetKeyDown(KeyCode.Space) && _tileMovementAmount == 0)
            {
                _tileMovementAmount = _die.RollDice();
                _text.text = "you rolled a " + _tileMovementAmount.ToString();
                _turnStarted = true;
            }

            if (_tileMovementAmount > 0 && !_isMoving)
            {
                MoveOneTile();
            }

            if (_isMoving)
            {
                UpdatePosition();
            }









            if (_tileMovementAmount == 0 && !_isMoving)
            {

                






                _text.text = "press space to roll the dice yahoo";

                if (_turnStarted)
                {
                    _turnStarted = false;
                    if (_currentPlayer == 0) { 
                    _currentPlayer = 1;
                    }
                    else if (_currentPlayer == 1)
                    {
                        _currentPlayer = 2;
                    }
                    else if (_currentPlayer == 2)
                    {
                        _currentPlayer = 3;
                    }
                    else if (_currentPlayer == 3)
                    {
                        _currentPlayer = 0;
                    }
                }
            }
        }
    }

    void UpdatePosition()
    {
        _deltaT += Time.deltaTime / _totalTime;

        if (_deltaT < 0f)
        {
            _deltaT = 0f;
        }
        if (_deltaT >= 1f || _nextPos == _currentPos)
        {
            _isMoving = false;
            _tileMovementAmount--;
            _deltaT = 0f;
        }

        _players[_currentPlayer].SetPosition(Vector2.Lerp(_currentPos, _nextPos, _deltaT));
    }

    void MoveOneTile()
    {
        _nextPos = _board.GetTilePositions()[_players[_currentPlayer].GetCurrentTile()];
        _totalTime = (_nextPos - _currentPos).magnitude / _speed;
        _isMoving = true;
        _players[_currentPlayer].SetCurrentTile(_players[_currentPlayer].GetCurrentTile() + 1);
    }






}
