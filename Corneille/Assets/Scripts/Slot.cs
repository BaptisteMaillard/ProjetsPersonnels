using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slot : MonoBehaviour, IDropHandler
{
    public static bool PointerIsOnSlot = false;
    public Image pois;//contient le pois que l'on glisse dans le slot, = null si le slot est vide
    public int id;//contient l'identifiant du slot
    //public bool isOpen; en fait isOpen == (if(id == currentIndex))
    public LevelManager levelManager;//Essayer de le remplir avec le script

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && pois == null && id == LevelManager.currentIndex)//si le curseur est dans le slot ET que le slot est vide ET ouvert 
        {
            pois = eventData.pointerDrag.GetComponent<Image>();//alors on ajoute le pois dans ce slot

            //si le pois que l'on veut déposer est au sol ou en l'air
            if (pois.GetComponent<Pois>().indice == -1)
            {
                FillSlot(eventData); //alors on remplit ce slot et on ouvre le prochain
            }
        }       
    }

    public void PointerOnSlot()
    {
        PointerIsOnSlot = true;
    }

    public void PointerOutSlot()
    {
        PointerIsOnSlot = false;
    }


    public void EmptySlot()
    {    
        //on retire le pois qui était dans ce slot
        pois = null;
        //puis on ferme le prochain slot
        LevelManager.currentIndex--;
        levelManager.UpdateVisuelCosse();
    }


    public void FillSlot(PointerEventData eventData)
    {
        //on attribut la position du pois déplacé à celle du slot
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        //puis on ajoute le pois dans ce slot
        pois = eventData.pointerDrag.GetComponent<Image>();
        //et on donne au pois l'indice du slot qui a été rempli
        pois.GetComponent<Pois>().indice = id;
        //enfin on ouvre le prochain slot si la cosse n'est pas remplie
        if (LevelManager.currentIndex < levelManager.poisDansCosse.Length - 1)
        {
            LevelManager.currentIndex++;
           
            levelManager.UpdateVisuelCosse();
        }
        else
        {
            CheckingWord();
        }
    }

   

    public void CheckingWord()
    {
        string word = "";
        for (int i = 0; i < levelManager.poisDansCosse.Length; i++)
        {
            word+= levelManager.poisDansCosse[i].GetComponent<Slot>().pois.GetComponent<Pois>().grapheme;//On récupère le mot proposé par le joueur
        }

        //Si ce mot est correct
        if (word == levelManager.levelWord)//??????
        {
            //le mot s'ajuste
            //la cosse se referme
            //animation : la cosse rétrécit/grossit puis ne bouge plus + musique


            //On passe au niveau suivant
            SceneManager.LoadScene("NoixLevel");
        }
        //Sinon on recommence le niveau
        else
        {
            //Animation de la cosse de gauche à droite car erreur




            //Puis on recharge la scene
            SceneManager.LoadScene("LamaLevel");
        }



    }

}
