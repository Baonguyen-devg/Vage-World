using UnityEngine;

public class MashGenerator : MonoBehaviour
{
    public SquareGrid squareGird;

    public void GenerateMesh(int[,] map, float squareSize)
    {
        this.squareGird = new SquareGrid(map, squareSize);
    }

    public void OnDrawGizmos()
    {
        if (squareGird != null)
        {
            for (int x = 1; x < squareGird.squares.GetLength(0) - 1; x++)
                for (int y = 1; y < squareGird.squares.GetLength(1) - 1; y++)
                {
                    if (squareGird.squares[x, y] == null) continue;
                    Gizmos.color = (squareGird.squares[x, y].topLeft.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGird.squares[x, y].topLeft.position, Vector3.one * .4f);

                    Gizmos.color = (squareGird.squares[x, y].topRight.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGird.squares[x, y].topRight.position, Vector3.one * .4f);

                    Gizmos.color = (squareGird.squares[x, y].bottomLeft.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGird.squares[x, y].bottomLeft.position, Vector3.one * .4f);

                    Gizmos.color = (squareGird.squares[x, y].bottomRight.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGird.squares[x, y].bottomRight.position, Vector3.one * .4f);

                    Gizmos.color = Color.grey;
                    Gizmos.DrawCube(squareGird.squares[x, y].centerTop.position, Vector3.one * .15f);
                    Gizmos.DrawCube(squareGird.squares[x, y].centerBottom.position, Vector3.one * .15f);
                    Gizmos.DrawCube(squareGird.squares[x, y].centerRight.position, Vector3.one * .15f);
                    Gizmos.DrawCube(squareGird.squares[x, y].centerLeft.position, Vector3.one * .15f);
                }
        }
    }

    public class SquareGrid
    {
        public Square[,] squares;

        public SquareGrid(int[,] map, float squareSize)
        {
            int nodeCountX = map.GetLength(0) - 1;
            int nodeCountY = map.GetLength(1) - 1;

            Debug.Log(nodeCountX + " " + nodeCountY);

            float mapWidth = nodeCountX * (squareSize - 1);
            float mapHeight = nodeCountY * (squareSize - 1);

            ControlNode[,] controlNodes = new ControlNode[nodeCountX + 1, nodeCountY + 1];
            for (int x = 1; x <= nodeCountX; x++)
                for (int y = 1; y <= nodeCountY; y++)
                {
                    Vector3 pos = new Vector3(-mapWidth / 2 + (x - 1) * squareSize + squareSize / 2, -mapHeight / 2 + (y - 1) * squareSize + squareSize / 2, 0);
                    controlNodes[x, y] = new ControlNode(pos, map[x, y] == 0, squareSize);
                }

            squares = new Square[nodeCountX + 1, nodeCountY + 1];
            for (int x = 1; x < nodeCountX; x++)
                for (int y = 1; y < nodeCountY; y++)
                {
                    squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
                }
        }
    }

    public class Square
    {
        public ControlNode topLeft, topRight, bottomRight, bottomLeft;
        public Node centerTop, centerRight, centerBottom, centerLeft;

        public Square(ControlNode _topLeft, ControlNode _topRight, ControlNode _bottomRight, ControlNode _bottomLeft)
        {
            this.topLeft = _topLeft;
            this.topRight = _topRight;
            this.bottomLeft = _bottomLeft;
            this.bottomRight = _bottomRight;

            this.centerTop = topLeft.right;
            this.centerRight = bottomRight.above;
            this.centerBottom = bottomLeft.right;
            this.centerLeft = bottomLeft.above;
        }
    }

    public class Node
    {
        public Vector3 position;
        public int vertexIndex = -1;

        public Node(Vector3 pos)
        {
            position = pos;
        }

    }

    public class ControlNode : Node
    {
        public bool active;
        public Node above, right;

        public ControlNode(Vector3 _pos, bool _active, float squareSize) : base(_pos)
        {
            this.active = _active;
            this.above = new Node(position + Vector3.forward * squareSize / 2f);
            this.right = new Node(position + Vector3.right * squareSize / 2f);
        }
    }
}
