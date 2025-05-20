using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public InventoryPanel inventoryPanel;

    public void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public float timeCounter = 30f;
    public ItemData target;
    public int targetAmout = 5;

    public TMP_Text timeCounterText;
    public Image targetItemIcon;
    public TMP_Text targetCurrentAmountText;

    public bool isPlayerWin = false;

    private void Start()
    {
        targetItemIcon.sprite = target.itemIcon;
    }

    private void Update()
    {
        if (isPlayerWin)
            return;

        if(timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCounterText.text = timeCounter.ToString();
            targetCurrentAmountText.text = "x " + (targetAmout - InventoryManager.instance.GetItemAmount(target)).ToString();

            if(InventoryManager.instance.GetItemAmount(target) >= targetAmout)
            {
                Debug.Log("Player Win");
                isPlayerWin = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("WinScenes");
            }
        }
        else // Player Lost
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LoseScene");
        }
    }
}
