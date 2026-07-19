using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorIcon : MonoBehaviour
{
    private RectTransform rectTransform;
    private UnityEngine.UI.Image cursorImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // This stops Unity from destroying the cursor when changing scenes

        rectTransform = GetComponent<RectTransform>();
        cursorImage = GetComponentInChildren<UnityEngine.UI.Image>();

        Cursor.visible = false;

        DontDestroyOnLoad(transform.root.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        CheckCursorVisibility(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        // Safety check to make sure both components exist before tracking position
        if (cursorImage != null && cursorImage.enabled && rectTransform != null && Mouse.current != null)
        {
            rectTransform.position = Mouse.current.position.ReadValue();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckCursorVisibility(scene.name);
    }
   
    private void CheckCursorVisibility(string sceneName)
    {
        // Automatically hides the paw if we leave the MainMenu scene

        if (cursorImage == null) return;

        if (sceneName == "Gameplay")
        {
            cursorImage.enabled = false;
        }
        else
        {
            cursorImage.enabled = true;
        }
    }

    private void OnDestroy()
    {
        // Avoids memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
