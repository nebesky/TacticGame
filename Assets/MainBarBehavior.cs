using TMPro;
using UnityEngine;

public class MainBarBehavior : MonoBehaviour
{
    public TextMeshProUGUI caption;
    public void SetCaption(string name)
    {
        caption.text = name;
    }
}