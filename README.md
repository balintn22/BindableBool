# BindableBool
A bool representation with IsTrue and IsFalse properties, to help WPF/Xamarin/Maui IsVisible/IsNotVisible binding.

In WPF/Maui, when displaying alternate UI components in certain cases, you bind their IsVisible properties to a bool.
It is easy for the one that is in sync with the true state, but quite filldy for the false one.

BindableBool implements IsTrue and IsFalse, so that IsVisible can be bound directly.

**Example**
In your viewModel:

    public BindableBool HasData { get => _myList?.Any() ?? false; }
    
  when the collection changes, don't forget to
  
    OnPropertyChanged(nameof(HasData));


In your view:

    <Label IsVisible="{Binding HasData.IsFalse}" Text="No Data" />

 for any component that may or may not show:

    <CollectionView IsVisible="{Binding HasData.IsTrue}" .../>

 ... or

    <Image IsVisible="{Binding HasData.Value}" .../>

**Notes**
- BindabeBool is implicitly convertible to bool so you can use as or compare with a boolean value.
  You can also do things like
    BindableBool bb = true;
    or
    public BindableBool HasData { get => _myList?.Any() ?? false; }

- BindableBool implements INotifyPropertyChanged such that you can bind to the Value, IsTrue and IsFalse properties as well.
