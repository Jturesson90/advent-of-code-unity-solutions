using System;
using System.Collections.Generic;
using AdventOfCode_2023;
using TMPro;
using UnityEngine;

public class Behaviour202310A : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject prefabWithText;
    [SerializeField] private PuzzleInput puzzleInput;
    [SerializeField] private string custom;
    private static readonly int Color1 = Shader.PropertyToID("_Color");

    public enum PuzzleInput
    {
        Real,
        ExampleOne,
        ExampleTwo,
        ExampleThree,
        ExampleFour,
        Custom
    }

    private void Start()
    {
        string input = puzzleInput switch
        {
            PuzzleInput.Real => Resources.Load<TextAsset>("AdventOfCode/2023/10").text,
            PuzzleInput.ExampleOne => ".....\n.S-7.\n.|.|.\n.L-J.\n.....",
            PuzzleInput.ExampleTwo => "..F7.\n.FJ|.\nSJ.L7\n|F--J\nLJ...",
            PuzzleInput.ExampleThree => "7-F7-\n.FJ|7\nSJLL7\n|F--J\nLJ.LJ",
            PuzzleInput.ExampleFour =>
                "...........\n.S-------7.\n.|F-----7|.\n.||.....||.\n.||.....||.\n.|L-7.F-J|.\n.|..|.|..|.\n.L--J.L--J.\n...........",
            PuzzleInput.Custom => custom,
            _ => throw new ArgumentOutOfRangeException()
        };

        int answer = int.Parse(Day10.PuzzleB(input, out var data));

        var posByGo = new Dictionary<(int Row, int Col), GameObject>();
        foreach (var vvv in data.Dots)
        {
            var go = Instantiate(prefab);
            go.transform.SetPositionAndRotation(new Vector3(vvv.Col, 0, -vvv.Row),
                Quaternion.identity);
            go.GetComponent<MeshRenderer>().material
                .SetColor(Color1, Color.blue);
            go.transform.localScale = new Vector3(0.3f, 2, 0.3f);
        }

        foreach (var vvv in data.PositionsByDistance)
        {
            var go = Instantiate(puzzleInput == PuzzleInput.Real ? prefab : prefabWithText);
            go.transform.SetPositionAndRotation(new Vector3(vvv.Key.Col, 0, -vvv.Key.Row),
                Quaternion.identity);
            posByGo.Add(vvv.Key, go);
            go.GetComponent<MeshRenderer>().material
                .SetColor(Color1, Color.Lerp(Color.green, Color.red, vvv.Value / (float)answer));
            if (puzzleInput != PuzzleInput.Real)
                go.GetComponentInChildren<TMP_Text>().text = vvv.Value.ToString();

            const float d = 0.25f;
            switch (data.TypeLookup[vvv.Key])
            {
                case "S":
                    break;
                case "|":
                    //  go.transform.localScale = new Vector3(1, 1, 1);
                    break;
                case "-":
                    //    go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, 90);
                    break;
                case "L":
                    go.transform.Translate(new Vector3(d, 0, d), Space.Self);
                    //   go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, 45);
                    break;
                case "J":
                    go.transform.Translate(new Vector3(-d, 0, d), Space.Self);
                    //     go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, -45);
                    break;
                case "7":
                    go.transform.Translate(new Vector3(-d, 0, -d), Space.Self);
                    //      go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, 45);
                    break;
                case "F":
                    go.transform.Translate(new Vector3(d, 0, -d), Space.Self);
                    //     go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, -45);
                    break;
            }
        }

        foreach (var vvv in data.Missing)
        {
            var go = Instantiate(puzzleInput == PuzzleInput.Real ? prefab : prefabWithText);
            go.transform.SetPositionAndRotation(new Vector3(vvv.Key.Col, 0, -vvv.Key.Row),
                Quaternion.identity);
            posByGo.Add(vvv.Key, go);
            go.GetComponent<MeshRenderer>().material
                .SetColor(Color1, Color.black);

            const float d = 0.25f;
            switch (data.TypeLookup[vvv.Key])
            {
                case "S":
                    break;
                case "|":
                    go.transform.localScale = new Vector3(0.3f, 1, 1);
                    break;
                case "-":
                    go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, 90);
                    break;
                case "L":
                    go.transform.Translate(new Vector3(d, 0, d), Space.Self);
                    go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, 45);
                    break;
                case "J":
                    go.transform.Translate(new Vector3(-d, 0, d), Space.Self);
                    go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, -45);
                    break;
                case "7":
                    go.transform.Translate(new Vector3(-d, 0, -d), Space.Self);
                    go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, 45);
                    break;
                case "F":
                    go.transform.Translate(new Vector3(d, 0, -d), Space.Self);
                    go.transform.localScale = new Vector3(0.3f, 1, 1);
                    go.transform.Rotate(Vector3.down, -45);
                    break;
            }
        }

        int len = data.Path.Count;
        for (var i = 0; i < len; i++)
            posByGo[data.Path[i]].GetComponent<MeshRenderer>().material
                .SetColor(Color1, Color.Lerp(Color.magenta, Color.black, i / (float)len));

        posByGo[data.StartingPoint].transform.localScale = new Vector3(1, 20, 1);
        posByGo[data.EndPoint].transform.localScale = new Vector3(1, 20, 1);
    }
}