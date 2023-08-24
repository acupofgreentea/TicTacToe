using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class GameBoardController : MonoBehaviour
{
    [SerializeField] private List<BoardUnit> boardUnits;
    [SerializeField] private Sprite xImage;
    [SerializeField] private Sprite oImage;
    
    public static GameBoardController Instance;

    public UnityAction<bool> OnGameWin {get; set;}
    public UnityAction OnGameDraw {get; set;}

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
        else
        {
            bool isDraw = boardUnits.All(x => !x.IsInteractable);

            if(isDraw)
                OnGameDraw?.Invoke();
        }
        
        isFirstPlayerTurn = !isFirstPlayerTurn;
    }

    /* 0 1 2
       3 4 5
       6 7 8
    */
    private bool CheckWin(BoardUnit unit)
    {
        switch (boardUnits.IndexOf(unit))
        {
            case 0:
                if (unit == boardUnits[1] && unit == boardUnits[2])
                    return true;
                if (unit == boardUnits[3] && unit == boardUnits[6])
                    return true;
                if (unit == boardUnits[4] && unit == boardUnits[8])
                    return true;
                break;
            case 1:
                if (unit == boardUnits[0] && unit == boardUnits[2])
                    return true;
                if (unit == boardUnits[4] && unit == boardUnits[7])
                    return true;
                break;
            case 2:
                if (unit == boardUnits[1] && unit == boardUnits[0])
                    return true;
                if (unit == boardUnits[5] && unit == boardUnits[8])
                    return true;
                if (unit == boardUnits[4] && unit == boardUnits[6])
                    return true;
                break;
            case 3:
                if (unit == boardUnits[0] && unit == boardUnits[6])
                    return true;
                if (unit == boardUnits[4] && unit == boardUnits[6])
                    return true;
                break;
            case 4:
                if (unit == boardUnits[3] && unit == boardUnits[5])
                    return true;
                if (unit == boardUnits[1] && unit == boardUnits[7])
                    return true;
                if (unit == boardUnits[0] && unit == boardUnits[8])
                    return true;
                break;
            case 5:
                if (unit == boardUnits[3] && unit == boardUnits[4])
                    return true;
                if (unit == boardUnits[2] && unit == boardUnits[8])
                    return true;
                break;
            case 6:
                if (unit == boardUnits[0] && unit == boardUnits[3])
                    return true;
                if (unit == boardUnits[7] && unit == boardUnits[8])
                    return true;
                if (unit == boardUnits[2] && unit == boardUnits[4])
                    return true;
                break;
            case 7:
                if (unit == boardUnits[1] && unit == boardUnits[4])
                    return true;
                if (unit == boardUnits[6] && unit == boardUnits[8])
                    return true;
                break;
            case 8:
                if (unit == boardUnits[6] && unit == boardUnits[7])
                    return true;
                if (unit == boardUnits[0] && unit == boardUnits[4])
                    return true;
                if (unit == boardUnits[2] && unit == boardUnits[5])
                    return true;
                break;
            
        }

        return false;
    }
}
