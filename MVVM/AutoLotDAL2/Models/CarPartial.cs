using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL2.Models
{
    public partial class Car : EntityBase
    {
        public override string ToString()
        {
            //Since the CarNickName column could be empty, supply the default name of **No Name**
            return $"{this.CarNickName ?? "**No Name**"} is a {this.Color} {this.Make} with ID {this.CarId}.";
        }

        public override string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(CarId):
                        errors = GetErrorsFromAnnotations(nameof(CarId), CarId);
                        break;
                    case nameof(Make):
                        hasError = CheckMakeAndColor();
                        if (Make == "ModelT")
                        {
                            AddError(nameof(Make), "Too Old");
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Make));
                        errors = GetErrorsFromAnnotations(nameof(Make), Make);
                        break;
                    case nameof(Color):
                        hasError = CheckMakeAndColor();
                        if (!hasError) ClearErrors(nameof(Color));
                        errors = GetErrorsFromAnnotations(nameof(Color), Color);
                        break;
                    case nameof(CarNickName):
                        errors = GetErrorsFromAnnotations(nameof(CarNickName), CarNickName);
                        break;
                }
                if (errors != null && errors.Length != 0)
                {
                    AddErrors(columnName, errors);
                    hasError = true;
                }
                if (!hasError) ClearErrors(columnName);
                return string.Empty;
            }
        }
        internal bool CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Pink")
            {
                //return $"{Make}'s don't come in {Color}";
                AddError(nameof(Color), $"{Make}'s don't come in {Color}");
                AddError(nameof(Make), $"{Make}'s don't come in {Color}");
                return true;
            }
            return false;
        }
    }
}
