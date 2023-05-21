namespace winMdi;
public interface IWinMdi
{
    MdiControl MdiControl { get; set; }

    bool IsMinNotMove { get; }
    bool NotMove { get; }
    int MinInd { get; }

    void SetTitle(string title);

    void SetTitleFont(Font font);

    void SetMinimizeBox(bool minimizeBox);
    void SetMaximizeBox(bool maximizeBox);

    bool MdiFocus { get; set; }
}
