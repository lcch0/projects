using System;
using Logic.Models;
using Storage.Interfaces;
using Storage.Serializable;
using Storage.Serializers;

namespace Logic.DbSerializer.LiteDb
{
    internal class MainFormViewSerializer
    {
        private readonly TimeSheetsModel _model;

        public MainFormViewSerializer(TimeSheetsModel model)
        {
            _model = model;
        }

        internal void LoadTo()
        {
            using (var context = Factory.GetDbSerializer(_model.Settings.ConnectionStr))
            {
                LoadProjects(context);
                LoadUsers(context);
                LoadActivities(context);
            }
        }

        private void LoadProjects(IDbSerializer context)
        {
            var projects = context.GetRecords<Project>();
            foreach (var project in projects)
            {
                var model = new ProjectModel(project);
                _model.Projects.Add(model);
            }

            if (_model.Projects.Count < 1)
                GenerateDefaultProjects(context);

            _model.SelectedProject = _model.Projects[0];

            foreach (var item in _model.Projects)
                if (item.ProjectDesc.Contains(_model.Settings.Project))
                {
                    _model.SelectedProject = item;
                    break;
                }
        }

        private void GenerateDefaultProjects(IDbSerializer context)
        {
            var pmodel = new ProjectModel {Id = 1, ProjectType = ProjectModel.EType.Design};
            _model.Projects.Add(pmodel);
            context.AddRecord(pmodel.GetStorageObject());

            pmodel = new ProjectModel {Id = 2, ProjectType = ProjectModel.EType.Mobile};
            _model.Projects.Add(pmodel);
            context.AddRecord(pmodel.GetStorageObject());

            pmodel = new ProjectModel {Id = 3, ProjectType = ProjectModel.EType.Unity};
            _model.Projects.Add(pmodel);
            context.AddRecord(pmodel.GetStorageObject());
        }

        private void LoadUsers(IDbSerializer context)
        {
            var users = context.GetRecords<User>();
            foreach (var user in users)
            {
                var model = new UserModel(user);
                _model.Users.Add(model);
            }

            if (_model.Users.Count == 0)
            {
                var user = new UserModel {Id = 1, Name = _model.Settings.UserName};
                _model.Users.Add(user);
                context.AddRecord(user.GetStorageObject());
            }

            _model.SelectedUser = _model.Users.Find(u =>
                u.Name.Equals(_model.Settings.UserName, StringComparison.OrdinalIgnoreCase));
            if (_model.SelectedUser == null)
                _model.SelectedUser = new UserModel {Name = _model.Settings?.UserName ?? "No user"};
        }

        private void LoadActivities(IDbSerializer context)
        {
            var activities = context.GetRecords<Activity>(-1);

            foreach (var activity in activities)
            {
                var model = new ActivityModel(activity);
                _model.Activities.Add(model);
            }
        }

        internal void GenerateDefaultData()
        {
            using (var context = Factory.GetDbSerializer(_model.Settings.ConnectionStr))
            {
                GenerateDefaultProjects(context);

                foreach (var model in _model.Projects) model.Id = context.AddRecord(model.GetStorageObject());

                var umodel = new UserModel {Id = 1, Name = "No user"};
                _model.Users.Add(umodel);

                foreach (var model in _model.Users) model.Id = context.AddRecord(model.GetStorageObject());

//				var a = new ActivityModel
//				{
//					Id = 1,
//					Date = DateTime.Now,
//					Days = 0,
//					Description = string.Empty,
//					ProjectType = ProjectModel.eType.Design,
//					UserName = umodel.Name
//				};

                foreach (var model in _model.Activities) model.Id = context.AddRecord(model.GetStorageObject());
            }
        }
    }
}