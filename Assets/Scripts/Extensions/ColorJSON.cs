using UnityEngine;

[System.Serializable]
public struct ColorJSON
{
    public float r;
    public float g;
    public float b;
    public float a;

    public static implicit operator Color(ColorJSON c)
    {
        return new Color(c.r, c.g, c.b, c.a);
    }

    public static implicit operator ColorJSON(Color c)
    {
        return new ColorJSON{ r = c.r, g = c.g, b = c.b, a = c.a };
    }
}