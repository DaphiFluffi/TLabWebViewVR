using GooglyEyesGames.TicTacToe;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MakeCube : MonoBehaviour
{
    public GameObject cubePrefab;
    //public GameObject whiteCubePrefab;
    //public GameObject newParentPivotObj;
    public int size = 4;
    private Queue<string> alphabetQueue = new Queue<string>();
    private List<string> letterList = new List<string>();
    private Vector3 pivot;
    private Vector3 localSc;
    
    // Start is called before the first frame update
    void Start()
    {
        // no double instantiation beacue we keep everything in editor 
        /*foreach (Transform child in this.transform)
        {
            DestroyImmediate(child.gameObject); // nope
        }*/
        localSc = cubePrefab.GetComponentInChildren<MeshFilter>().transform.localScale;
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz.,=():/*-+?!{}<>[]#_\"$@\\|~&1234567890".ToCharArray();
        char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        foreach (char letter in alphabet)
        {
            alphabetQueue.Enqueue(letter.ToString());
        }
        foreach (char letter in letters)
        {
            letterList.Add(letter.ToString());
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
                    //bool isOutline = (i == 0 || j == 0 || i == size - 1 || j == size - 1);

                    int middle = size / 2;

                    bool isMiddleCube = k == middle && i == middle && j == middle;

                    
                    GameObject newCube = Instantiate(cubePrefab, new Vector3(
                                            (localSc.x + 0.01f) * i,
                                            (localSc.y + 0.01f) * j,
                                            0.01f),
                                            Quaternion.identity,
                                            block.transform);
                    if (isSurfaceCube)
                    {
                         
                         string currentLetter = "";

                         if (alphabetQueue.Count > 0)
                         {
                             currentLetter = alphabetQueue.Dequeue();
                             newCube.name = currentLetter;
                         }
                         else
                         {
                             newCube.name = "noLetter";
                         }
                         newCube.GetComponentInChildren<Text>().text = currentLetter;

                        if (newCube.GetComponent<KeyboardKey>() != null)
                        {

                            newCube.GetComponent<KeyboardKey>().character = currentLetter;
                            if (letterList.Contains(currentLetter)) // if it's a letter that can be upper case
                            {
                                newCube.GetComponent<KeyboardKey>().shiftCharacter = currentLetter.ToUpper();
                            }
                        }
                        else
                        {
                            Debug.Log("Nulll");
                            Debug.Log(newCube != null ? "newCube exists" : "newCube is null");


                        }

                    }
                    else {
                        // leave inner cubes blank
                        newCube.GetComponentInChildren<Text>().text = "";
                    }

                    if (isMiddleCube)
                    {
                        pivot = newCube.transform.position;
                        Debug.Log(pivot);
                    }

                }
            }
            Debug.Log(block.transform.position );

            block.transform.localPosition = new Vector3(
                block.transform.position.x,
                0, //this.transform.localPosition.y,
                (localSc.z + 0.01f) * k);
            //newParentPivotObj.transform.position = pivot;
            //block.transform.parent = null;
            //block.transform.parent = newParentPivotObj.transform;
        }

    }
}