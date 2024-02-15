using MauiLocalStorageExamples.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Reflection;

namespace MauiLocalStorageExamples;

public partial class LoadResourceJson : ContentPage
{
    private ObservableCollection<Monkey> _monkeys;

    public ObservableCollection<Monkey> Monkeys
    {
        get { return _monkeys; }
        set
        {
            _monkeys = value;

            OnPropertyChanged();
        }
    }


    public LoadResourceJson()
	{
		InitializeComponent();

        LoadLocalResources();

        BindingContext = this;
	}


    private void LoadLocalResources()
    {
        #region How to load a text file embedded resource
        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
        Stream stream = assembly.GetManifestResourceStream("MauiLocalStorageExamples.LibJsonResource.json");

        string json = "";
        using (var reader = new StreamReader(stream))
        {
            json = reader.ReadToEnd();
        }

        var rootobject = JsonConvert.DeserializeObject<MonkeyRootobject>(json);
      
        Monkeys = new ObservableCollection<Monkey>(rootobject.Monkeys);

        #endregion
    }
}