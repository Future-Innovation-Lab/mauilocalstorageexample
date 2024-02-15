using System.Reflection;

namespace MauiLocalStorageExamples;


public partial class LoadResourceText : ContentPage
{
    private string _output;

    public string Output
    {
        get { return _output; }
        set { _output = value; }
    }



    public LoadResourceText()
	{
		InitializeComponent();

        LoadLocalResources();

        BindingContext = this;

    }

	private void LoadLocalResources()
	{
        #region How to load a text file embedded resource
        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
        Stream stream = assembly.GetManifestResourceStream("MauiLocalStorageExamples.LibTextResource.txt");

        string text = "";
        using (var reader = new StreamReader(stream))
        {
            text = reader.ReadToEnd();
        }

        Output = text;
        
        #endregion

    }

}