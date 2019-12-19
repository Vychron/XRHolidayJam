using UnityEngine;

public static class IM {
    
    public static bool MouseDown { get {
            return Input.GetMouseButton(0);
        }
    }

    public static bool MouseUp { get {
            return Input.GetMouseButtonUp(0);
        }
    }

    public static Vector2 MousePosition { get {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

}
