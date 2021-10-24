using UnityEngine;
using UnityEngine.UI;

public class SegmentBar : MonoBehaviour
{
    public float fillingBarAlpha;
    private int amount;
    public int Amount
    {
        get { return amount; }
        set
        {
            amount = value;
            UpdateBar();
        }
    }

    

    private float extra;
    public float Extra
    {
        get { return extra; }
        set
        {
            extra = value;
            UpdateBar();
        }
    }
    public Image[] bars;
    
    public int MaxAmount => bars.Length;
    
    
    private void UpdateBar()
    {
        for (int i = 0; i < MaxAmount; i++)
        {
            if (amount - 1 >= i)
            {
                bars[i].fillAmount = 1;
                bars[i].color = new Color(bars[0].color.r, bars[0].color.g, bars[0].color.b, 1f);
            }
            else if(amount >= i)
            {
                bars[i].fillAmount = extra;
                bars[i].color = new Color(bars[0].color.r, bars[0].color.g, bars[0].color.b, fillingBarAlpha);
            }
            else
            {
                bars[i].fillAmount = 0;
            }
        }
    }
}
