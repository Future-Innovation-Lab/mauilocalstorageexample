using System.Windows.Input;
using static Android.Renderscripts.ScriptGroup;

namespace MauiLocalStorageExamples;

public partial class SaveAndLoadText : ContentPage
{
    private string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");

    #region properties

    public ICommand SaveCommand { private set; get; }
    public ICommand LoadCommand { private set; get; }

    private string _inputText;

    public string InputText
    {
        get { return _inputText; }
        set {
            _inputText = value;

            OnPropertyChanged();
        }
    }

    private string _outputText;

    public string OutputText
    {
        get { return _outputText; }
        set
        {
            _outputText = value;

            OnPropertyChanged();
        }
    }


    private bool _loadButtonEnabled;

	public bool LoadButtonEnabled
	{
		get { return _loadButtonEnabled; }
		set { _loadButtonEnabled = value;

            OnPropertyChanged();
        }
	}

    private bool _saveButtonEnabled;

    public bool SaveButtonEnabled
    {
        get { return _saveButtonEnabled; }
        set { _saveButtonEnabled = value;

            OnPropertyChanged();
        }
    }

    #endregion


    public SaveAndLoadText()
	{
		InitializeComponent();

        SaveCommand = new Command(Save);
        LoadCommand = new Command(Load);

        SaveButtonEnabled = true;
        LoadButtonEnabled = true;

        BindingContext = this;
    }

    private void Load(object obj)
    {
        LoadButtonEnabled = SaveButtonEnabled = false;
        OutputText = File.ReadAllText(_fileName);
        LoadButtonEnabled = SaveButtonEnabled = true;
    }

    private void Save(object param)
    {
        LoadButtonEnabled = SaveButtonEnabled = false;
        File.WriteAllText(_fileName, InputText);
        LoadButtonEnabled = SaveButtonEnabled = true;
    }
}