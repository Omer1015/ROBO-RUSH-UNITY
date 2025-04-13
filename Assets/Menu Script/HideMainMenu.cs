using UnityEngine;

public class panelscript : MonoBehaviour {

    public GameObject MainMenu;
    public void hidePanel()
    {
        MainMenu.gameObject.SetActive(false);
    }
}
