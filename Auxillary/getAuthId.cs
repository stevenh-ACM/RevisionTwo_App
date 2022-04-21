#nullable disable

using RevisionTwo_App.Models;

namespace RevisionTwo_App.Auxillary;

public class AuthId
{
    public int getAuthId(List<Credential> credentials)
    {
        foreach (Credential credential in credentials)
        {
            if (credential.IsChecked)
            {
                return credential.Id;
            }
        }
        return 0;
    }
}
