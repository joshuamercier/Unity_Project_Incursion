public class Options : ButtonObject
{
    protected override void OnClicked()
    {
        mainManager.ChangeBetweenMainOrOptions();
    }
}
