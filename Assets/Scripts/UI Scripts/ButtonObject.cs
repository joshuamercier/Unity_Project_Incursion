using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonObject : MonoBehaviour
{
    [SerializeField]
    protected Button button;
    protected MainManager mainManager;

    private void Awake()
    {
        if (!button)
        {
            button = GetComponent<Button>();
        }
        // dynamically add the callback and main manager
        button.onClick.AddListener(OnClicked);
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    protected virtual void OnClicked()
    {
        Debug.Log("Button was pressed");
    }
}
