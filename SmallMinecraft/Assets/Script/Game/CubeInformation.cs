using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeInformation : MonoBehaviour {

    public GameObject smallCube_soil, smallCube_stone, smallCube_wood, smallCube_grass, smallCube_leaves;
    public GameObject cube_soil, cube_stone, cube_wood, cube_grass, cube_leaves;
    public Sprite     sprite_soil, sprite_stone, sprite_wood, sprite_grass, sprite_leaves;

    public const int soil   = 0;
    public const int stone  = 1;
    public const int wood   = 2;
    public const int grass  = 3;
    public const int leaves = 4;

    public GameObject GetSmallCube( int number )
    {
        switch( number)
        {
            case soil:
                return smallCube_soil;
            case stone:
                return smallCube_stone;
            case wood:
                return smallCube_wood;
            case grass:
                return smallCube_grass;
            case leaves:
                return smallCube_leaves;
            default:
                return null;
        }
    }

    public GameObject GetCube(int number)
    {
        switch (number)
        {
            case soil:
                return cube_soil;
            case stone:
                return cube_stone;
            case wood:
                return cube_wood;
            case grass:
                return cube_grass;
            case leaves:
                return cube_leaves;
            default:
                return null;
        }
    }

    public int GetCubeNumber( string cubeName )
    {
        if (cubeName == "soil")
            return soil;
        else if (cubeName == "stone")
            return stone;
        else if (cubeName == "leaves")
            return leaves;
        else if (cubeName == "grass")
            return grass;
        else if (cubeName == "wood")
            return wood;
        else
            return -1;
    }

    public Sprite GetCubeSprite( int number)
    {
        switch (number)
        {
            case soil:
                return sprite_soil;
            case stone:
                return sprite_stone;
            case wood:
                return sprite_wood;
            case grass:
                return sprite_grass;
            case leaves:
                return sprite_leaves;
            default:
                return null;
        }
    }
}
