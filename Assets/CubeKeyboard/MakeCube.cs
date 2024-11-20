using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Linq;
[ExecuteInEditMode]
public class MakeCube : MonoBehaviour
{
    public GameObject cubePrefab;
    //public GameObject whiteCubePrefab;

    public int size = 4;
    private Queue<string> alphabetQueue = new Queue<string>();

   
    // Start is called before the first frame update
    void Start()
    {
        // no double instantiation beacue we keep everything in editor 
        /*foreach (Transform child in this.transform)
        {
            DestroyImmediate(child.gameObject); // nope
        }*/
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz.,=():/*-+?!{}<>[]#_\"$@\\|~&1234567890".ToCharArray();
        foreach (char letter in alphabet)
        {
            alphabetQueue.Enqueue(letter.ToString());
        }
        BuildMyCube(size);
    }

    private void BuildMyCube(int size)
    {
        for (int k = 0; k < size; k++)
        {
            GameObject block = new GameObject("Block" + k);
            block.transform.parent = this.transform;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool isSurfaceCube =
                        k == 0 || k == size - 1 ||  // front and back faces
                        i == 0 || i == size - 1 ||  // left and right faces
                        j == 0 || j == size - 1;    // top and bottom faces
                    /*bool isOutline = (i == 0 || j == 0 || i == size - 1 || j == size - 1);

                    if (isOutline)
                    {
                        colorPrefab = whiteCubePrefab;
                    }
                    else
                    {
                        colorPrefab = cubePrefab;
                    }*/
                    if (isSurfaceCube)
                    {
                        Instantiate(cubePrefab, new Vector3(
                            (cubePrefab.transform.localScale.x + 0.01f) * i,
                            (cubePrefab.transform.localScale.y + 0.01f) * j,
                            0.01f),
                            Quaternion.identity,
                            block.transform);
                        /* if (colorPrefab.Equals(cubePrefab))
                         {*/
                        TextMeshProUGUI textObj = cubePrefab.GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>();
                        string currentLetter = "";
                        if (alphabetQueue.Count > 0)
                        {
                            currentLetter = alphabetQueue.Dequeue();
                            cubePrefab.name = currentLetter;
                        }
                        else
                        {
                            cubePrefab.name = "noLetter";
                        }
                        textObj.text = currentLetter;
                        /*}
                        else
                        {
                            Debug.Log("It's the white prefab");
                        }*/
                    }

                }
            }
            block.transform.position = new Vector3(
                block.transform.position.x,
                block.transform.position.y,
                (cubePrefab.transform.localScale.z + 0.01f) * k);
        }
    }
}