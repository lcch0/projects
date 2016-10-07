using SQLAccessor.Serializable;

namespace Logic.Models
{
    public class ProjectModel
    {
		public ProjectModel(Project project)
		{
			ProjectType = project?.Type ?? Project.ProjectType.Design;
		}

		public Project.ProjectType ProjectType { get; set; }

		public string ProjectDesc
		{
			get
			{
				switch (ProjectType)
				{
					case Project.ProjectType.Design:
						return "Design";
					case Project.ProjectType.Mobile:
						return "Mobile";
					case Project.ProjectType.Unity:
						return "Unity";
					default:
						return "Design";
				}
			}
		}
	}
}
