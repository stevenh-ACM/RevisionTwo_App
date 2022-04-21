#nullable disable

using RevisionTwo_App.Models;

namespace RevisionTwo_App.Auxillary;

public class AuthId
{
    public int getAuthId(List<AcuAuth> acuAuths)
    {
        foreach (AcuAuth acuAuth in acuAuths)
        {
            if (acuAuth.IsChecked)
            {
                return acuAuth.Id;
            }
        }
        return 0;
    }
}
