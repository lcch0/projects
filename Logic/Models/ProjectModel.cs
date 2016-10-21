using Storage.Serializable;

namespace Logic.Models
{
    public class ProjectModel
    {
		public enum eType
		{
			Design = 0,
			Mobile,
			Unity
		}

		public ProjectModel(Project project)
		{
			Id = project.Id;
			ProjectType = GetProjectType(project.ProjectType);
		}

	    public int Id { get; set; }
		public eType ProjectType { get; set; }
		public string ProjectDesc => GetProjectDesc(ProjectType);

	    public static string GetProjectDesc(eType projectType)
	    {
		    switch (projectType)
		    {
			    case eType.Design:
				    return "Design";
			    case eType.Mobile:
				    return "Mobile";
			    case eType.Unity:
				    return "Unity";
			    default:
				    return "Design";
		    }
	    }

	    public static eType GetProjectType(int? value)
	    {
			if(value == null)
				return eType.Design;

			if (value == (int) eType.Mobile)
			    return eType.Mobile;

			if (value == (int)eType.Design)
				return eType.Design;

			if (value == (int)eType.Unity)
				return eType.Unity;

			return eType.Design;
		}

	    public override string ToString()
	    {
		    return GetProjectDesc(ProjectType);
	    }

	    public Project GetStorageObject()
	    {
		    return new Project
		    {
			    Id = Id,
				ProjectType = (int)ProjectType
		    };
	    }
    }
}
