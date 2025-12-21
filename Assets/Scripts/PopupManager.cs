using UnityEngine;

public class PopupManager : MonoBehaviour
{
    
   public static PopupManager instance;
    public GameObject prefabPoints;
    private void Start()
    {
        instance = this;
    }



    public void CreatePopup(Vector3 pos, int points)
    {
        GameObject pointVisuel = Instantiate(prefabPoints , pos, Quaternion.identity,transform);
        Popup popup = pointVisuel.GetComponent<Popup>();
        popup.Initialise(points);
    }

}
