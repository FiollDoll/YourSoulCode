using UnityEngine;
public class lvlMenu : MonoBehaviour
{
    [SerializeField] private Transform panel;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 directionPos;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        
        switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos.x = touch.position.x;
                    break;

                case TouchPhase.Moved:
                    directionPos.x = touch.position.x - startPos.x;
                    break;
            }
        }
        panel.localPosition = new Vector2(directionPos.x, 0);
    }
}
