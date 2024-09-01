using System;
using UnityEngine;

namespace ChessGame
{
    public class Tile : MonoBehaviour
    {

        #region  Fields
        public bool isVisible { get; set; }
        public Piece piece { get; set; }
        public (int, int) position { get; set; }
        public bool isWhite;

        public delegate void TileClickedHandler(Tile clickedTile);
        public static event TileClickedHandler OnTileClicked;

        [SerializeField] private Color movmentColor;
        [SerializeField] private Color captureColor;
        [SerializeField] private Color specialMoveColor;
        [SerializeField] private Color differentMoveColor;
        [SerializeField] private Color whiteColor;
        [SerializeField] private Color blackColor;
        [SerializeField] private Color hovertColor;

        private SpriteRenderer spriteRenderer;

        #endregion


        public Tile(int x, int y)
        {
            isVisible = true;
            piece = null;
            position = (x, y);
            //tileRenderer = GetComponent<Renderer>();
        }


        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            Debug.Log($"WhiteColor: {whiteColor}, BlackColor: {blackColor}");
        }

        public void SetTileColor(bool setWhiteColor)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = (setWhiteColor) ? whiteColor : blackColor;
                isWhite = setWhiteColor;
            }
        }

        public void SetTileColor(TileAction action)
        {
            switch (action)
            {
                case TileAction.Movment:
                    spriteRenderer.color = movmentColor;
                    break;
                case TileAction.Capture:
                    spriteRenderer.color = captureColor;
                    break;
                case TileAction.SpecialMove:
                    spriteRenderer.color = specialMoveColor;
                    break;
                case TileAction.DifferentMove:
                    spriteRenderer.color = differentMoveColor;
                    break;
                case TileAction.Hover:
                    spriteRenderer.color = hovertColor;
                    break;
                case TileAction.Idle:
                    spriteRenderer.color = (isWhite) ? whiteColor : blackColor;
                    break;
            }
        }

        private void OnMouseEnter()
        {
            SetTileColor(TileAction.Hover);
        }

        private void OnMouseExit()
        {
            SetTileColor(TileAction.Idle);
        }

        void OnMouseDown()
        {
            Debug.Log("CLICKED");
            OnTileClicked?.Invoke(this);
        }

    }
}
