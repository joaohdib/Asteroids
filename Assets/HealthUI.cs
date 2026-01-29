using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public List<GameObject> heartIcons;

    public void UpdateHealthDisplay(int currentHealth)
    {

        for (int i = 0; i < heartIcons.Count; i++)
        {
            Image heartImage = heartIcons[i].GetComponent<Image>();
            if (i < currentHealth)
            {
                heartImage.enabled = true;
                heartImage.color = Color.white; // Or new Color(1, 1, 1, 1f);
            }
            else
            {
                heartImage.color = new Color(1, 1, 1, 0.2f);
            }
        }

    }


}
