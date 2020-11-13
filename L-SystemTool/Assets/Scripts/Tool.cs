///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            LSystemGeneration.cs
///     Author:          Morgan Samuel Ellis
///     Date Created:    30/09/20
///     Brief:           Main file for the project which controls the generation of the trees and the different patterns.
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;

public class Tool : EditorWindow
{

    GameObject Tree = null;
    GameObject treeParent; // This groups together our branches under a single parent
    GameObject branch; // This is what will make up our trees
    GameObject treeSegment; // this will be used to give our individual branches settings based on the pattern
    GameObject cube;
    GameObject cubeSegment;

    float treeAngle;
    float treeHeight;
    float treeWidth;
    int treeIterations;
    string treeAxiom;
    private string treeCurrentString;
    string treeKey;
    string treeRules;

    Dictionary<char, string> rules = new Dictionary<char, string>();
    Stack<TransformInfo> transformStack;

    Color lineColour = Color.green;

    private Texture2D tree1;

    [MenuItem("Tools/L-System Generator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Tool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Create New Tree", EditorStyles.boldLabel);

        //Tree = EditorGUILayout.ObjectField("Tree", Tree, typeof(GameObject), false) as GameObject;
        branch = EditorGUILayout.ObjectField("Branch", branch, typeof(GameObject), false) as GameObject;
        treeParent = EditorGUILayout.ObjectField("Parent", treeParent, typeof(GameObject), false) as GameObject;
        cube = EditorGUILayout.ObjectField("cube", cube, typeof(GameObject), false) as GameObject;
        treeAngle = EditorGUILayout.FloatField("Angle", treeAngle);
        treeHeight = EditorGUILayout.FloatField("Height", treeHeight);
        treeWidth = EditorGUILayout.FloatField("Width", treeWidth);
        treeIterations = EditorGUILayout.IntField("Iterations", treeIterations);
        treeAxiom = EditorGUILayout.TextField("Axiom", treeAxiom);
        //treeCurrentString = EditorGUILayout.TextField("Current String", treeCurrentString);
        treeKey = EditorGUILayout.TextField("Key", treeKey);
        treeRules = EditorGUILayout.TextField("Rules", treeRules);

        if (GUILayout.Button("Generate Tree"))
        {
            Generate();
            branch.transform.position = Vector2.zero;
            branch.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }

        if (GUILayout.Button("Reset Variables"))
        {
            treeAngle = 0;
            treeWidth = 0;
            treeHeight = 0;
            treeIterations = 0;
            treeCurrentString = treeAxiom;
        }

        if (GUILayout.Button("Change Axiom"))
        {
            treeCurrentString = treeAxiom;
        }

        if (GUILayout.Button("Reset Axiom"))
        {
            treeAxiom = null;
        }

        if (GUILayout.Button("Update Dictionary"))
        {
            rules.Add(treeKey[0], treeRules);
        }

        if (GUILayout.Button("Reset Dictionary"))
        {
            treeRules = null;
            treeKey = null;
            rules.Clear();
        }

        lineColour = EditorGUILayout.ColorField("Change Color", lineColour);
    }

    private void Generate()
    {
        transformStack = new Stack<TransformInfo>();

        treeCurrentString = treeAxiom;

        Tree = Instantiate(treeParent);
        StringBuilder sb = new StringBuilder();



        LineRenderer lineRenderer = branch.GetComponent<LineRenderer>();
        Debug.Log(treeCurrentString);
        for (int i = 0; i < treeIterations; i++)
        {
            foreach (char c in treeCurrentString)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
            }
            treeCurrentString = sb.ToString();
            sb = new StringBuilder();
        }

