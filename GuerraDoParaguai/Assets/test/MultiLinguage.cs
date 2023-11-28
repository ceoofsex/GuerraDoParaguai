using Assets.SimpleLocalization.Scripts;
using UnityEngine;

public class MultiLinguage : MonoBehaviour
{

    private void Awake()
    {
        //LocalizationManager.Read();
        //LocalizationManager.Language = "Portugues";
    }
    public void Portugues()
    {
        LocalizationManager.Language = "Portugues";
    }
    public void English()
    {
        LocalizationManager.Language = "English";
    }
}
