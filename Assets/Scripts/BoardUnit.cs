using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardUnit : MonoBehaviour, IPointerClickHandler
{
    private bool isInteractable = true;
    
    private Image image;
    private int? type = null;
    public static UnityAction<BoardUnit> OnInteracted { get; set;}

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        GameBoardController.Instance.OnGameWin += HandleGameWin;   
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isInteractable)
            return;
        
        isInteractable = false;
        GameBoardController.Instance.HandleOnInteracted(this);
    }

    public void RestartUnit()
    {
        SetImage(null);
        SetType(null);
        isInteractable = true;
    }

    public void SetImage(Sprite image) => this.image.sprite = image;
    public void HandleGameWin(bool isFirstPlayerWin) => isInteractable = false;
    public void SetType(int? target) => this.type = target;
    public int? Type => type;
    
    
}
