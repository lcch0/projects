using Logic.Models;
using Storage.Serializable;
using Storage.Serializers;

namespace Logic.DbSerializer.LiteDb
{
    internal class DraftViewModelSerializer
    {
        private readonly TimeSheetsModel _model;

        public DraftViewModelSerializer(TimeSheetsModel model)
        {
            _model = model;
        }

        internal void SaveActivity(ActivityModel activityModel)
        {
            var activity = GetActivity(activityModel);
            if (activity == null)
                return;

            using (var context = Factory.GetDbSerializer(_model.Settings.ConnectionStr))
            {
                if (activity.Project.Id == 0) 
                    context.AddRecord(activity.Project);

                if (activity.User.Id == 0) 
                    context.AddRecord(activity.User);

                if (activity.Id == 0)
                {
                    activityModel.Id = context.AddRecord(activity);
                    _model.RaisePropertyChanged(this, () => _model.Activities);
                }
                else
                {
                    context.UpdateRecord(activity);
                }
            }
        }

        private Activity GetActivity(ActivityModel activity)
        {
            var a = activity.GetStorageObject();
            a.Project = _model.SelectedProject.GetStorageObject();
            a.User = _model.SelectedUser.GetStorageObject();

            return a;
        }
    }
}