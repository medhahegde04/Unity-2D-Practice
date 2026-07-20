using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorIcon : MonoBehaviour
{
    public Sprite defaultCursor;
    public Sprite pointingCursor;
    private RectTransform rectTransform;
    private UnityEngine.UI.Image cursorImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        cursorImage = GetComponentInChildren<UnityEngine.UI.Image>();

        Cursor.visible = false;
        DontDestroyOnLoad(transform.root.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        CheckCursorVisibility(SceneManager.GetActiveScene().name);

        ResetCursorTexture();
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

    public void SetHoverState(bool isHovering)
    {
        // Change the cursor icon to the pointer sprite

        if (cursorImage == null) return;

        if (isHovering && pointingCursor != null)
        {
            cursorImage.sprite = pointingCursor;
        }
        else
        {
            ResetCursorTexture();
        }
    }

    private void ResetCursorTexture()
    {
        // Resets the cursor to default sprite

        if (cursorImage != null && defaultCursor != null)
        {
            cursorImage.sprite = defaultCursor;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckCursorVisibility(scene.name);
        ResetCursorTexture();
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
