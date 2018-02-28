using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.Models.mvvm;

namespace Logic.ViewModels
{
    public class GridViewModel : BaseViewModel
    {
        public GridViewModel(TimeSheetsModel model) : base(model)
        {
            Model = model;
            SelectionChangedCommand = new RelayCommand<ActivityModel>(SelectionChanged);
        }

        public List<ActivityModel> EditEntries
        {
            get => Model.Activities;
            set => Model.Activities = value;
        }

        public ICommand SelectionChangedCommand { get; set; }

        private void SelectionChanged(ActivityModel obj)
        {
            Model.SelectedActivity = obj;
        }

        protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender != this && e.PropertyName == PropertySupport.ExtractPropertyName(() => Model.Activities))
                base.OnModelPropertyChanged(sender, e);
        }
    }
}