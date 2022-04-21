
//using RevisionTwo_App.Models;

//using System.ComponentModel.DataAnnotations;

//namespace RevisionTwo_App.Auxillary;

//public class RequiredCustomAttribute : ValidationAttribute
//{
//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        var Model = (AllCreds)validationContext.ObjectInstance;

//        var checkBoxCounter = 0;
//        foreach (var item in Model.Creds)
//        {
//            if (item.IsChecked == true)
//            {
//                checkBoxCounter++;
//            }
//            if (item.IsChecked == true && checkBoxCounter == 1)
//            {
//                return new ValidationResult(ErrorMessage = "You have selected checkbox!");
//            }
//            else
//            {
//                return new ValidationResult(ErrorMessage == null ? "Please check one checkbox!" : ErrorMessage);
//            }

//        }

//        return ValidationResult.Success;
//    }
//}

