using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace winMdi;
public partial class WinMdi : AbstractWinMdi
{
    private bool mdiFocus = true;

    private bool resizable = true, maximizeBox = true, minimizeBox = true;
    private Image max = Properties.Resources.max;
    private Image min = Properties.Resources.min;
    private Image normal = Properties.Resources.nor;
    private Image close = Properties.Resources.close;
    private Image maxh = Properties.Resources.max_h;
    private Image minh = Properties.Resources.min_h;
    private Image normalh = Properties.Resources.nor_h;
    private Image closeh = Properties.Resources.close_h;
    private Image maxp = Properties.Resources.max_p;
    private Image minp = Properties.Resources.min_p;
    private Image normalp = Properties.Resources.nor_p;
    private Image closep = Properties.Resources.close_p;
    private Color borderColor;

    bool isMin = false, isMax = false, isResize = false;
    int mx, my, rx, ry;
    Point lastLocation;
    Size lastSize, lastMinSize, lastMaxSize;
    string lastTitle = string.Empty;

    public WinMdi()
    {
        BackColor = Color.WhiteSmoke;
        InitializeComponent();
        //labelTitle
        labelTitle.MouseDown += panelMain_MouseDown;
        labelTitle.MouseUp += panelMain_MouseUp;
        labelTitle.MouseMove += panelMain_MouseMove;
    }

    #region behaviors
    [DefaultValue("WinMdi")]
    [Description("Is WinMdi Title")]
    public string Title { get { return labelTitle.Text; } set { labelTitle.Text = value; } }

    [DefaultValue(true)]
    [Description("Is Maximize Box WinMdi")]
    public bool MaximizeBox
    {
        get { return maximizeBox; }
        set
        {
            maximizeBox = value;
            if (!maximizeBox && !minimizeBox)
            {
                bMax.Visible = false;
                bMin.Visible = false;
            }
            else if (!bMax.Visible || bMin.Visible)
            {
                bMax.Visible = true;
                bMin.Visible = true;
            }
        }
    }

    [DefaultValue(true)]
    [Description("Is Minimize Box WinMdi")]
    public bool MinimizeBox
    {
        get { return minimizeBox; }
        set
        {
            minimizeBox = value;
            if (!maximizeBox && !minimizeBox)
            {
                bMax.Visible = false;
                bMin.Visible = false;
            }
            else if (!bMax.Visible || bMin.Visible)
            {
                bMax.Visible = true;
                bMin.Visible = true;
            }
        }
    }

    [DefaultValue(typeof(Color), "0x535353")]
    [Description("Border Color")]
    public Color BorderColor { get { return borderColor; } set { borderColor = panelTop.BackColor = panelFloor.BackColor = panelLeft.BackColor = panelRight.BackColor = panelRightFloor.BackColor = value; } }

    [DefaultValue(typeof(Color), "Black")]
    [Description("Is WinMdi Title")]
    public Color TitleColor { get { return labelTitle.ForeColor; } set { labelTitle.ForeColor = value; } }

    #endregion

