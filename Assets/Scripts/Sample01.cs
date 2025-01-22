using UnityEngine;

public enum RAINBOW
{
    RED,
    ORANGE,
    YELLOW,
    GREEN,
    BLUE,
    INDIGO,
    VIOLET
}


[AddComponentMenu("GS/Sample01")]




public class Sample01 : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>

    public bool isJumpAble = true;
    public string[] basket_fruits = null;
    public int money = 0;

    [Range(1f, 99f)] public float field_view;

    public RAINBOW rainbow;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
