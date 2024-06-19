using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeVistoria.Infra.Data.IdentityData.Data;

// Add profile data for application users by adding properties to the ControleDeVistoriaIdentityUser class
public class ControleDeVistoriaIdentityUser : IdentityUser 
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Nome { get; set; }
}

