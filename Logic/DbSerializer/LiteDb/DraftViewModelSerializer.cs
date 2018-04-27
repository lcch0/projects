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

            using (var context = SerializerFactory.GetDbSerializer(_model.Settings.ConnectionStr))
            {
                if (activity.Project.Id == 0) context.AddRecord(activity.Project, context.GetCollection<Project>());

                if (activity.User.Id == 0) context.AddRecord(activity.User, context.GetCollection<User>());

                var collection = context.GetCollection<Activity>();
                collection = collection.Include(x => x.Project).Include(x => x.User);
                if (activity.Id == 0)
                {
                    activityModel.Id = context.AddRecord(activity, collection);
                    _model.RaisePropertyChanged(this, () => _model.Activities);
                }
                else
                {
                    context.UpdateRecord(activity, collection);
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