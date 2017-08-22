using UnityEngine;
using System.Collections;

public class cubeok : MonoBehaviour
{

    public int[,] map = new int[12, 8];
    public static int[,] samplace;
    public static int row_m=8;
    public static int col_m=12;
    public static int index;
    public int x, y;

    public cubeok(int[] map,int x,int y) {

        int k = 0;
        this.x = x;
        this.y = y;
        for (int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 8; j++) 
            {
                this.map[i, j] =map[k];
                k++;
            }
        }

    }
    
    public int start()
    {

        samplace = new int[50,2];
        for (int i = 0; i < 50; i++) { samplace[i,0] = 0; samplace[i,1] = 101; }
        index = 1;
        int result = ok(x, y, 0, 111);

       // Debug.Log("최소 이동 횟수");
        //Debug.Log(result);
        return result;
        

    }

    bool same(int x, int y, int count)
    {

        int k = x*100 + y;
        if (k == 0)
        {
            return true;
        }
        else
        {
            for (int i = 1; i <= index; i++)
            {
                if (samplace[i,0] == k)
                {
                    if (count < samplace[i,1])
                    {
                        samplace[i,1] = count;
                        return true;
                    }
                    return false;
                }

            }
            samplace[index,0] = k;
            samplace[index,1] = count;
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
                    while (map[y + 1,x] != 1)
                    {
                        y++;
                        if (map[y, x] == 2) { return count; }
                        if (y == 11)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (x < 7) if (map[y,x + 1] != 1) c2 = ok(x, y, count, 2);
                        if (x > 0) if (map[y,x - 1] != 1) c3 = ok(x, y, count, 3);
                    }
                    break;

                case 1:

                    count++;
                    while (map[y - 1,x] != 1)
                    {
                        y--;
                        if (map[y,x] == 2) {return count; }
                        if (y == 0)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (x < 7) if (map[y,x + 1] != 1) c2 = ok(x, y, count, 2);
                        if (x > 0) if (map[y,x - 1] != 1) c3 = ok(x, y, count, 3);
                    }
                    break;
                case 2:
                    count++;
                    while (map[y,x + 1] != 1)
                    {
                        x++;
                        if (map[y,x] == 2) {return count; }
                        if (x == 7)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (y < 11) if (map[y + 1,x] != 1) c0 = ok(x, y, count, 0);
                        if (y > 0) if (map[y - 1,x] != 1) c1 = ok(x, y, count, 1);
                    }
                    break;
                case 3:
                    count++;
                    while (map[y,x - 1] != 1)
                    {
                        x--;
                        if (map[y,x] == 2) { return count; }
                        if (x == 0)
                        {
                            break;
                        }
                    }
                    if (same(x, y, count))
                    {
                        if (y < 11) if (map[y + 1,x] != 1) c0 = ok(x, y, count, 0);
                        if (y > 0) if (map[y - 1,x] != 1) c1 = ok(x, y, count, 1);
                    }
                    break;
                default:
                    if (y < 11) if (map[y + 1,x] != 1) c0 = ok(x, y, count, 0);
                    if (y > 0) if (map[y - 1,x] != 1) c1 = ok(x, y, count, 1);
                    if (x < 7) if (map[y,x + 1] != 1) c2 = ok(x, y, count, 2);
                    if (x > 0) if (map[y,x - 1] != 1) c3 = ok(x, y, count, 3);
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