    #region panelMain
    private void panelMain_MouseDown(object? sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            IsMove = true;
            IsMinNotMove = false;
            mx = MousePosition.X - Location.X;
            my = MousePosition.Y - Location.Y;
        }
    }

    private void panelMain_MouseUp(object? sender, MouseEventArgs e)
    {
        IsMove = false;
    }

    private void panelMain_MouseMove(object? sender, MouseEventArgs e)
    {
        if (IsMove)
        {
            Point newMousePosition = new Point(MousePosition.X - mx, MousePosition.Y - my), newPosition = newMousePosition;

            if (Width < MdiControl.Width)
            {
                if (newMousePosition.X < 0)
                {
                    newPosition.X = 0;
                }
                else if (newMousePosition.X + Width > MdiControl.Width)
                {
                    newPosition.X = MdiControl.Width - Width;
                }
            }

            if (Height < MdiControl.Height)
            {
                if (newMousePosition.Y < 0)
                {
                    newPosition.Y = 0;
                }
                else if (newMousePosition.Y + Height > MdiControl.Height)
                {
                    newPosition.Y = MdiControl.Height - Height;
                }
            }

            Location = newPosition;

            if (NotMove)
            {
                NotMove = false;
            }
        }
    }
    #endregion

    #region panelRightFloor
    private void panelRightFloor_MouseDown(object? sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            rx = MousePosition.X - Size.Width;
            ry = MousePosition.Y - Size.Height;
        }
    }

    private void panelRightFloor_MouseUp(object? sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelRightFloor_MouseMove(object? sender, MouseEventArgs e)
    {
        if (isResize)
        {
            Size = new Size(MousePosition.X - rx, MousePosition.Y - ry);
        }

        if (resizable)
            Cursor.Current = Cursors.SizeNWSE;
    }

    private void panelRightFloor_MouseEnter(object? sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeNWSE;
    }
    #endregion

    #region buttons
    private void bMin_Click(object? sender, EventArgs e)
    {
        if (minimizeBox)
        {
            if (!isMin)
            {
                int x = 0;
                MinInd = 1;

                IWinMdi[] wins = new IWinMdi[] { };
                wins = MdiControl.WinMdis.ToArray();

                Array.Sort(wins, delegate (IWinMdi mw1, IWinMdi mw2)
                {
                    if (((Control)mw1).Location.Y == ((Control)mw2).Location.Y)
                        return ((Control)mw1).Location.X.CompareTo(((Control)mw2).Location.X);
                    else
                        return -((Control)mw1).Location.Y.CompareTo(((Control)mw2).Location.Y);
                });

                foreach (Control cont in wins)
                {
                    if (cont.Location.X + 226 > MdiControl.Width)
                        continue;

                    if (x + 226 <= MdiControl.Width)
                    {
                        if (cont.Location.X == x && cont.Location.Y == MdiControl.Height - 32 * MinInd)
                        {
                            x += 226;
                        }
                        if (cont.Location.X > x)
                        {
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        MinInd++;
                        if (cont.Location.X == x && cont.Location.Y == MdiControl.Height - 32 * MinInd)
                        {
                            x += 226;
                        }
                        if (cont.Location.X > x)
                        {
                            break;
                        }
                    }
                }

                if (isMax)
                {
                    Dock = DockStyle.None;
                    bMax.Image = max;
                    isMax = false;
                }

                lastTitle = Title;
                lastSize = Size;
                lastMinSize = MinimumSize;
                lastLocation = Location;
                MaximumSize = lastMaxSize;

                panelTop.Visible = false;
                panelFloor.Visible = false;
                panelLeft.Visible = false;
                panelRight.Visible = false;
                panelRightFloor.Visible = false;

                Title = (Title.Length >= 8) ? Title.Substring(0, 8) + "..." : Title;
                MinimumSize = new Size(0, 0);
                Bounds = new Rectangle(x, MdiControl.Height - 32 * MinInd, 226, 32);
                bMin.Image = normal;
                isMin = true;
                IsMinNotMove = true;

                if (NotMove)
                {
                    NotMove = false;
                }
            }
            else
            {
                panelTop.Visible = true;
                panelFloor.Visible = true;
                panelLeft.Visible = true;
                panelRight.Visible = true;
                panelRightFloor.Visible = true;

                Title = lastTitle;
                MinimumSize = lastMinSize;
                Bounds = new Rectangle(lastLocation, lastSize);
                //bMin.Image = min;
                bMin.Image = normal;
                isMin = false;
                IsMinNotMove = false;
            }
        }
    }

    private void bMax_Click(object? sender, EventArgs e)
    {
        if (maximizeBox)
        {
            if (isMax)
            {
                Dock = DockStyle.None;
                //bMax.Image = max;
                bMax.Image = normal;

                MaximumSize = lastMaxSize;
                panelTop.Visible = true;
                panelFloor.Visible = true;
                panelLeft.Visible = true;
                panelRight.Visible = true;
                panelRightFloor.Visible = true;
                isMax = false;
            }
            else
            {
                if (isMin)
                {
                    Title = lastTitle;
                    MinimumSize = lastMinSize;
                    Bounds = new Rectangle(lastLocation, lastSize);
                    bMin.Image = min;
                    isMin = false;
                    IsMinNotMove = false;
                }
                else
                {
                    panelTop.Visible = false;
                    panelFloor.Visible = false;
                    panelLeft.Visible = false;
                    panelRight.Visible = false;
                    panelRightFloor.Visible = false;
                }

                lastMaxSize = MaximumSize;
                if (MaximumSize.Width > MinimumSize.Width && MaximumSize.Height > MinimumSize.Height)
                    MaximumSize = new Size(MaximumSize.Width - 12, MaximumSize.Height - 44);
                Dock = DockStyle.Fill;
                bMax.Image = normal;
                isMax = true;
            }
        }
    }

    private void bClose_Click(object? sender, EventArgs e)
    {
        MdiControl.Controls.Remove(this);
        MdiControl.WinMdis.Remove(this);
        Dispose();
    }

    private void bMin_MouseLeave(object? sender, EventArgs e)
    {
        if (minimizeBox)
            if (isMin)
                bMin.Image = normal;
            else
                bMin.Image = min;
    }

    private void bMax_MouseLeave(object? sender, EventArgs e)
    {
        if (maximizeBox)
            if (isMax)
                bMax.Image = normal;
            else
                bMax.Image = max;
    }

    private void bClose_MouseLeave(object? sender, EventArgs e)
    {
        bClose.Image = close;
    }

    private void bMin_MouseEnter(object? sender, EventArgs e)
    {
        if (minimizeBox)
            if (isMin)
                bMin.Image = normalh;
            else
                bMin.Image = minh;
    }

    private void bMax_MouseEnter(object? sender, EventArgs e)
    {
        if (maximizeBox)
            if (isMax)
                bMax.Image = normalh;
            else
                bMax.Image = maxh;
    }

    private void bClose_MouseEnter(object? sender, EventArgs e)
    {
        bClose.Image = closeh;
    }

    private void bMin_MouseDown(object? sender, MouseEventArgs e)
    {
        if (minimizeBox)
            if (isMin)
                bMin.Image = normalp;
            else
                bMin.Image = minp;
    }

    private void bMax_MouseDown(object? sender, MouseEventArgs e)
    {
        if (maximizeBox)
            bMax.Image = maxp;
    }

    private void bClose_MouseDown(object? sender, MouseEventArgs e)
    {
        bClose.Image = closep;
    }
    #endregion

    #region AbstractWinMdi

    public override void SetTitle(string title)
    {
        Title = title;
    }

    public override void SetTitleFont(Font font)
    {
        labelTitle.Font = font;
        panelMain.Height = (labelTitle.Height < 20) ? 20 : labelTitle.Height;
    }

    public override void SetMinimizeBox(bool minimizeBox)
    {
        MinimizeBox = minimizeBox;
    }
    public override void SetMaximizeBox(bool maximizeBox)
    {
        MaximizeBox = maximizeBox;
    }

    private void panelRightFloor_Paint(object sender, PaintEventArgs e)
    {
        panelRightFloor.BackColor = BackColor;
        Brush b = new SolidBrush(Color.FromArgb(83, 83, 83));
        var path = new GraphicsPath();
        path.AddLines(new PointF[] {
            new PointF(0, panelRightFloor.Height),
            new PointF(panelRightFloor.Width, 0),
            new PointF(panelRightFloor.Width, panelRightFloor.Height)

        });
        path.CloseFigure();
        e.Graphics.FillPath(b, path);
        b.Dispose();
    }

    private void panelRightFloor_MouseLeave(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.Default;
    }

    public override bool MdiFocus
    {
        get => mdiFocus;

        set
        {
            if (mdiFocus != value && value == true)
            {
                BorderColor = Color.FromArgb(83, 83, 83);
                TitleColor = Color.White;

            }
            else if (mdiFocus != value && value == false)
            {
                BorderColor = Color.FromArgb(100, 100, 100);
                TitleColor = Color.DarkGray;

            }

            mdiFocus = value;
        }
    }
    #endregion
}
