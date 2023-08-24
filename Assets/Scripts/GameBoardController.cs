using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBoardController : MonoBehaviour
{
    [SerializeField] private List<BoardUnit> boardUnits;
    [SerializeField] private Sprite xImage;
    [SerializeField] private Sprite oImage;
    
    public static GameBoardController Instance;

    public UnityAction<bool> OnGameWin {get; set;}

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

    public void RestartBoard()
    {
        foreach (var unit in boardUnits)
        {
            unit.RestartUnit();
        }
    }

    public void HandleOnInteracted(BoardUnit unit)
    {
        unit.SetImage(isFirstPlayerTurn ? xImage : oImage);
        unit.SetType(isFirstPlayerTurn ? 1 : 0);
        bool isWin = CheckWin(unit);

        if(isWin)
        {
            OnGameWin?.Invoke(isFirstPlayerTurn);
        }
        
        isFirstPlayerTurn = !isFirstPlayerTurn;
    }

    /* 0 1 2
       3 4 5
       6 7 8
    */
    private bool CheckWin(BoardUnit unit)
    {
        int? type = unit.Type;
        switch (boardUnits.IndexOf(unit))
        {
            case 0:
                if (type == boardUnits[1].Type && type == boardUnits[2].Type)
                    return true;
                if (type == boardUnits[3].Type && type == boardUnits[6].Type)
                    return true;
                if (type == boardUnits[4].Type && type == boardUnits[8].Type)
                    return true;
                break;
            case 1:
                if (type == boardUnits[0].Type && type == boardUnits[2].Type)
                    return true;
                if (type == boardUnits[4].Type && type == boardUnits[7].Type)
                    return true;
                break;
            case 2:
                if (type == boardUnits[1].Type && type == boardUnits[0].Type)
                    return true;
                if (type == boardUnits[5].Type && type == boardUnits[8].Type)
                    return true;
                if (type == boardUnits[4].Type && type == boardUnits[6].Type)
                    return true;
                break;
            case 3:
                if (type == boardUnits[0].Type && type == boardUnits[6].Type)
                    return true;
                if (type == boardUnits[4].Type && type == boardUnits[6].Type)
                    return true;
                break;
            case 4:
                if (type == boardUnits[3].Type && type == boardUnits[5].Type)
                    return true;
                if (type == boardUnits[1].Type && type == boardUnits[7].Type)
                    return true;
                if (type == boardUnits[0].Type && type == boardUnits[8].Type)
                    return true;
                break;
            case 5:
                if (type == boardUnits[3].Type && type == boardUnits[4].Type)
                    return true;
                if (type == boardUnits[2].Type && type == boardUnits[8].Type)
                    return true;
                break;
            case 6:
                if (type == boardUnits[0].Type && type == boardUnits[3].Type)
                    return true;
                if (type == boardUnits[7].Type && type == boardUnits[8].Type)
                    return true;
                if (type == boardUnits[2].Type && type == boardUnits[4].Type)
                    return true;
                break;
            case 7:
                if (type == boardUnits[1].Type && type == boardUnits[4].Type)
                    return true;
                if (type == boardUnits[6].Type && type == boardUnits[8].Type)
                    return true;
                break;
            case 8:
                if (type == boardUnits[6].Type && type == boardUnits[7].Type)
                    return true;
                if (type == boardUnits[0].Type && type == boardUnits[4].Type)
                    return true;
                if (type == boardUnits[2].Type && type == boardUnits[5].Type)
                    return true;
                break;
            
        }

        return false;
    }
}
