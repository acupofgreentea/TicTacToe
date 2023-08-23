using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{
    [SerializeField] private List<BoardUnit> boardUnits;
    [SerializeField] private Sprite xImage;
    [SerializeField] private Sprite oImage;
    
    public static GameBoardController Instance;

    private bool isFirstPlayerTurn = true;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }

    public void HandleOnInteracted(BoardUnit unit)
    {
        unit.SetImage(isFirstPlayerTurn ? xImage : oImage);
        unit.SetType(isFirstPlayerTurn ? 1 : 0);
        isFirstPlayerTurn = !isFirstPlayerTurn;
    }

    /* 0 1 2
       3 4 5
       6 7 8
    */
    private bool CheckWin(BoardUnit unit)
    {
        int? type = unit.GetType;
        switch (boardUnits.IndexOf(unit))
        {
            case 0:
                if (type == boardUnits[1].GetType && type == boardUnits[2].GetType)
                    return true;
                if (type == boardUnits[3].GetType && type == boardUnits[6].GetType)
                    return true;
                if (type == boardUnits[4].GetType && type == boardUnits[8].GetType)
                    return true;
                break;
            case 1:
                if (type == boardUnits[0].GetType && type == boardUnits[2].GetType)
                    return true;
                if (type == boardUnits[4].GetType && type == boardUnits[7].GetType)
                    return true;
                break;
            case 2:
                if (type == boardUnits[1].GetType && type == boardUnits[0].GetType)
                    return true;
                if (type == boardUnits[5].GetType && type == boardUnits[8].GetType)
                    return true;
                if (type == boardUnits[4].GetType && type == boardUnits[6].GetType)
                    return true;
                break;
            case 3:
                if (type == boardUnits[0].GetType && type == boardUnits[6].GetType)
                    return true;
                if (type == boardUnits[4].GetType && type == boardUnits[6].GetType)
                    return true;
                break;
            case 4:
                if (type == boardUnits[3].GetType && type == boardUnits[5].GetType)
                    return true;
                if (type == boardUnits[1].GetType && type == boardUnits[7].GetType)
                    return true;
                if (type == boardUnits[0].GetType && type == boardUnits[8].GetType)
                    return true;
                break;
            case 5:
                if (type == boardUnits[3].GetType && type == boardUnits[4].GetType)
                    return true;
                if (type == boardUnits[2].GetType && type == boardUnits[8].GetType)
                    return true;
                break;
            case 6:
                if (type == boardUnits[0].GetType && type == boardUnits[3].GetType)
                    return true;
                if (type == boardUnits[7].GetType && type == boardUnits[8].GetType)
                    return true;
                if (type == boardUnits[2].GetType && type == boardUnits[4].GetType)
                    return true;
                break;
            case 7:
                if (type == boardUnits[1].GetType && type == boardUnits[4].GetType)
                    return true;
                if (type == boardUnits[6].GetType && type == boardUnits[8].GetType)
                    return true;
                break;
            case 8:
                if (type == boardUnits[6].GetType && type == boardUnits[7].GetType)
                    return true;
                if (type == boardUnits[0].GetType && type == boardUnits[4].GetType)
                    return true;
                if (type == boardUnits[2].GetType && type == boardUnits[5].GetType)
                    return true;
                break;
            
        }

        return false;
    }
}
