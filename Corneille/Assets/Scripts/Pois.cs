using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasGroup))]

public class Pois : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;
    public Vector2 initialPos;
    public int indice = -1;
    public string grapheme;
    public LevelManager levelManager;//Essayer de le remplir avec le script

    
   
    
    void Awake()
    {
        grapheme = GetComponentInChildren<Text>().text;
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponentInParent<CanvasGroup>();
        initialPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    { 
        //si ce pois est au sol ou est le dernier pois � avoir �t� d�pos�
        if (indice == -1 || indice == LevelManager.currentIndex - 1)
        {
            
            //si en particulier ce pois est le dernier � avoir �t� d�pos�
            if (indice == LevelManager.currentIndex - 1 && indice != -1)
            {
                //alors on vide le slot qui le contenait c'est-�-dire celui dont l'id est currentIndex-1
                levelManager.poisDansCosse[LevelManager.currentIndex - 1].GetComponent<Slot>().EmptySlot();    
            }

            //alors on l'autorise � bouger
            indice = -1;
            canvasGroup.alpha = 0.5f;
            canvasGroup.blocksRaycasts = false;
        }      
    }

    public void OnDrag(PointerEventData eventData)
    {
        //si ce pois est au sol ou est le dernier pois � avoir �t� d�pos�
        if (indice == -1 || indice == LevelManager.currentIndex - 1)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;//on d�place ce pois 
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (indice == -1)//si ce pois est au sol ou en l'air
        {
            rectTransform.anchoredPosition = initialPos;//alors on remet le pois � sa position initiale
        }       
    }
}
