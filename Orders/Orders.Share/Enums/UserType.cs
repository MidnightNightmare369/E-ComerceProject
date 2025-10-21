using System.ComponentModel;

namespace Orders.Share.Enums;

public enum UserType
{
    [Description("Administrador")]
    Admin,

    [Description("Usuario")]
    User
}