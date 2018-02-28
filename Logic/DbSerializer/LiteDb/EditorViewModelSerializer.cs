using Logic.Models;
using Storage.Serializable;
using Storage.Serializers;

namespace Logic.DbSerializer.LiteDb
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
            using (var context = new LiteDbSerializer(_model.Settings.ConnectionStr))
            {
                if (activity.Project.Id == 0) context.AddRecord(activity.Project, context.GetCollection<Project>());

                if (activity.User.Id == 0) context.AddRecord(activity.User, context.GetCollection<User>());

                var collection = context.GetCollection<Activity>();
                collection = collection.Include(x => x.Project).Include(x => x.User);
                if (activity.Id == 0)
                {
                    id = context.AddRecord(activity, collection);
                    if (updateModel)
                    {
                        _model.Activities.Add(new ActivityModel(activity));
                        _model.RaisePropertyChanged(this, () => _model.Activities);
                    }
                }
                else
                {
                    id = context.UpdateRecord(activity, collection);
                }
            }

            return id;
        }

        internal void DeleteActivity(Activity activity, bool updateModel)
        {
            using (var context = new LiteDbSerializer(_model.Settings.ConnectionStr))
            {
                var collection = context.GetCollection<Activity>();
                collection = collection.Include(x => x.Project).Include(x => x.User);
                if (activity.Id != 0)
                {
                    context.DeleteRecord(activity, collection);
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