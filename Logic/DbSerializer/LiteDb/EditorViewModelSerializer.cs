using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		internal void SaveActivity(Activity activity, ActivityModel editActivity)
		{
			using (var context = new LiteDbSerializer(_model.Settings.ConnectionStr))
			{
				if (activity.Project.Id == 0)
				{
					context.AddRecord(activity.Project, context.GetCollection<Project>());
				}

				if (activity.User.Id == 0)
				{
					context.AddRecord(activity.User, context.GetCollection<User>());
				}

				var collection = context.GetCollection<Activity>();
				collection = collection.Include(x => x.Project).Include(x => x.User);
				if (activity.Id == 0)
				{
					editActivity.Id = context.AddRecord(activity, collection);
					_model.Activities.Add(editActivity);
					_model.RaisePropertyChanged(this, () => _model.Activities);
				}
				else
				{
					editActivity.Id = context.UpdateRecord(activity, collection);
				}
			}
		}
	}
}
