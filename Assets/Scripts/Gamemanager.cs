using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private Texture2D mouseCursor;

    private void Start()
    {
        Cursor.SetCursor(mouseCursor,new Vector2(mouseCursor.width/2,mouseCursor.height/2),CursorMode.Auto);
    }

}
