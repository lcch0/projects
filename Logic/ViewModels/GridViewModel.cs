using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;

namespace Logic.ViewModels
{
    public class GridViewModel : BaseViewModel
    {
        public GridViewModel(TimeSheetsModel model) : base(model)
        {
            Model = model;
            SelectionChangedCommand = new RelayCommand<ActivityModel>(SelectionChanged);
            SelectRowsCommand = new RelayCommand<IEnumerable<ActivityModel>>(SelectRows);
        }

        private void SelectRows(IEnumerable<ActivityModel> rows)
        {
            Model.SelectedActivities = rows.ToList();
        }

        public List<ActivityModel> EditEntries
        {
            get => Model.Activities;
            set => Model.Activities = value;
        }

        public ICommand SelectionChangedCommand { get; set; }
        public ICommand SelectRowsCommand { get; set; }

        private void SelectionChanged(ActivityModel obj)
        {
            Model.SelectedActivity = obj;
        }

        protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender != this && e.PropertyName == nameof(Model.Activities))
                base.OnModelPropertyChanged(sender, e);
        }
    }
}