using UnityEngine;
using UnityEngine.UI;

public class ChangePois : MonoBehaviour // PEUT-�tre RENOMMER EN PoisManager
{
    public static Image[] poisDansCosse;
    public static int currentIndex = 0; /*CONVENTION : currentIndex < poisDansCosse.Length*/
    private void Start()
    {
        poisDansCosse = GetComponentsInChildren<Image>();
        for (int i = 0; i < poisDansCosse.Length; i++)
        {
            poisDansCosse[i].GetComponent<Drop>().id = i;
        }
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
            Debug.LogError("currentIndex sup�rieur ou �gale � la taille de la cosse et c'est pas normal");
        }
    }
}