        foreach (char c in treeCurrentString)
        {
            switch (c)
            {
                case 'F':

                    // set intialPosition to a position part of a transform componenet which allows for the position of the
                    // branches to be changed
                    Vector3 initialPosition = branch.transform.position;
                    branch.transform.Translate(Vector3.forward * treeHeight); // This moves the transform up based on the value on length

                    treeSegment = Instantiate(branch); // creates a new branch under the gameobject treesegment
                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPosition); // set the starting position of this branch to initial position
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, branch.transform.position); // set the final position of this branch to the transform 
                    treeSegment.GetComponent<LineRenderer>().startWidth = treeWidth; // How wide we want the branches at the start
                    treeSegment.GetComponent<LineRenderer>().endWidth = treeWidth; // How wide we want the branches at the end
                    treeSegment.GetComponent<LineRenderer>().material = new Material(Shader.Find("Sprites/Default")); // Create a new material so we can change the colour of the line renderer
                    treeSegment.GetComponent<LineRenderer>().startColor = lineColour; // Set the startcolour to our defined start colour
                    treeSegment.GetComponent<LineRenderer>().endColor = lineColour; // Set the endcolour to our defined end colour
                    treeSegment.transform.SetParent(Tree.transform); // Attach all these branches to a single parent to organise the heirarch

                    cubeSegment = Instantiate(cube);
                    cubeSegment.transform.position = initialPosition;
                    cubeSegment.transform.position = branch.transform.position;
                    cubeSegment.transform.localScale = new Vector3(treeWidth, treeHeight, treeWidth);
                    treeSegment.transform.SetParent(Tree.transform);

                    break;
                case 'a':
                    break;
                case 'b':
                    break;
                case 'c':
                    break;
                case 'd':
                    break;
                case 'e':
                    break;
                case 'f':
                    break;
                case 'g':
                    break;
                case 'h':
                    break;
                case 'i':
                    break;
                case 'j':
                    break;
                case 'k':
                    break;
                case 'm':
                    break;
                case 'n':
                    break;
                case 'o':
                    break;
                case 'p':
                    break;
                case 'q':
                    break;
                case 'r':
                    break;
                case 's':
                    break;
                case 't':
                    break;
                case 'u':
                    break;
                case 'v':
                    break;
                case 'w':
                    break;
                case 'x':
                    break;
                case 'y':
                    break;
                case 'z':
                    break;
                case 'A':
                    break;
                case 'B':
                    break;
                case 'C':
                    break;
                case 'D':
                    break;
                case 'E':
                    break;
                case 'G':
                    break;
                case 'H':
                    break;
                case 'I':
                    break;
                case 'J':
                    break;
                case 'K':
                    break;
                case 'L':
                    break;
                case 'M':
                    break;
                case 'N':
                    break;
                case 'O':
                    break;
                case 'P':
                    break;
                case 'Q':
                    break;
                case 'R':
                    break;
                case 'S':
                    break;
                case 'T':
                    break;
                case 'U':
                    break;
                case 'V':
                    break;
                case 'W':
                    break;
                case 'X': // if there is a X in the rule set then no action is performed
                    break;
                case 'Y':
                    break;
                case 'Z':
                    break;
                case '+':
                    branch.transform.Rotate(Vector3.up * treeAngle); // A plus is going to rotate the branch using the positive value of our defined angle
                    cube.transform.Rotate(Vector3.up * treeAngle);
                    break;
                case '-':
                    branch.transform.Rotate(Vector3.up * -treeAngle); // A minus is going to rotate the branch using the negative value of our defined angle
                    cube.transform.Rotate(Vector3.up * -treeAngle);
                    break;
                case '[':
                    transformStack.Push(new TransformInfo() // Adds this information into our transform stack to be used
                    {
                        position = branch.transform.position,
                        rotation = branch.transform.rotation
                    });
                    break;
                case ']':
                    {
                        TransformInfo ti = transformStack.Pop(); // removes this information from our transform stack
                        branch.transform.position = ti.position;
                        branch.transform.rotation = ti.rotation;
                    }
                    break;
                default:
                    throw new InvalidOperationException("Invalid L-tree operation"); // if something was in the rule set that was not defined this error will be thrown.
            }
        }

        treeHeight /= 2; // after the for loop if done the length and width are halved.
        treeWidth /= 2;
        Debug.Log(treeCurrentString);
        Debug.Log("Generate");
    }
}