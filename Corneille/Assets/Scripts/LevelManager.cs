using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour // PEUT-être RENOMMER EN PoisManager
{
    public Image[] poisDansCosse;
    public string levelWord;//Le mot à écrire pour ce niveau
    //public int sceneNumber;
    //public string word;//Le mot actuel formé par les pois dans la cosse 
    public static int currentIndex = 0; /*CONVENTION : currentIndex < poisDansCosse.Length*/
    private void Start()
    {
        currentIndex = 0;
        UpdateVisuelCosse();
    }

  

    public void UpdateVisuelCosse()
    {
        if (currentIndex == 0)
        {
            poisDansCosse[currentIndex].sprite = Resources.Load<Sprite>("Decors/POIS BLANC DANS LA COSSE");
            poisDansCosse[1].sprite = Resources.Load<Sprite>("Decors/POIS DANS LA COSSE");
        }
        else if (currentIndex > 0 && currentIndex < poisDansCosse.Length - 1)
        {
            poisDansCosse[currentIndex].sprite = Resources.Load<Sprite>("Decors/POIS BLANC DANS LA COSSE");
            poisDansCosse[currentIndex + 1].sprite = Resources.Load<Sprite>("Decors/POIS DANS LA COSSE");           
        }
        else if (currentIndex == poisDansCosse.Length - 1)
        {
            poisDansCosse[currentIndex].sprite = Resources.Load<Sprite>("Decors/POIS BLANC DANS LA COSSE");
        }
        else
        {
            Debug.LogError("currentIndex supérieur ou égale à la taille de la cosse et c'est pas normal");
        }
    }
}
