using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Maze : MonoBehaviour {
    public static int height = 0;
    public static int width = 0;
	public string path;
    public GameObject Pacman;
    public GameObject Blinky;
    public GameObject Pinky;
    public GameObject Inky;
    public GameObject Clyde;
	public GameObject wall;
	public GameObject dot;
    public GameObject upleft;
    public GameObject upright;
    public GameObject bigbleft;
    public GameObject bigbright;
    public GameObject biguleft;
    public GameObject biguright;
    public GameObject horizontal;
    public GameObject hori;
    public GameObject vert;
    public GameObject vertr;
    public GameObject bleft;
    public GameObject bright;
    public GameObject uleft;
    public GameObject uright;

    // Use this for initialization
    void Start() {
		CreateMaze();	
	}

	void CreateMaze() {
		string[] text = System.IO.File.ReadAllLines(@path).Select(l => l.Trim()).ToArray();
		Debug.Log("Reading " + text[0].Length + "x" + text.Length + " array.");
        height = text[0].Length; width = text.Length;

		//for (int y = text.Length-1; y >= 0; y--) {
        for(int y = 0; y < text.Length; y++) {
			for (int x = 0; x < text[y].Length; x++) {
				if (text[y][x] == '#') {
                    //Instantiate(bigbleft, new Vector3(x-14, text.Length-y-16, 0), Quaternion.identity);
                    if (y == 0)
                    {
                        if (x == 0)
                        {
                            Instantiate(biguleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                        if(x == 27)
                        {
                            Instantiate(biguright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                        else
                        {
                            Instantiate(hori, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                    }
                    if(x == 0)
                    {
                        if(y == 30)
                        {
                            Instantiate(bigbleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                        if (text[y-1][x] == '#')
                        {
                            if(text[y+1][x] == '#')
                            {
                                Instantiate(vert, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                                continue;
                            }
                            else
                            {
                                Instantiate(bigbleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                                continue;
                            }
                        }
                        if(text[y+1][x] == '#')
                        {
                            Instantiate(biguleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                    }
                    if(y == 30)
                    {
                        if(x == 27)
                        {
                            Instantiate(bigbright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                        else
                        {
                            Instantiate(horizontal, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                    }
                    if(x == 27)
                    {
                        if(text[y - 1][x] == '#')
                        {
                            if (text[y + 1][x] == '#')
                            {
                                Instantiate(vertr, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                                continue;
                            }
                            else
                            {
                                Instantiate(bigbright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                                continue;
                            }
                        }
                        if(text[y + 1][x] == '#')
                        {
                            Instantiate(biguright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                            continue;
                        }
                    }
                    if (text[y + 1][x] == '#' && text[y - 1][x] == '#' && text[y][x - 1] == '#' && text[y][x + 1] == '#' && text[y+1][x+1] == '#' && text[y+1][x-1] == '#' && text[y-1][x+1] == '#' && text[y-1][x-1] == '#')
                    {
                        //Instantiate(wall, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if(text[y][x+1] == '#' && text[y+1][x] == '#' && text[y-1][x] != '#' && text[y][x-1] != '#')
                    {
                        Instantiate(biguleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x + 1] == '#' && text[y - 1][x] == '#' && text[y + 1][x] != '#' && text[y][x - 1] != '#')
                    {
                        Instantiate(bigbleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x - 1] == '#' && text[y - 1][x] == '#' && text[y + 1][x] != '#' && text[y][x + 1] != '#')
                    {
                        Instantiate(bigbright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x + 1] == '#' && text[y + 1][x] == '#' && text[y - 1][x] == '#' && text[y][x - 1] == '#' && text[y-1][x+1] != '#')
                    {
                        Instantiate(bleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x + 1] == '#' && text[y + 1][x] == '#' && text[y - 1][x] == '#' && text[y][x - 1] == '#' && text[y - 1][x - 1] != '#')
                    {
                        Instantiate(bright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x + 1] == '#' && text[y + 1][x] == '#' && text[y - 1][x] == '#' && text[y][x - 1] == '#' && text[y + 1][x - 1] != '#')
                    {
                        Instantiate(uright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x + 1] == '#' && text[y + 1][x] == '#' && text[y - 1][x] == '#' && text[y][x - 1] == '#' && text[y + 1][x + 1] != '#')
                    {
                        Instantiate(uleft, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y+1][x] == '#' && text[y-1][x] == '#' && text[y][x-1] != '#' && text[y][x+1] == '#')
                    {
                        Instantiate(vert, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y + 1][x] == '#' && text[y - 1][x] == '#' && text[y][x - 1] == '#' && text[y][x + 1] != '#')
                    {
                        Instantiate(vertr, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x+1] == '#' && text[y][x-1] == '#' && text[y-1][x] != '#' && text[y+1][x] == '#')
                    {
                        Instantiate(hori, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    if (text[y][x + 1] == '#' && text[y][x - 1] == '#' && text[y - 1][x] == '#' && text[y + 1][x] != '#')
                    {
                        Instantiate(horizontal, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
                    else
                    {
                        Instantiate(biguright, new Vector3(x - 14, text.Length - y - 16, 0), Quaternion.identity);
                        continue;
                    }
				}
				else if (text[y][x] == 'o') {
					Instantiate(dot, new Vector3(x-14, text.Length-y-16, 0), Quaternion.identity);
				}
                else if (text[y][x] == '!') {
                    Instantiate(Pacman, new Vector3(x-14, text.Length-y-16, 0), Quaternion.identity);
                }
                else if (text[y][x] == 'B') {
                    Instantiate(Blinky, new Vector3(x-14, text.Length-y-16, 0), Quaternion.identity);
                }
                else if (text[y][x] == 'P') {
                    Instantiate(Pinky, new Vector3(x-14, text.Length-y-16, 0), Quaternion.identity);
                }
                else if (text[y][x] == 'I') {
                    Instantiate(Inky, new Vector3(x-14, text.Length-y-16, 0), Quaternion.identity);
                }
                else if (text[y][x] == 'C') {
                    Instantiate(Clyde, new Vector3(x-14, text.Length-y-16, 0), Quaternion.identity);
                }
			}
		}
	}
}