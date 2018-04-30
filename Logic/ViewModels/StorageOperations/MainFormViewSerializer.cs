using System;
using Logic.Models;
using Storage.Interfaces;
using Storage.Serializable;
using Storage.Serializers;

namespace Logic.ViewModels.StorageOperations
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

            _model.SelectedProject = _model.Projects[0];

            foreach (var item in _model.Projects)
                if (item.ProjectDesc.Contains(_model.Settings.Project))
                {
                    _model.SelectedProject = item;
                    break;
                }
        }

        private void LoadUsers(IDbSerializer context)
        {
            var users = context.GetRecords<User>();
            foreach (var user in users)
            {
                var model = new UserModel(user);
                _model.Users.Add(model);
            }

            _model.SelectedUser = _model.Users.Find(u =>
                u.Name.Equals(_model.Settings.UserName, StringComparison.OrdinalIgnoreCase));

            if (_model.SelectedUser == null)
            {
                _model.SelectedUser = new UserModel {Name = _model.Settings?.UserName ?? "No user"};
            }
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
    }
}