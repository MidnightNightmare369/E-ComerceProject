﻿using Orders.Share.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Orders.Share.Entities;

public class Category : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Categoria")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} catacteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Name { get; set; } = null;
}