using UnityEngine.UI;

public static class GraphicExt
{
    public static void SetAlpha( this Graphic self, float alpha )
    {
        var color = self.color;
        color.a = alpha;
        self.color = color;
    }
}