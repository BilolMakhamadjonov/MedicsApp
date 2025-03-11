using System.ComponentModel;

namespace Medics.Core.Entities.Enum.User;

public enum UserGender
{
    [Description("Erkak")]
    Male = 1,

    [Description("Ayol")]
    Female = 2,

    [Description("Nomalum holatlar uchun")]
    Unknown = 3
}
