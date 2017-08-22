using UnityEngine;
using System.Collections;

public class cubeok_new : MonoBehaviour
{

    public int[,] map;
    public static int[,] samplace;
    public int row_m;
    public int col_m;
    public static int index;
    private int starting_x=0, starting_y=0;

    public cubeok_new(int row,int col,int[] map, int x, int y)
    {
        this.map = new int[row, col];
        this.row_m = row;
        this.col_m = col;
        this.starting_x = x;
        this.starting_y = y;
        int k = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                this.map[i, j] = map[k];
                k++;
            }
        }

    }

    public int start()
    {

        samplace = new int[200, 2];
        for (int i = 0; i < 200; i++) { samplace[i, 0] = 0; samplace[i, 1] = 101; }
        index = 1;
        int result = ok(starting_x, starting_y, 0, 111);

        // Debug.Log("최소 이동 횟수");
        //Debug.Log(result);
        return result;


    }

    bool same(int x, int y, int count)
    {

        int k = x * 100 + y;
        if (k == 0)
        {
            return true;
        }
        else
        {
            for (int i = 1; i <= index; i++)
            {
                if (samplace[i, 0] == k)
                {
                    if (count < samplace[i, 1])
                    {
                        samplace[i, 1] = count;
                        return true;
                    }
                    return false;
                }

            }
            samplace[index, 0] = k;
            samplace[index, 1] = count;
            index++;
            return true;

        }

    }
    int ok(int x, int y, int count, int ca)
    {

        int c0 = 201, c1 = 201, c2 = 201, c3 = 201;

        if (count > 200) { return 201; }
        else
        {
            switch (ca)
            {
                case 0:
                    count++;
                    while (map[y + 1, x] != 1)
                    {
                        y++;
                        if (map[y, x] == 2) { return count; }
                        if (y == row_m-1)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (x < col_m-1) if (map[y, x + 1] != 1) c2 = ok(x, y, count, 2);
                        if (x > 0) if (map[y, x - 1] != 1) c3 = ok(x, y, count, 3);
                    }
                    break;

                case 1:

                    count++;
                    while (map[y - 1, x] != 1)
                    {
                        y--;
                        if (map[y, x] == 2) { return count; }
                        if (y == 0)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (x < col_m-1) if (map[y, x + 1] != 1) c2 = ok(x, y, count, 2);
                        if (x > 0) if (map[y, x - 1] != 1) c3 = ok(x, y, count, 3);
                    }
                    break;
                case 2:
                    count++;
                    while (map[y, x + 1] != 1)
                    {
                        x++;
                        if (map[y, x] == 2) { return count; }
                        if (x == col_m-1)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (y < row_m - 1) if (map[y + 1, x] != 1) c0 = ok(x, y, count, 0);
                        if (y > 0) if (map[y - 1, x] != 1) c1 = ok(x, y, count, 1);
                    }
                    break;
                case 3:
                    count++;
                    while (map[y, x - 1] != 1)
                    {
                        x--;
                        if (map[y, x] == 2) { return count; }
                        if (x == 0)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (y < row_m - 1) if (map[y + 1, x] != 1) c0 = ok(x, y, count, 0);
                        if (y > 0) if (map[y - 1, x] != 1) c1 = ok(x, y, count, 1);
                    }
                    break;
                default:
                    if (y < row_m - 1) if (map[y + 1, x] != 1) c0 = ok(x, y, count, 0);
                    if (y > 0) if (map[y - 1, x] != 1) c1 = ok(x, y, count, 1);
                    if (x < col_m-1) if (map[y, x + 1] != 1) c2 = ok(x, y, count, 2);
                    if (x > 0) if (map[y, x - 1] != 1) c3 = ok(x, y, count, 3);
                    break;
            }
            if (c0 < c1)
                if (c2 < c3)
                    if (c2 < c0)
                        count = c2;
                    else count = c0;
                else if (c3 < c0)
                    count = c3;
                else count = c0;
            else
                if (c2 < c3)
                if (c2 < c1)
                    count = c2;
                else count = c1;
            else if (c3 < c1)
                count = c3;
            else count = c1;
        }
        return count;
    }


}