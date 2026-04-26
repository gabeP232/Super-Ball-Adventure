using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaterialChange : MonoBehaviour
{

    private const string MATERIAL_PREF_KEY = "SelectedBallMaterial";

    [SerializeField] private Renderer target;
    // Currently 6 materials
    // index 0: blue, 1: glass, 2: gold, 3: green, 4: purple, 5: lava
    [SerializeField] private Material[] materials = new Material[6];
    

    private void Awake()
    {
        // find a renderer
        if (target == null)
        {
            // find renderer on child "Body"
            Transform body = transform.Find("Body");
            // if no body found
            if (body != null)
            {
                // assign a body and attach the renderer to this obj
                target = body.GetComponent<Renderer>();
            } else
            {
                // use the renderer on the body found
                target = GetComponent<Renderer>();
            }
        }
        // Change the material to whichever material was saved
        showSavedMaterial();

    }

    // When the user clicks to change the material it finds which material and sets it.
    public void SetMaterial(int index)
    {   
        // get material, make sure it is in range
        if (index < 0 || index >= materials.Length) return;

        // set the current material to the material at selected index
        target.material = materials[index];
        // make it persist through scenes and save it
        PlayerPrefs.SetInt(MATERIAL_PREF_KEY, index);
        PlayerPrefs.Save();
    }

    public void showSavedMaterial()
    {
        // set default material to index 0
        int savedIndex = PlayerPrefs.GetInt(MATERIAL_PREF_KEY, 0);

        // check if index is in range and material exists
        if (savedIndex >= 0 && savedIndex < materials.Length && materials[savedIndex] != null)
        {
            // change material to the saved player pref
            target.material = materials[savedIndex];
        }
    }
}
