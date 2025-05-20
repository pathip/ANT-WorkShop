using UnityEngine;

public class Player : MonoBehaviour
{
    private LayerMask mask;

    private void Start()
    {
        mask = LayerMask.GetMask("Interactable");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position,
                                Camera.main.transform.forward, 
                                out RaycastHit hit,
                                5f, mask))
            {
                Debug.Log("Quest done");
                IInteractable comp = hit.collider.gameObject.GetComponent<IInteractable>();
                comp.Interact();
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instance.OpenInventoryPanel();
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            GameManager.instance.CloseInventoryPanel();
        }
    }
}
