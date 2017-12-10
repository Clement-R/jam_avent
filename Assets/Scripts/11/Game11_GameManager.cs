using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game11_GameManager : MonoBehaviour {

    private Vector2 _startLine = new Vector2(-9999, -9999);
    private Vector2 _endLine = new Vector2(-9999, -9999);

    private GameObject lineObject;
    private LineRenderer line;

    private List<LineRenderer> _allLines = new List<LineRenderer>();
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_startLine.x == -9999)
            {
                _startLine = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                print(_startLine);

                lineObject = new GameObject();
                line = lineObject.AddComponent<LineRenderer>();
                line.SetPosition(0, _startLine);
                line.startWidth = 1f;
                line.endWidth = 1f;
            }
            else if (_endLine.x == -9999)
            {
                _endLine = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                print(_endLine);

                line.SetPosition(1, _endLine);
                
                // If there is at least 2 lines
                if (_allLines.Count >= 1)
                {
                    // Check if we cross other lines
                    bool crossedALine = false;
                    foreach (var line in _allLines)
                    {
                        if (doIntersect(this.line, line))
                        {
                            crossedALine = true;
                            break;
                        }
                    }

                    if (!crossedALine)
                    {
                        _allLines.Add(this.line);
                        print("Is okay");
                    }
                    else
                    {
                        print("Lose");
                        // TODO : show lose panel
                    }
                }
                else
                {
                    _allLines.Add(this.line);
                }

                _startLine = new Vector2(-9999, -9999);
                _endLine = new Vector2(-9999, -9999);
                lineObject = null;
                line = null;
            }
        }

        if (_startLine.x != -9999)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(1, mousePos);
        }
    }

    // Check if two segments line intersect, code by geeksforgeeks modified for c#
    bool doIntersect(LineRenderer line1, LineRenderer line2)
    {
        return doIntersect(line1.GetPosition(0), line1.GetPosition(1), line2.GetPosition(0), line2.GetPosition(1));
    }

    // Given three colinear points p, q, r, the function checks if
    // point q lies on line segment 'pr'
    bool onSegment(Vector2 p, Vector2 q, Vector2 r)
    {
        if (q.x <= Mathf.Max(p.x, r.x) && q.x >= Mathf.Min(p.x, r.x) &&
            q.y <= Mathf.Max(p.y, r.y) && q.y >= Mathf.Min(p.y, r.y))
            return true;

        return false;
    }

    // To find orientation of ordered triplet (p, q, r).
    // The function returns following values
    // 0 --> p, q and r are colinear
    // 1 --> Clockwise
    // 2 --> Counterclockwise
    float orientation(Vector2 p, Vector2 q, Vector2 r)
    {
        float val = (q.y - p.y) * (r.x - q.x) -
                  (q.x - p.x) * (r.y - q.y);

        if (val == 0) return 0;  // colinear

        return (val > 0) ? 1 : 2; // clock or counterclock wise
    }

    // The main function that returns true if line segment 'p1q1'
    // and 'p2q2' intersect.
    bool doIntersect(Vector2 p1, Vector2 q1, Vector2 p2, Vector2 q2)
    {
        // Find the four orientations needed for general and
        // special cases
        float o1 = orientation(p1, q1, p2);
        float o2 = orientation(p1, q1, q2);
        float o3 = orientation(p2, q2, p1);
        float o4 = orientation(p2, q2, q1);

        // General case
        if (o1 != o2 && o3 != o4)
            return true;

        // Special Cases
        // p1, q1 and p2 are colinear and p2 lies on segment p1q1
        if (o1 == 0 && onSegment(p1, p2, q1)) return true;

        // p1, q1 and p2 are colinear and q2 lies on segment p1q1
        if (o2 == 0 && onSegment(p1, q2, q1)) return true;

        // p2, q2 and p1 are colinear and p1 lies on segment p2q2
        if (o3 == 0 && onSegment(p2, p1, q2)) return true;

        // p2, q2 and q1 are colinear and q1 lies on segment p2q2
        if (o4 == 0 && onSegment(p2, q1, q2)) return true;

        return false; // Doesn't fall in any of the above cases
    }
}
