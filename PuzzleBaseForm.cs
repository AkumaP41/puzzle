using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PuzzleGame
{
    public class PuzzleBaseForm : Form
    {
        protected string Username = "Ten mac dinh";
        protected int gridSize = 2;
        protected Image originalImage;
        public List<Image> images = new List<Image>();
        public int inNullSliceIndex, inmoves = 0, inattempts = 0;
        public List<Bitmap> lstOriginalPictureList = new List<Bitmap>();
        public System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        protected List<Image> CropImageToPieces(Image original, int pieceWidth, int pieceHeight)
        {
            List<Image> pieces = new List<Image>();

            for (int y = 0; y < original.Height; y += pieceHeight)
            {
                for (int x = 0; x < original.Width; x += pieceWidth)
                {
                    Rectangle pieceRect = new Rectangle(x, y, pieceWidth, pieceHeight);
                    Bitmap piece = new Bitmap(pieceWidth, pieceHeight);
                    {
                        using (Graphics g = Graphics.FromImage(piece))
                        {
                            g.DrawImage(original, new Rectangle(0, 0, piece.Width, piece.Height),
                                pieceRect, GraphicsUnit.Pixel);
                        }

                        pieces.Add(piece);
                    }
                }
            }
            return pieces;
        }

        protected int[] ShuffleArray(int[] arr)
        {
            Random rand = new Random();
            arr = arr.OrderBy(x => rand.Next()).ToArray();
            return arr;
        }

        public void Shuffle(GroupBox gbPuzzleBox)
        {
           /* if (CheckWin(gbPuzzleBox) == true)         //mới 
            {
                gridSize++;
                //SetupNewGame();
            }*/

            if (gridSize == 3)
            {
                do
                {
                    int[] indexes = Enumerable.Range(0, gridSize * gridSize - 1).ToArray();
                    indexes = ShuffleArray(indexes);

                    for (int i = 0; i < gridSize * gridSize; i++)
                    {

                        if (i == gridSize * gridSize - 1)
                        {
                            inNullSliceIndex = i;
                            ((PictureBox)gbPuzzleBox.Controls[i]).Image = Properties.Resources._null;
                            break;
                        }
                        ((PictureBox)gbPuzzleBox.Controls[i]).Image = images[indexes[i]];

                    }

                } while (CheckWin(gbPuzzleBox) == true);
            }

            if (gridSize == 2)
            {
                do
                {
                    int[] indexes = Enumerable.Range(0, gridSize * gridSize - 1).ToArray();
                    indexes = ShuffleArray(indexes);
                    int[] indexess = new int [3];
                    indexess[0] = 2;
                    indexess[1] = 0;
                    indexess[2] = 1;

                    for (int i = 0; i < gridSize * gridSize; i++)
                    {
                        
                        if (i == gridSize * gridSize - 1)
                        {
                            inNullSliceIndex = i;
                            ((PictureBox)gbPuzzleBox.Controls[i]).Image = Properties.Resources.null2;
                            break;
                        }
                        ((PictureBox)gbPuzzleBox.Controls[i]).Image = images[indexess[i]];

                    }
                } while (CheckWin(gbPuzzleBox));
            }

            if (gridSize == 4)
            {
                do
                {
                    int[] indexes = Enumerable.Range(0, gridSize * gridSize - 1).ToArray();
                    indexes = ShuffleArray(indexes);

                    for (int i = 0; i < gridSize * gridSize; i++)
                    {

                        if (i == gridSize * gridSize - 1)
                        {
                            inNullSliceIndex = i;
                            ((PictureBox)gbPuzzleBox.Controls[i]).Image = Properties.Resources.null___Copy;
                            break;
                        }
                        ((PictureBox)gbPuzzleBox.Controls[i]).Image = images[indexes[i]];

                    }

                } while (CheckWin(gbPuzzleBox) == true);
            }
            //MessageBox.Show("You win!!!!");
        }

        public bool CheckWin(GroupBox gbPuzzleBox)
        {
            int totalPieces = gridSize * gridSize;  //moi
            for (int i = 0; i < totalPieces - 1; i++)
            {
                Console.WriteLine(totalPieces);
                if (gridSize == 3)
                {
                    PictureBox pictureBox = gbPuzzleBox.Controls[i] as PictureBox;
                    if (pictureBox != null)
                    {
                        if (pictureBox.Image != images[i])
                        {
                            return false;
                        }
                    }
                }

                if (gridSize == 2)
                {
                    PictureBox pictureBox = gbPuzzleBox.Controls[i] as PictureBox;
                    if (pictureBox != null)
                    {

                        if (pictureBox.Image != images[i])
                        {
                            return false;
                        }
                    }
                }

                if (gridSize == 4)
                {
                    PictureBox pictureBox = gbPuzzleBox.Controls[i] as PictureBox;
                    if (pictureBox != null)
                    {

                        if (pictureBox.Image != images[i])
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }

        protected void SwapImages(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            Image tempImage = pictureBox1.Image;
            pictureBox1.Image = pictureBox2.Image;
            pictureBox2.Image = tempImage;
        }

        protected bool CanMoveToAdjacent(int fromIndex, int toIndex)
        {
            int fromRow = fromIndex / gridSize;
            int fromCol = fromIndex % gridSize;
            int toRow = toIndex / gridSize;
            int toCol = toIndex % gridSize;
            return Math.Abs(fromRow - toRow) + Math.Abs(fromCol - toCol) == 1;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PuzzleBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "PuzzleBaseForm";
            this.Load += new System.EventHandler(this.PuzzleBaseForm_Load);
            this.ResumeLayout(false);

        }

        private void PuzzleBaseForm_Load(object sender, EventArgs e)
        {

        }

        protected bool CanMove(int pictureIndex)
        {
            int emptyIndex = inNullSliceIndex;
            return CanMoveToAdjacent(pictureIndex, emptyIndex);
        }
    }


}
