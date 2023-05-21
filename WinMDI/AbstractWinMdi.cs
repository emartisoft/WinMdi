using System.ComponentModel;
using System.Security.Permissions;

namespace winMdi;
[TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AbstractWinMdi, UserControl>))]
abstract public class AbstractWinMdi : UserControl, IWinMdi
{
    public AbstractWinMdi()
    {
        DoubleBuffered = true;
        NotMove = true;
        IsMove = false;
        ChildrenMouseDown = delegate { MdiControl.FocusWinMdi(this); };
        MouseDown += delegate { ChildrenMouseDown.Invoke(); };
    }

    private Action ChildrenMouseDown { get; set; }

    protected bool IsMove { get; set; }

    private MdiControl? mdiControl;
    public MdiControl MdiControl
    {
        get
        {
            if (mdiControl is not null)
                return mdiControl;
            else
                throw new Exception("MdiControl is null");
        }

        set
        {
            mdiControl = value;
        }
    }
    public bool IsMinNotMove { get; protected set; }
    public bool NotMove { get; protected set; }
    public int MinInd { get; protected set; }
    public abstract bool MdiFocus { get; set; }
    public abstract void SetMaximizeBox(bool maximizeBox);
    public abstract void SetMinimizeBox(bool minimizeBox);
    public abstract void SetTitle(string title);
    public abstract void SetTitleFont(Font font);

    #region behaviors
#pragma warning disable SYSLIB0003 
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
#pragma warning restore SYSLIB0003 
    protected override void WndProc(ref Message m)
    {
        // 0x210 is WM_PARENTNOTIFY
        // 513 is WM_LBUTTONCLICK
        if (m.Msg == 0x210 && m.WParam.ToInt32() == 513)
        {
            // get the clicked position
            int x = m.LParam.ToInt32() & 0xFFFF;
            int y = m.LParam.ToInt32() >> 16;

            // get the clicked control
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Control childControl = GetChildAtPoint(new Point(x, y));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            // call onClick (which fires Click event)
            ChildrenMouseDown.Invoke();

        }
        base.WndProc(ref m);
    }
    #endregion
}

public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
{
    public AbstractControlDescriptionProvider()
        : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
    {
    }

    public override Type GetReflectionType(Type objectType, object? instance)
    {
        if (objectType == typeof(TAbstract))
            return typeof(TBase);

        return base.GetReflectionType(objectType, instance);
    }

    public override object? CreateInstance(IServiceProvider? provider, Type objectType, Type[]? argTypes, object[]? args)
    {
        if (objectType == typeof(TAbstract))
            objectType = typeof(TBase);

        return base.CreateInstance(provider, objectType, argTypes, args);
    }
}