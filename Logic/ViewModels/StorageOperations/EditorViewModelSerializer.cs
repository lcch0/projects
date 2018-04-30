using Logic.Models;
using Storage.Serializable;
using Storage.Serializers;

namespace Logic.ViewModels.StorageOperations
{
    internal class EditorViewModelSerializer
    {
        private readonly TimeSheetsModel _model;

        public EditorViewModelSerializer(TimeSheetsModel model)
        {
            _model = model;
        }

        internal int SaveActivity(Activity activity, bool updateModel)
        {
            int id;
            using (var context = Factory.GetDbSerializer(_model.Settings.ConnectionStr))
            {
                if (activity.Project.Id == 0) context.AddRecord(activity.Project);

                if (activity.User.Id == 0)
                {
                    context.AddRecord(activity.User);
                }
                else
                {
                    context.UpdateRecord(activity.User);
                }

                if (activity.Id == 0)
                {
                    id = context.AddRecord(activity);
                    if (updateModel)
                    {
                        _model.Activities.Add(new ActivityModel(activity));
                        _model.RaisePropertyChanged(this, () => _model.Activities);
                    }
                }
                else
                {
                    id = context.UpdateRecord(activity);
                }
            }

            return id;
        }

        internal void DeleteActivity(Activity activity, bool updateModel)
        {
            using (var context = Factory.GetDbSerializer(_model.Settings.ConnectionStr))
            {
                if (activity.Id != 0)
                {
                    context.DeleteRecord(activity);
                    if (updateModel)
                    {
                        var count = _model.Activities.RemoveAll(a => a.Id == activity.Id);
                        if (count > 0)
                            _model.RaisePropertyChanged(this, () => _model.Activities);
                    }
                }
            }
        }
    }
}