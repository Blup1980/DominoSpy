using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DominoSpy
{ 

    public enum DominoStatus
    {
        Correct,
        Wrong,
        Inverted,
        NotPlaced
    }

    public partial class DominoControl : Control
    {
        private readonly Color _colorOutline = Color.Black;
        private readonly Color _colorVuPath = Color.DarkGreen;
        private readonly Color _colorVuFill = Color.Green;
        private readonly Color _colorArrowPath = Color.DarkRed;
        private readonly Color _colorArrowFill = Color.Red;
        private readonly Color _colorCrossPath = Color.DarkRed;
        private readonly Color _colorCrossFill = Color.Red;
        private readonly Color _colorText = Color.Black;
        private readonly Color _colorCorrectText = Color.Green;
        private readonly int _smallDim = 75;
        private readonly int _largeDim = 150;
        private readonly int _fontSize = 40;
        private readonly int _fontCorrect = 20;
        private String _textA = "";
        private String _textB = "";
        private String _correctA = "";
        private String _correctB = "";
        private bool _showCorrect = false;
        private bool _vert = false;
        private DominoStatus _status = DominoStatus.NotPlaced;


        public bool Vertical
        {
            get { return _vert; }
            set
            {
                _vert = value;
                if (_vert)
                {
                    this.Size = new Size(_smallDim, _largeDim);
                }
                else
                {
                    this.Size = new Size(_largeDim, _smallDim);
                }
                Invalidate(); 
            }
        }

        public DominoStatus Status
        {
            get { return _status; }
            set { _status = value; Invalidate(); }
        }

        public String TextA
        {
            get { return _textA; }
            set { _textA = value; Invalidate(); }
        }
        public String TextB
        {
            get { return _textB; }
            set { _textB = value; Invalidate(); }
        }

        public String CorrectA
        {
            get { return _correctA; }
            set { _correctA = value; Invalidate(); }
        }
        public String CorrectB
        {
            get { return _correctB; }
            set { _correctB = value; Invalidate(); }
        }

        public bool ShowCorrect
        {
            get { return _showCorrect; }
            set { _showCorrect = value; Invalidate(); }
        }


        public DominoControl()
        {
            InitializeComponent();
            
            if (_vert)
            {
                this.Size = new Size(_smallDim, _largeDim);
            }
            else
            {
                this.Size = new Size(_largeDim, _smallDim);
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            DrawBody(pe);
            DrawTexts(pe);
            if (_showCorrect)
            {
                DrawCorrect(pe);
            }

            switch (_status)
            {
                case DominoStatus.Correct:
                    DrawVu(pe);
                    break;
                case DominoStatus.Wrong:
                    DrawCross(pe);
                    break;

                case DominoStatus.Inverted:
                    DrawArrow(pe);
                    break;
            }
            base.OnPaint(pe);
        }

        protected void DrawBody(PaintEventArgs pe)
        {
            List<PointF> shapePoints = new List<PointF> {
                new PointF(- _largeDim/2, _smallDim/2),
                new PointF(- _largeDim/2, -_smallDim/2),
                new PointF(_largeDim/2, -_smallDim/2),
                new PointF( _largeDim/2, _smallDim/2)
            };

            List<PointF> drawPoints = new List<PointF>();
            if (_vert)
            {
                foreach (PointF p in shapePoints)
                {
                    drawPoints.Add(new PointF(_smallDim / 2 + p.Y, _largeDim / 2 + p.X));
                }
            }
            else
            {
                foreach (PointF p in shapePoints)
                {
                    drawPoints.Add(new PointF(_largeDim / 2 + p.X, _smallDim / 2 + p.Y));
                }
            }

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLines(drawPoints.ToArray());
            path.CloseFigure();

            pe.Graphics.FillPath(new SolidBrush(this.ForeColor), path);
            pe.Graphics.DrawPath(new Pen(_colorOutline, 2), path);
            path.Dispose();
        }

        protected void DrawVu(PaintEventArgs pe)
        {

            List<PointF> shapePoints = new List<PointF> {
                new PointF(-27, 4),
                new PointF(-11, 27),
                new PointF(24, -26),
                new PointF(20, -28),
                new PointF(-11, 10),
                new PointF(-25, 1 )
            };

            List<PointF> drawPoints = new List<PointF>();
            if (_vert)
            {
                foreach (PointF p in shapePoints)
                {
                    drawPoints.Add(new PointF(_smallDim / 2 + p.X, _largeDim / 2 + p.Y));
                }
            }
            else
            {
                foreach (PointF p in shapePoints)
                {
                    drawPoints.Add(new PointF(_largeDim / 2 + p.X, _smallDim / 2 + p.Y));
                }
            }

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLines(drawPoints.ToArray());
            path.CloseFigure();

            pe.Graphics.FillPath(new SolidBrush(_colorVuFill), path);
            pe.Graphics.DrawPath(new Pen(_colorVuPath, 2), path);
            path.Dispose();
        }

        protected void DrawArrow(PaintEventArgs pe)
        {

            List<PointF> shapePoints = new List<PointF> {
                new PointF(-2 , -3),
                new PointF(-17, -3),
                new PointF(-7, -18),
                new PointF(-12, -18),
                new PointF(-24, +0),
                new PointF(-12, +18),
                new PointF(-7, +18),
                new PointF(-17, +3),
                new PointF(-2 , +3)
            };

            List<PointF> drawPointsA = new List<PointF>();
            List<PointF> drawPointsB = new List<PointF>();

            if (_vert)
            {
                foreach (PointF p in shapePoints)
                {
                    drawPointsA.Add(new PointF(_smallDim / 2 + p.Y, _largeDim / 2 + p.X));
                    drawPointsB.Add(new PointF(_smallDim / 2 + p.Y, _largeDim / 2 - p.X));
                }
            } 
            else
            {
                foreach (PointF p in shapePoints)
                {
                    drawPointsA.Add(new PointF(_largeDim / 2 + p.X, _smallDim / 2 + p.Y));
                    drawPointsB.Add(new PointF(_largeDim / 2 - p.X, _smallDim / 2 + p.Y));
                }
            }

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLines(drawPointsA.ToArray());
            path.CloseFigure();

            path.StartFigure();
            path.AddLines(drawPointsB.ToArray());
            path.CloseFigure();

            pe.Graphics.FillPath(new SolidBrush(_colorArrowFill), path);
            pe.Graphics.DrawPath(new Pen(_colorArrowPath, 2), path);
            path.Dispose();
        }

        protected void DrawCross(PaintEventArgs pe)
        {

            List<PointF> shapePoints = new List<PointF> {
                new PointF(0 , -5),
                new PointF(-13, -17),
                new PointF(-18, -12)
            };


            shapePoints.Add(new PointF(shapePoints[0].Y, shapePoints[0].X));
            shapePoints.Add(new PointF(shapePoints[2].X, -shapePoints[2].Y));
            shapePoints.Add(new PointF(shapePoints[1].X, -shapePoints[1].Y));
            shapePoints.Add(new PointF(shapePoints[0].X, -shapePoints[0].Y));
            shapePoints.Add(new PointF(-shapePoints[1].X, -shapePoints[1].Y));
            shapePoints.Add(new PointF(-shapePoints[2].X, -shapePoints[2].Y));
            shapePoints.Add(new PointF(-shapePoints[0].Y, shapePoints[0].X));
            shapePoints.Add(new PointF(-shapePoints[2].X, shapePoints[2].Y));
            shapePoints.Add(new PointF(-shapePoints[1].X, shapePoints[1].Y));

            List<PointF> drawPoints = new List<PointF>();
            if (_vert)
            {
                foreach (PointF p in shapePoints)
                {
                    drawPoints.Add(new PointF(_smallDim / 2 + p.X, _largeDim / 2 + p.Y));
                }
            } else
            {
                foreach (PointF p in shapePoints)
                {
                    drawPoints.Add(new PointF(_largeDim / 2 + p.X, _smallDim / 2 + p.Y));
                }
            }

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLines(drawPoints.ToArray());
            path.CloseFigure();

            pe.Graphics.FillPath(new SolidBrush(_colorCrossFill), path);
            pe.Graphics.DrawPath(new Pen(_colorCrossPath, 2), path);
            path.Dispose();
        }

        void DrawTexts(PaintEventArgs pe)
        {
            
            Point positionA; 
            Point positionB;
            if (_vert)
            {
                positionA = new Point(_smallDim / 2, _largeDim / 2 - _largeDim / 4);
                positionB = new Point(_smallDim / 2, _largeDim / 2 + _largeDim / 4);
            }
            else
            {
                positionA = new Point(_largeDim / 2 - _largeDim /4 , _smallDim / 2);
                positionB = new Point(_largeDim / 2 + _largeDim /4, _smallDim / 2);
            }

            DrawTextAt(pe, positionA, TextA, _colorText, _fontSize);
            DrawTextAt(pe, positionB, TextB, _colorText, _fontSize);

        }

        void DrawCorrect(PaintEventArgs pe)
        {

            Point positionA;
            Point positionB;
            if (_vert)
            {
                positionA = new Point(_smallDim*2 / 10, _largeDim / 2 - _largeDim / 4);
                positionB = new Point(_smallDim*2 / 10, _largeDim / 2 + _largeDim / 4);
            }
            else
            {
                positionA = new Point(_largeDim / 2 - _largeDim / 4, _smallDim*8 / 10);
                positionB = new Point(_largeDim / 2 + _largeDim / 4, _smallDim*8 / 10);
            }

            DrawTextAt(pe, positionA, _correctA, _colorCorrectText, _fontCorrect);
            DrawTextAt(pe, positionB, _correctB, _colorCorrectText, _fontCorrect);

        }


        void DrawTextAt(PaintEventArgs pe, Point pos, String text, Color col, int size)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               size,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            SolidBrush solidBrush = new SolidBrush(col);

            Rectangle rect1 = new Rectangle(pos.X - _fontSize/2 , pos.Y - _fontSize/2 + _fontSize / 12, _fontSize, _fontSize);

            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            pe.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            pe.Graphics.DrawString(text, font, solidBrush, rect1, stringFormat);

            stringFormat.Dispose();
            fontFamily.Dispose();
            font.Dispose();
        }
    }
}
