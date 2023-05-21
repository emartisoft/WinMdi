using System.ComponentModel;
namespace winMdi;

public partial class MdiControl : UserControl
{
    #region Public
    public List<IWinMdi> WinMdis { get; private set; }

    public MdiControl()
    {
        WinMdis = new();
        InitializeComponent();
    }

    public WinMdi CreateWinMdi()
    {
        WinMdi win = new()
        {
            MdiControl = this
        };

        IWinMdi[] all_wins = WinMdis.ToArray();
        List<IWinMdi> listWinsDontMove = new();
        foreach (IWinMdi subwin in all_wins)
        {
            if (subwin.NotMove)
            {
                listWinsDontMove.Add(subwin);
            }
        }
        IWinMdi[] wins = listWinsDontMove.ToArray();
        Array.Sort(wins, SortWinMdi);
        win.Location = GetWinStartPosition(win, wins);

        Controls.Add(win);
        WinMdis.Add(win);

        FocusWinMdi(win);
        return win;
    }

    public WinMdi CreateWinMdiWithForm(Form form)
    {
        form.FormBorderStyle = FormBorderStyle.None;
        form.TopLevel = false;

        WinMdi win = new();
        win.Title = form.Text;
        win.MinimumSize = new Size(form.MinimumSize.Width + 12, form.MinimumSize.Height + 44);
        if (form.MaximumSize.Width > 0 && form.MaximumSize.Height > 0)
            win.MaximumSize = new Size(form.MaximumSize.Width + 12, form.MaximumSize.Height + 44);
        win.MinimizeBox = form.MinimizeBox;
        win.MaximizeBox = form.MaximizeBox;
        form.Dock = DockStyle.Fill;
        win.Controls.Add(form);
        form.BringToFront();
        form.Show();
        win.panelRightFloor.BringToFront();
        win.MdiControl = this;

        IWinMdi[] all_wins = WinMdis.ToArray();
        List<IWinMdi> listWinsDontMove = new();
        foreach (IWinMdi subwin in all_wins)
        {
            if (subwin.NotMove)
            {
                listWinsDontMove.Add(subwin);
            }
        }
        IWinMdi[] wins = listWinsDontMove.ToArray();
        Array.Sort(wins, SortWinMdi);
        win.Location = GetWinStartPosition(win, wins);

        Controls.Add(win);
        WinMdis.Add(win);

        FocusWinMdi(win);
        return win;
    }

    public void FocusWinMdi(IWinMdi win)
    {
        win.MdiFocus = true;
        Controls.SetChildIndex((Control)win, 0);
        foreach (IWinMdi subwin in WinMdis)
        {
            if (subwin == win) continue;
            subwin.MdiFocus = false;
        }
    }
    #endregion

    #region Private
    int SortWinMdi(IWinMdi mw1, IWinMdi mw2)
    {
        if (mw1 is Control cmw1 && mw2 is Control cmw2)
        {
            if (cmw1.Location.X - cmw1.Location.Y == cmw2.Location.X - cmw2.Location.Y)
            {
                return cmw1.Location.X.CompareTo(cmw2.Location.X);
            }
            else
            {
                return (cmw1.Location.X - cmw1.Location.Y).CompareTo(cmw2.Location.X - cmw2.Location.Y);
            }
        }
        else
        {
            return 0;
        }
    }

    private Point GetWinStartPosition(IWinMdi win, IWinMdi[] wins)
    {
        const int MOVE = 48;
        if (win is not Control winCont) return default;

        int x = 0, y = 0, cil = 0;
        foreach (IWinMdi subwin in wins)
        {
            if (subwin is not Control cont) continue;

            if (cont.Location.Y + cont.Height <= Height)
            {
                if (cont.Location.X == x && cont.Location.Y == y)
                {
                    x += MOVE;
                    y += MOVE;
                }
            }

            if (y + winCont.Height > Height)
            {
                cil++;
                x = MOVE * cil;
                y = 0;
            }
        }
        return new Point(x, y);
    }

    private void MdiControl_Resize(object sender, EventArgs e)
    {
        foreach (IWinMdi win in WinMdis)
        {
            if (win.IsMinNotMove && win is Control control)
            {
                control.Location = new Point(((Control)win).Location.X, Height - 32 * win.MinInd);
            }
        }
    }
    #endregion

    #region Behaviors
    [DefaultValue(true)]
    [Description("Is Remove Screen Flickering")]
    public bool removeScreenFlickering = true;

    public bool RemoveScreenFlickering { get => removeScreenFlickering; set => removeScreenFlickering = value; }
    protected override CreateParams CreateParams
    {
        get
        {
            if (RemoveScreenFlickering)
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
            else
            {
                return base.CreateParams;
            }
        }
    }
    #endregion
}
